using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


/*************************************************************
** MadeBy		：			IceCubePill						**
** Time			:			 2018/12/2 18:40:17							**
** Description	：											**
**************************************************************/
namespace IEngine.EngineBase.Components
{
  public  class AudioListener:Component
  {
      public Microsoft.Xna.Framework.Audio.AudioListener listener;
      public override void OnAwake()
      {
          base.OnAwake();
          listener=new Microsoft.Xna.Framework.Audio.AudioListener();
      }
  }
}
