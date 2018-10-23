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
    class DebugManager:SingleType<DebugManager>
    {
        private static StringBuilder sb=new StringBuilder();
       

        public static void Debug(string message)
        {
            sb.AppendLine(message);
        }
    }
}
