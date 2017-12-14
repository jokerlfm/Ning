using MingCore;
using NingCore.Runtime;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace RealmServiceCore
{
    public class Service
    {
        private Service()
        {
            MLogger.InitLoggers("RealmLog");
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
        private Socket realmClientListener = null;
        private IPEndPoint realmServerIEP;

        private bool working = false;
        public bool Working
        {
            get
            {
                return this.working;
            }
        }
        #endregion

        #region business
        public void Start()
        {
            if (!this.working)
            {
                this.working = true;
                WaitCallback wcbLogging = new WaitCallback(this.DoConsoleLogging);
                ThreadPool.QueueUserWorkItem(wcbLogging, null);

                ConfigManager.LoadConfigs(ConfigType.REALM_SERVER_CONFIG);
                Store.InitializeAllArchiveStores();
                Store.InitializeAllWorldStores();
                Store.InitializeAllPatchStores();

                this.realmClientListener = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
                this.realmServerIEP = new IPEndPoint(IPAddress.Any, 8085);
                this.realmClientListener.Bind(this.realmServerIEP);
                this.realmClientListener.Listen(10);
                WaitCallback wcb1 = new WaitCallback(this.DoAuthClientAccepting);
                ThreadPool.QueueUserWorkItem(wcb1, null);
                MLogger.RuntimeLogger.Info("Realm server listener started. " + this.realmServerIEP.Address.ToString() + ":" + this.realmServerIEP.Port);

                MLogger.RuntimeLogger.Info("Realm server started.");
            }
        }

        private void DoAuthClientAccepting(object pmMain = null)
        {
            while (this.working)
            {
                Socket realmClientSocket = this.realmClientListener.Accept();

                try
                {

                }
                catch (Exception exp)
                {
                    MLogger.NetworkLogger.Error("Realm client accept error : " + exp.Message);
                    FinishSocket(ref realmClientSocket);
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
                if (this.realmClientListener != null)
                {
                    if (this.realmClientListener.Connected)
                    {
                        this.realmClientListener.Shutdown(SocketShutdown.Both);
                        this.realmClientListener.Disconnect(false);
                    }
                    this.realmClientListener.Close();
                    this.realmClientListener.Dispose();
                }
            }
            catch (Exception exp)
            {
                MLogger.RuntimeLogger.Error("Realm client listener closing exp : " + exp.Message);
            }
            finally
            {
                FinishSocket(ref realmClientListener);
            }

            MLogger.RuntimeLogger.Info("Realm server Stopped.");

            this.working = false;
        }

        private void FinishSocket(ref Socket pmTarget)
        {
            if (pmTarget != null)
            {
                try
                {
                    if (pmTarget.Connected)
                    {
                        pmTarget.Disconnect(false);
                    }
                    pmTarget.Dispose();
                }
                catch (Exception)
                {

                }
                finally
                {
                    pmTarget = null;
                }
            }
        }
        #endregion
    }
}
