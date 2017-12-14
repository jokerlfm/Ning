using MingCore;
using NingCore.Business;
using NingCore.Runtime;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace AuthenticationServiceCore
{
    public class Service
    {
        private Service()
        {
            MLogger.InitLoggers("AuthLog");
        }

        private Service(string pmLogPath)
        {
            MLogger.InitLoggers(pmLogPath);
        }

        private static Service mainService = null;

        public static Service GetService()
        {
            if (mainService == null)
            {
                mainService = new Service();
            }
            return mainService;
        }

        public static Service GetService(string pmLogPath)
        {
            if (mainService == null)
            {
                mainService = new Service(pmLogPath);
            }
            return mainService;
        }

        #region declaration
        private Socket authClientListener = null;
        private IPEndPoint authServerIEP;

        private bool working = false;
        public bool Working
        {
            get
            {
                return this.working;
            }
        }

        private List<AuthClientSession> clients;
        #endregion

        #region business
        public void Start()
        {
            if (!this.working)
            {
                this.working = true;
                WaitCallback wcbLogging = new WaitCallback(this.DoConsoleLogging);
                ThreadPool.QueueUserWorkItem(wcbLogging, null);

                ConfigManager.LoadConfigs(ConfigType.AUTHENTICATION_SERVER_CONFIG);
                Store.InitializeAllPassportStores();

                clients = new List<AuthClientSession>();

                this.authClientListener = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
                this.authServerIEP = new IPEndPoint(IPAddress.Any, 8081);
                this.authClientListener.Bind(this.authServerIEP);
                this.authClientListener.Listen(10);
                WaitCallback wcb1 = new WaitCallback(this.DoAuthClientAccepting);
                ThreadPool.QueueUserWorkItem(wcb1, null);
                MLogger.RuntimeLogger.Info("authentication server listener started. " + this.authServerIEP.Address.ToString() + ":" + this.authServerIEP.Port);

                MLogger.RuntimeLogger.Info("authentication server started.");
            }
        }

        private void DoAuthClientAccepting(object pmMain = null)
        {
            while (this.working)
            {
                Socket authClientSocket = this.authClientListener.Accept();

                try
                {
                    AuthClientSession newACS = new AuthClientSession(authClientSocket);
                    clients.Add(newACS);
                    newACS.StartSession();
                }
                catch (Exception exp)
                {
                    MLogger.NetworkLogger.Error("Authentication client accept error : " + exp.Message);
                    MingCore.SocketOperator.FinishSocket(ref authClientSocket);
                }
            }
        }

        private void DoConsoleLogging(object pmMain = null)
        {
            while (this.working)
            {
                try
                {
                    Console.WriteLine(MLogger.RuntimeLogger.DequeueLog());
                }
                catch (Exception outerEXP)
                {
                    MLogger.RuntimeLogger.Error("console logging exp : " + outerEXP.Message);
                }
            }
        }

        public void Stop()
        {
            try
            {
                if (this.authClientListener != null)
                {
                    if (this.authClientListener.Connected)
                    {
                        this.authClientListener.Shutdown(SocketShutdown.Both);
                        this.authClientListener.Disconnect(false);
                    }
                    this.authClientListener.Close();
                    this.authClientListener.Dispose();
                }
            }
            catch (Exception exp)
            {
                MLogger.RuntimeLogger.Error("Authentication client listener closing exp : " + exp.Message);
            }
            finally
            {
                MingCore.SocketOperator.FinishSocket(ref authClientListener);
            }
            
            MLogger.RuntimeLogger.Info("Authentication server Stopped.");

            this.working = false;
        }
        #endregion
    }
}