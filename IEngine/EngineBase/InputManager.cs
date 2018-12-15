using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework.Input;


/*************************************************************
** MadeBy		：			IceCubePill						**
** Time			:			 2018/10/31 13:39:44							**
** Description	：											**
**************************************************************/
namespace IEngine.EngineBase
{
    public class InputManager : SingleType<InputManager>
    {
        private KeyboardState m_current_kbs;
        private MouseState m_current_ms; 
        private Dictionary<Keys, List<KeyHandle>> KeyHandleListener = new Dictionary<Keys, List<KeyHandle>>();


        public bool IsKeyDown(Keys key)
        {
            return m_current_kbs.IsKeyDown(key);
        }

        /// <summary>
        /// 引擎内部使用，不建议自己修改使用
        /// </summary>
        internal void GetInPutState()
        {
            m_current_kbs = Keyboard.GetState();
            m_current_ms = Mouse.GetState();
        }
        internal override void OnConstruct(Game1 game)
        {
            base.OnConstruct(game);
        }

        public void AddInputKey(Keys key, KeyHandle handle)
        {
            if (KeyHandleListener.ContainsKey(key))
                KeyHandleListener[key].Add(handle);
            else
                KeyHandleListener.Add(key, new List<KeyHandle>() { handle });
        }

    }

    public class KeyHandle
    {
        public enum KeyState
        {
            Down,
            Press,
            Up
        }
        public readonly Keys key;
        public readonly KeyState state;

        internal virtual void HanleEvent(KeyState keyState)
        {
            if (keyState == state)
            {
                KeyEvent?.Invoke();
            }
        }

        public Action KeyEvent;

        public KeyHandle(Keys k, KeyState ks, Action fun)
        {
            key = k;
            state = ks;
            KeyEvent = fun;
        }
    }
}
