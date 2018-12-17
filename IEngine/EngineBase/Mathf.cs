using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;


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
        public static bool IsInBox(int x,int y,Rectangle rect)
        {
            return (IsInRange(rect.X, rect.X + rect.Width, x) && (IsInRange(rect.Y, rect.Y + rect.Height, y)));
        }
        public static bool IsCross(Rectangle checkRect, Rectangle targetRect)
        {
            bool hasCollision = false;
            if (IsInBox(checkRect.X, checkRect.Y, targetRect))
                 hasCollision = true;
            else if (IsInBox(checkRect.X+checkRect.Width, checkRect.Y, targetRect))
                hasCollision = true;
            else if (IsInBox(checkRect.X , checkRect.Y+checkRect.Height, targetRect))
                hasCollision = true;
            else if (IsInBox(checkRect.X + checkRect.Width, checkRect.Y + checkRect.Height, targetRect))
                hasCollision = true;
            return hasCollision;

        }
    }
   
}
