using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Framework.Tool.Context
{
    public class BaseContext<T1,T2> : ILogger
        where T1: class 
        where T2: BaseResponse
    {
        public ILogger Logger;
        public BaseContext(T1 request, T2 response)
        {
            Logger = new Logger(response);
        }

        public void Warn(string msg)
        {
            Logger.Warn(msg);
        }

        public void Error(string msg)
        {
            Logger.Error(msg);
        }

        public void Info(string msg)
        {
            Logger.Info(msg);
        }

        public void Debug(string msg)
        {
            Logger.Debug(msg);
        }
    }
}
