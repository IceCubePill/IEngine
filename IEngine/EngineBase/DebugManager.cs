using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


/*************************************************************
** MadeBy		：			IceCubePill						**
** Time			:			 2018/10/20 22:03:29							**
** Description	：											**
**************************************************************/
namespace IEngine.EngineBase
{
    public enum DebugType
    {
        Normol,
        Warnning,
        Error,
        Special,

    }
    public class DebugManager:SingleType<DebugManager>
    {
        private static StringBuilder DebugLog_Normol=new StringBuilder();
        private static StringBuilder DebugLog_Warnning = new StringBuilder();
        private static StringBuilder DebugLog_Error = new StringBuilder();
        private static StringBuilder DebugLog_Special = new StringBuilder();

        public static  Action<DebugType, string> OnGetDebugMessage;
        
    

        public static void Debug(DebugType dt,string message)
        {
            switch (dt)
            {
                case DebugType.Normol:
                    DebugLog_Normol.AppendLine(message);
                    break;
                case DebugType.Warnning:
                    DebugLog_Warnning.AppendLine(message);
                    break;
                case DebugType.Error:
                    DebugLog_Error.AppendLine(message);
                    break;
                case DebugType.Special:
                    DebugLog_Special.AppendLine(message);
                    break;
                default:
                   break;
            }
            OnGetDebugMessage?.Invoke(dt,message);


        }
    }
}
