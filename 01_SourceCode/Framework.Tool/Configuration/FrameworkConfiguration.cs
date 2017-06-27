using System;
using System.Configuration;
using System.IO;
using System.Xml;
using Framework.Tool.Common;

namespace Framework.Tool.Configuration
{
    public class FrameworkConfiguration : IConfigurationSectionHandler
    {
        public object Create(object parent, object configContext, System.Xml.XmlNode section)
        {
            var config = BuildDefaultConfig();
            if (section != null && section.HasChildNodes)
            {
                foreach (XmlNode node in section.ChildNodes)
                {
                    if (node.Name.Equals(Constants.Log_setting_Node))
                    {
                        if (node.Attributes[Constants.Log_Attri_Provider] != null 
                            && node.Attributes[Constants.Log_Attri_Provider].Value != null)
                        {
                            config.LogSetting.LogType = node.Attributes[Constants.Log_Attri_Provider].Value.Trim();
                        }

                        if (node.Attributes[Constants.Log_Attri_Folder] != null 
                            && node.Attributes[Constants.Log_Attri_Folder].Value != null)
                        {
                            var folder = node.Attributes[Constants.Log_Attri_Folder].Value.Trim();
                            string path = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, folder);
                            config.LogSetting.LogFolder = path;
                        }

                        if (node.Attributes[Constants.Log_Attri_Dispatcher] != null 
                            && node.Attributes[Constants.Log_Attri_Dispatcher].Value != null)
                        {
                            config.LogSetting.DispatchType = node.Attributes[Constants.Log_Attri_Dispatcher].Value.Trim();
                        }
                    }
                }
            }
            return config;
        }

        private FrameworkConfig BuildDefaultConfig()
        {
            return new FrameworkConfig
            {
                LogSetting = new LogSetting
                {
                    LogType = Constants.Log_Default_Type,
                    LogFolder = Constants.Log_Default_Folder,
                    DispatchType = string.Empty
                }
            };
        }
    }
}
