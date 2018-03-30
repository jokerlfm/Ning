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
    public class RealmClientSession
    {
        public RealmClientSession(Socket pmSocket)
        {
            this.clientSocket = pmSocket;
            realmReceiveBuffer = new ReceiveBuffer(1048576);
            outRPQueue = new Queue<RealmPacket>();
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

        private ReceiveBuffer realmReceiveBuffer;
        private Queue<RealmPacket> outRPQueue;        

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
                        if (!realmReceiveBuffer.Append(buffer.Take(receivedLength).ToArray()))
                        {
                            MLogger.NetworkLogger.Error("Receive buffer appending error occured : " + this.clientSocket.Handle);
                            this.StopSession();
                        }
                    }
                    else
                    {
                        MLogger.NetworkLogger.Error("Realm client socket disconnected : " + this.clientSocket.Handle);
                        this.StopSession();
                    }
                }
            }
            catch (Exception exp)
            {
                MLogger.NetworkLogger.Error("Realm client receiving exp :" + this.clientSocket.Handle + " " + exp.Message);
                this.StopSession();
            }            
        }

        private void ClientSending(object pmMain = null)
        {
            try
            {
                while (this.working)
                {
                    RealmPacket rp = outRPQueue.Dequeue();
                    if (rp != null)
                    {
                        int sentLength = clientSocket.Send(rp.GetPacketBuffer());
                        if (sentLength < 1)
                        {
                            MLogger.NetworkLogger.Error("Realm client socket sent 0 bytes : " + this.clientSocket.Handle);
                            this.StopSession();
                        }
                    }
                    Thread.Sleep(10);
                }
            }
            catch (Exception exp)
            {
                MLogger.NetworkLogger.Error("Realm client sending exp :" + this.clientSocket.Handle + " " + exp.Message);
                this.StopSession();
            }
        }

        private void ClientReceiveBufferHandling(object pmMain = null)
        {
            try
            {
                while (this.working)
                {
                    byte[] headBytes = realmReceiveBuffer.Take(6);
                    if (headBytes != null)
                    {
                        REALM_OPCODE currentOpcode = (REALM_OPCODE)headBytes[0];
                        RealmReceiveBufferHandler.HandleRealmOpcode(this, currentOpcode);
                    }
                    Thread.Sleep(10);
                }
            }
            catch (Exception exp)
            {
                MLogger.NetworkLogger.Error("Realm client receive buffer handling exp :" + this.clientSocket.Handle + " " + exp.Message);
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