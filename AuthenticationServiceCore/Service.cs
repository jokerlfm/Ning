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
            clients = null;
            loggingThread = null;
            clientAcceptingThread = null;
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
        private Thread clientAcceptingThread;
        private Thread loggingThread;
        #endregion

        #region business
        public void Start()
        {
            if (!this.working)
            {
                this.working = true;

                loggingThread = new Thread(new ThreadStart(DoConsoleLogging));
                loggingThread.IsBackground = true;
                loggingThread.Start();
                
                ConfigManager.LoadConfigs(CONFIG_TYPE.AUTHENTICATION_SERVER_CONFIG);
                Store.InitializeAllPassportStores();

                clients = new List<AuthClientSession>();

                this.authClientListener = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
                this.authServerIEP = new IPEndPoint(IPAddress.Any, 8081);
                this.authClientListener.Bind(this.authServerIEP);
                this.authClientListener.Listen(10);

                clientAcceptingThread = new Thread(new ThreadStart(DoAuthClientAccepting));
                clientAcceptingThread.IsBackground = true;
                clientAcceptingThread.Start();                
                MLogger.RuntimeLogger.Basic("authentication server listener started. " + this.authServerIEP.Address.ToString() + ":" + this.authServerIEP.Port);

                MLogger.RuntimeLogger.Basic("authentication server started.");
            }
        }

        private void DoAuthClientAccepting()
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

        private void DoConsoleLogging()
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
            this.working = false;

            SocketOperator.FinishSocket(ref this.authClientListener);
            MLogger.RuntimeLogger.Basic("Client listener Stopped.");

            try
            {
                if(clientAcceptingThread!=null)
                {
                    clientAcceptingThread.Abort();
                }
            }
            catch (Exception)
            {
                
            }
            clientAcceptingThread = null;
            MLogger.RuntimeLogger.Basic("Client accepting thread aborted.");
            MLogger.RuntimeLogger.Basic("Authentication server Stopped.");

            try
            {
                if (loggingThread != null)
                {
                    loggingThread.Abort();
                }
            }
            catch (Exception)
            {

            }
            loggingThread = null;
        }
        #endregion
    }
}