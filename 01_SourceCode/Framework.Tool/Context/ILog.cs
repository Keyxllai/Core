using System.Collections.Generic;

namespace Framework.Tool.Context
{
    public interface ILog
    {
        string OriginalTriggerID { get; set; }
        List<string> Logs { get; set; }
    }
}
