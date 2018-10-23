using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;


/*************************************************************
** MadeBy		：			IceCubePill						**
** Time			:			 2018/10/20 17:19:00							**
** Description	：											**
**************************************************************/
namespace IEngine.EngineBase
{
    public abstract class SingleType<T> where T : new()
    {
        protected SingleType()
        {

        }
        private static T m_init;

        public static T init
        {
            get
            {
                if (m_init == null)
                {
                    m_init = new T();
                   
                }
                return m_init;

            }
        }
        /// <summary>
        /// 当管理类构造时需要的操作
        /// </summary>
        /// <param name="game"></param>
        public virtual  void OnConstruct(Game1 game)
        {
            
        }
    }
}
