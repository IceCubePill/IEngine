using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;


/*************************************************************
** MadeBy		：			IceCubePill						**
** Time			:			 2018/10/22 22:49:00							**
** Description	：											**
**************************************************************/
namespace IEngine.EngineBase
{
  public static  class ExtensionFun
    {
        public static Vector2 ToV2(this Vector3 v3)
        {
            return new Vector2(v3.X,v3.Y);
        }

        public static Vector3 ToV3(this Vector2 v2)
        {
            return new Vector3(v2.X,v2.Y,0);
        }
    }
}
