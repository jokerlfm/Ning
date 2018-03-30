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
            outAPQueue = new BlockQueue<AuthPacket>(1000);
            receiveThread = null;
            sendThread = null;
            handleThread = null;
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
        private BlockQueue<AuthPacket> outAPQueue;
        private Thread receiveThread;
        private Thread sendThread;
        private Thread handleThread;

        private void DoReceiving()
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
                            MLogger.NetworkLogger.Error("Receive buffer appending error occured : " + this.clientSocket.Handle);
                            this.StopSession();
                        }
                    }
                    else
                    {
                        MLogger.NetworkLogger.Error("Auth client socket disconnected : " + this.clientSocket.Handle);
                        this.StopSession();
                    }
                }
            }
            catch (Exception exp)
            {
                MLogger.NetworkLogger.Error("Auth client receiving exp :" + this.clientSocket.Handle + " " + exp.Message);
                this.StopSession();
            }            
        }

        private void DoSending()
        {
            while (this.working)
            {
                AuthPacket ap = outAPQueue.Dequeue();
                if (ap != null)
                {
                    int sentLength = clientSocket.Send(ap.GetPacketBuffer());
                    if (sentLength < 1)
                    {
                        MLogger.NetworkLogger.Error("Auth client socket sent 0 bytes : " + this.clientSocket.Handle);
                        this.StopSession();
                    }
                }
                Thread.Sleep(10);
            }
        }

        private void DoHandling()
        {
            while (this.working)
            {
                byte[] headBytes = GetBuffer(4);
                if (headBytes != null)
                {
                    AUTH_OPCODE currentOpcode = (AUTH_OPCODE)headBytes[0];
                    AuthReceiveBufferHandler.HandleAuthOpcode(this, currentOpcode);
                    authReceiveBuffer.ResetBuffer();
                }
                Thread.Sleep(10);
            }
        }

        public byte[] GetBuffer(int pmCount)
        {
            return authReceiveBuffer.Take(4);
        }

        public void StartSession()
        {
            this.working = true;
            receiveThread = new Thread(new ThreadStart(DoReceiving));
            receiveThread.IsBackground = true;
            receiveThread.Start();
            sendThread = new Thread(new ThreadStart(DoSending));
            sendThread.IsBackground = true;
            sendThread.Start();
            handleThread = new Thread(new ThreadStart(DoHandling));
            handleThread.IsBackground = true;
            handleThread.Start();
        }

        public void StopSession()
        {
            if (this.working)
            {
                this.working = false;
                SocketOperator.FinishSocket(ref clientSocket);
                try
                {
                    if (receiveThread != null)
                    {
                        receiveThread.Abort();
                    }
                }
                catch (Exception)
                {

                }
                receiveThread = null;
                try
                {
                    if (sendThread != null)
                    {
                        sendThread.Abort();
                    }
                }
                catch (Exception)
                {

                }
                sendThread = null;
                try
                {
                    if (handleThread != null)
                    {
                        handleThread.Abort();
                    }
                }
                catch (Exception)
                {

                }
                handleThread = null;
                this.outAPQueue.Clear();                
            }
        }
    }
}