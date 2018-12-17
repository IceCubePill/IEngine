using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


/*************************************************************
** MadeBy		：			IceCubePill						**
** Time			:			 2018/12/17 10:14:42							**
** Description	：											**
**************************************************************/
namespace IEngine.EngineBase
{
   public static class Mathf
    {
        public static bool IsInRange(int min,int max,int value)
        {
            if (value < min || value > max)
                return false;
            else
                return true;
        }
    }
}
