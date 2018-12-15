using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IEngine.EngineBase;
using IEngine.EngineBase.Components;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;


/*************************************************************
** MadeBy		：			IceCubePill						**
** Time			:			 2018/12/15 21:16:44							**
** Description	：											**
**************************************************************/
namespace IEngine
{
   public  class TestBehaiour:Component
    {
        public override void OnAwake()
        {
            gameObject.Scale = new Vector2(0.1f, 0.1f);
            base.OnAwake();
        }

        public override void OnUpdate()
        {
            base.OnUpdate();
            //右正，上正
            int offset_x = (InputManager.init.IsKeyDown(Keys.A) ? 1 : 0) - (InputManager.init.IsKeyDown(Keys.D) ? 1 : 0);
            int offset_y = (InputManager.init.IsKeyDown(Keys.W) ? 1 : 0) - (InputManager.init.IsKeyDown(Keys.S) ? 1 : 0);
            DebugManager.Debug(DebugType.Normol,offset_x+"::"+offset_y);
            gameObject.Position = new Vector3(gameObject.Position.X + offset_x, gameObject.Position.Y + offset_y, gameObject.Position.Z);
        }
    }
}
