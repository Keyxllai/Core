using System;
using System.Collections.Generic;

namespace Framework.Tool.Context
{
    public interface ILogger
    {
        void Warn(string msg);
        void Error(string msg);
        void Info(string msg);
        void Debug(string msg);
    }
    public class Logger : ILogger
    {
        /// <summary>
        /// Implemenation class can collect differenct type logs
        /// </summary>
        public ILog _logCollecter;

        public Logger(ILog log)
        {
            _logCollecter = log;
        }

        private void TraceLog(string type, string msg)
        {
            if(null == _logCollecter) return;
            if (null == _logCollecter.Logs)
            {
                _logCollecter.Logs = new List<string>();
            }
            _logCollecter.Logs.Add(string.Format("[{0}] {1} {2}", DateTime.Now.ToShortTimeString(), type, msg));
        }

        public void Warn(string msg)
        {
            TraceLog("Warn", msg);
        }

        public void Error(string msg)
        {
            TraceLog("Error", msg);
        }

        public void Info(string msg)
        {
            TraceLog("Info", msg);
        }

        public void Debug(string msg)
        {
            TraceLog("Debug", msg);
        }
    }
}
