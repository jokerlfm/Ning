using MingCore;
using NingCore.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace NingCore.Business
{
    public class AuthClientSession
    {
        public AuthClientSession(Socket pmSocket)
        {
            this.clientSocket = pmSocket;
            authReceiveBuffer = new ReceiveBuffer(1048576);
            outAPQueue = new Queue<AuthPacket>();
            this.working = false;
        }

        private Socket clientSocket;
        private bool working;
        public bool Working
        {
            get
            {
                return this.working;
            }
        }

        private ReceiveBuffer authReceiveBuffer;
        private Queue<AuthPacket> outAPQueue;        

        private void ClientReceiving(object pmMain = null)
        {
            try
            {
                while (this.working)
                {
                    byte[] buffer = new byte[1024];
                    int receivedLength = this.clientSocket.Receive(buffer);
                    if (receivedLength > 0)
                    {
                        if (!authReceiveBuffer.Append(buffer.Take(receivedLength).ToArray()))
                        {
                            MLogger.NetworkLogger.Warn("Receive buffer appending error occured : " + this.clientSocket.Handle);
                            this.StopSession();
                        }
                    }
                    else
                    {
                        MLogger.NetworkLogger.Warn("Auth client socket disconnected : " + this.clientSocket.Handle);
                        this.StopSession();
                    }
                }
            }
            catch (Exception exp)
            {
                MLogger.NetworkLogger.Warn("Auth client receiving exp :" + this.clientSocket.Handle + " " + exp.Message);
                this.StopSession();
            }            
        }

        private void ClientSending(object pmMain = null)
        {
            try
            {
                while (this.working)
                {
                    AuthPacket ap = outAPQueue.Dequeue();
                    if (ap != null)
                    {
                        int sentLength = clientSocket.Send(ap.GetPacketBuffer());
                        if (sentLength < 1)
                        {
                            MLogger.NetworkLogger.Warn("Auth client socket sent 0 bytes : " + this.clientSocket.Handle);
                            this.StopSession();
                        }
                    }
                    Thread.Sleep(10);
                }
            }
            catch (Exception exp)
            {
                MLogger.NetworkLogger.Warn("Auth client sending exp :" + this.clientSocket.Handle + " " + exp.Message);
                this.StopSession();
            }
        }

        private void ClientReceiveBufferHandling(object pmMain = null)
        {
            try
            {
                while (this.working)
                {
                    byte[] headBytes = authReceiveBuffer.Take(4);
                    if (headBytes != null)
                    {
                        AUTH_OPCODE currentOpcode = (AUTH_OPCODE)headBytes[0];
                        AuthReceiveBufferHandler.HandleAuthOpcode(this, currentOpcode);
                    }
                    Thread.Sleep(10);
                }
            }
            catch (Exception exp)
            {
                MLogger.NetworkLogger.Warn("Auth client receive buffer handling exp :" + this.clientSocket.Handle + " " + exp.Message);
                this.StopSession();
            }
        }

        public void StartSession()
        {
            this.working = true;
            WaitCallback wcb1 = new WaitCallback(this.ClientReceiving);
            ThreadPool.QueueUserWorkItem(wcb1, null);
            WaitCallback wcb2 = new WaitCallback(this.ClientSending);
            ThreadPool.QueueUserWorkItem(wcb2, null);
            WaitCallback wcb3 = new WaitCallback(this.ClientReceiveBufferHandling);
            ThreadPool.QueueUserWorkItem(wcb3, null);
        }

        public void StopSession()
        {
            MingCore.SocketOperator.FinishSocket(ref clientSocket);
            this.working = false;
        }
    }
}