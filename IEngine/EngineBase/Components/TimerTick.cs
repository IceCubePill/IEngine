using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


/*************************************************************
** MadeBy		：			IceCubePill						**
** Time			:			 2018/12/2 13:31:26							**
** Description	：											**
**************************************************************/
namespace IEngine.EngineBase.Components
{
    public class TimerTick : Component
    {
        private int m_currentCounter=0;
        private int _tickTime=1;
        public bool isLoop = true;
        public Action TickListen;

        /// <summary>
        /// 每隔几秒触发一次,赋值会重置当前计时，所以建议不要动态调整
        /// </summary>
        public int TickTime
        {
            get { return _tickTime; }
            set
            {
                _tickTime = value;
                m_currentCounter = 0;


            }
        }

        /// <summary>
        /// 向全局时间委托注册事件
        /// </summary>
        private void CheckTickCount()
        {
            m_currentCounter++;
            if (m_currentCounter > _tickTime)
            {
                TickListen?.Invoke();
                m_currentCounter = 0;
            }
            if (!isLoop)
            {
                TimeManager.init.TickListener -= CheckTickCount;
            }
            
        }

        public override void OnAwake()
        {
            base.OnAwake();
         
            TimeManager.init.TickListener += CheckTickCount;
        }

        public override void OnRemove()
        {
            base.OnRemove();
            TimeManager.init.TickListener -= CheckTickCount;
        }
    }
}
