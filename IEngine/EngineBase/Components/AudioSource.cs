using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework.Audio;


/*************************************************************
** MadeBy		：			IceCubePill						**
** Time			:			 2018/12/2 15:50:40							**
** Description	：											**
**************************************************************/
namespace IEngine.EngineBase.Components
{
   public class AudioSource:Component
   {
       private SoundEffect _audioClip;
        /// <summary>
        /// 音量（0,1）
        /// </summary>
        public int volume=1;
        /// <summary>
        /// 音调（-1,1）
        /// </summary>
        public int pitch=0;
        /// <summary>
        /// 声道，（-1,1）-1左声道，1右声道
        /// </summary>
        public int pan=0;
        public SoundEffect AudioClip
        {
         get { return _audioClip; }
         set
         {
             _audioClip = value;
            
         }
     }

       public void Play()
       {
           if (_audioClip==null)
           {
               DebugManager.Debug(DebugType.Error,"The audioClip is null");
                return;
           }
           else
           {
               _audioClip.Play(volume,pitch,pan);
           }
       }
    }
}
