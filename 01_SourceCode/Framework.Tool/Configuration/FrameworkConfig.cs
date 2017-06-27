using Framework.Tool.Common;
using System.Configuration;

namespace Framework.Tool.Configuration
{
    public class FrameworkConfig
    {
        public LogSetting LogSetting { get; set; }
        private static FrameworkConfig _config;
        private static object _lock = new object();
        public static FrameworkConfig Instance
        {
            get
            {
                if (null == _config)
                {
                    lock (_lock)
                    {
                        _config = ConfigurationManager.GetSection(Constants.SectionName) as FrameworkConfig;
                    }
                }
                return _config;
            }
        }
    }

    public class LogSetting
    {
        public string LogType { get; set; }
        public string LogFolder { get; set; }
        public string DispatchType { get; set; }
    }
}
