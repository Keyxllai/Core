using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Framework.Tool.Context
{
    public abstract class BaseResponse : ILog
    {
        public string OriginalTriggerID { get; set; }
        public List<string> Logs { get; set; }
        public bool Succeed { get; set; }
        public string Language { get; set; }
    }
}
