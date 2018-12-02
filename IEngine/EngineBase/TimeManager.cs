using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


/*************************************************************
** MadeBy		：			IceCubePill						**
** Time			:			 2018/11/1 16:01:12							**
** Description	：											**
**************************************************************/
namespace IEngine.EngineBase
{
    public class TimeManager : SingleType<TimeManager>
    {
        private DateTime m_GameStartTime;
        private DateTime m_LastFrameTime;
        private float m_fps = 0;
        /// <summary>
        ///帧
        /// </summary>
        private float m_frame = 0;
        public float FPS => m_fps;
        //每秒钟事件触发分发
        internal  Action TickListener;
        internal override void OnConstruct(Game1 game)
        {
            base.OnConstruct(game);
            m_GameStartTime = DateTime.Now;
            m_LastFrameTime = DateTime.Now;
        }

       
       
        private void CountFPS()
        {
            m_fps = m_frame;
            m_frame = 0;
        }
        // todo 也许不是真正的fps，因为update 和draw我无法控制1:1
        /// <summary>
        /// 引擎内部使用，不建议自己修改使用
        /// </summary>
        internal void Timer_SecondsCheck()
        {
            if ((DateTime.Now - m_LastFrameTime).Seconds>1.0f)
            {
                TickListener?.Invoke();
                CountFPS();
                m_LastFrameTime = DateTime.Now;
            }
            m_frame++;

        }

        public TimeSpan GetGameRunTime()
        {
            return DateTime.Now - m_GameStartTime;

        }


    }
}
