using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MingCore
{
    public enum LOG_LEVEL
    {
        ERROR,
        DEBUG,
        DETAIL,
        BASIC
    }

    public class LogEntry
    {
        public LogEntry(LOG_LEVEL pmLogLevel, string pmLogContent)
        {
            logLevel = pmLogLevel;
            logContent = pmLogContent;
        }

        #region declaration
        private LOG_LEVEL logLevel;
        public LOG_LEVEL LogLevel
        {
            get
            {
                return LogLevel;
            }
        }

        private string logContent;
        public string LogContent
        {
            get
            {
                return logContent;
            }
        }
        #endregion
    }

    public class MLogger
    {
        public static void InitLoggers(string pmLogPath)
        {
            if (runtimeLogger == null)
            {
                runtimeLogger = new MixLogger(pmLogPath, "Runtime");
            }
            if (networkLogger == null)
            {
                networkLogger = new MixLogger(pmLogPath, "Network");
            }
        }
        #region declaration
        private static MixLogger runtimeLogger = null;
        public static MixLogger RuntimeLogger
        {
            get
            {
                return runtimeLogger;
            }
        }

        private static MixLogger networkLogger = null;
        public static MixLogger NetworkLogger
        {
            get
            {
                return networkLogger;
            }
        }
        #endregion
    }

    public class MixLogger
    {
        public MixLogger(string pmLogPath, string pmLogName)
        {
            this.logPath = pmLogPath;
            this.logName = pmLogName;
            this.logQueue = new BlockQueue<LogEntry>(1000);
            this.logger = log4net.LogManager.GetLogger(this.GenerateCurrentLog4NetRepository(), pmLogName);
        }

        #region declaration
        private string logPath = "";
        public string LogPath
        {
            get
            {
                return this.logPath;
            }
        }

        private string logName = "";
        public string LogName
        {
            get
            {
                return this.logName;
            }
        }

        private log4net.ILog logger = null;
        public log4net.ILog Logger
        {
            get
            {
                return logger;
            }
        }

        private BlockQueue<LogEntry> logQueue = null;
        #endregion

        #region business
        private string GenerateCurrentLog4NetRepository()
        {
            string result = "";

            ///Appender
            log4net.Appender.RollingFileAppender appender = new log4net.Appender.RollingFileAppender();

            appender.AppendToFile = true;
            appender.File = this.logPath + "\\" + this.logName;
            appender.RollingStyle = log4net.Appender.RollingFileAppender.RollingMode.Composite;
            appender.DatePattern = ".dd";
            appender.MaxSizeRollBackups = 100;
            appender.MaximumFileSize = "100MB";
            appender.CountDirection = 1;
            appender.ImmediateFlush = true;
            appender.LockingModel = new log4net.Appender.FileAppender.MinimalLock();

            ///layout  
            //log4net.Layout.PatternLayout layout = new log4net.Layout.PatternLayout("%message%newline");
            log4net.Layout.PatternLayout layout = new log4net.Layout.PatternLayout("%-5level:%message%newline");
            layout.Header = "------ New session ------" + Environment.NewLine;
            layout.Footer = "------ End session ------" + Environment.NewLine;
            //              
            appender.Layout = layout;
            appender.ActivateOptions();
            //  
            log4net.Repository.ILoggerRepository repository = log4net.LogManager.CreateRepository(this.logName + "Repository");
            log4net.Config.BasicConfigurator.Configure(repository, appender);
            result = repository.Name;

            return result;
        }

        private void EnqueueLog(LOG_LEVEL pmLogLevel, string pmLogContent)
        {
            if (this.logQueue.Count > 500)
            {
                this.logQueue.Clear();
            }
            this.logQueue.Enqueue(new LogEntry(pmLogLevel, pmLogContent));
        }

        public void Debug(string pmContent)
        {
            this.logger.Info(pmContent);
            this.EnqueueLog(LOG_LEVEL.DEBUG, pmContent);
        }

        public void Basic(string pmContent)
        {
            this.logger.Info(pmContent);
            this.EnqueueLog(LOG_LEVEL.BASIC, pmContent);
        }

        public void Detail(string pmContent)
        {
            this.logger.Info(pmContent);
            this.EnqueueLog(LOG_LEVEL.DETAIL, pmContent);
        }

        public void Error(string pmContent)
        {
            this.logger.Error(pmContent);
            this.EnqueueLog(LOG_LEVEL.ERROR, pmContent);
        }

        public LogEntry DequeueLog()
        {
            return this.logQueue.Dequeue();
        }
        #endregion
    }
}
