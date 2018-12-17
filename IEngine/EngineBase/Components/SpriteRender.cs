using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;


/*************************************************************
** MadeBy		：			IceCubePill						**
** Time			:			 2018/10/22 15:08:24							**
** Description	：											**
**************************************************************/
namespace IEngine.EngineBase.Components
{
   public  class SpriteRender:Component
   {
       
        private Texture2D sprite;

        public Texture2D Sprite
       {
           get { return sprite ?? (sprite = RenderManager.init.GetDefultTexture()); }
           set
           {
               sprite=value;
              
                // rectangle =new Rectangle((int)(gameObject.Position.X ), (int)(gameObject.Position.Y),(int)(sprite.Width * gameObject.Scale.X),(int)(sprite.Height* gameObject.Scale.Y));
               
           }
       }
        public Color color=Color.White;
        /// <summary>
        /// 这个矩形是按照像素来的，所以不要用浮点
        /// </summary>
        public Rectangle rectangle;
        /// <summary>
        ///裁剪矩形
        /// </summary>
        public Rectangle? cutingRectangle=null;
        /// <summary>
        /// filp
        /// </summary>
        public SpriteEffects spriteEffect=SpriteEffects.None;
        public override void OnAwake()
        {
            base.OnAwake();
            //默认赋值
            gameObject.IScaleLisenner += onScaleChange;
            gameObject.IPositionLisenner += onPositionChange;
            RenderManager.init.AddRender(this);
            onScaleChange(gameObject.Scale);
        }

       private void onScaleChange(Vector2 vec)
       {
            rectangle = new Rectangle((int)(gameObject.Position.X), (int)(gameObject.Position.Y), (int)(sprite.Width * vec.X), (int)(sprite.Height * vec.Y));
           //rectangle = new Rectangle(0,0, (int)(sprite.Width * vec.X), (int)(sprite.Height * vec.Y));
        }
       private void onPositionChange(Vector3 vec)
       {
           rectangle = new Rectangle((int)(gameObject.Position.X), (int)(gameObject.Position.Y), (int)(sprite.Width * gameObject.Scale.X), (int)(sprite.Height * gameObject.Scale.Y));
           //rectangle = new Rectangle(0,0, (int)(sprite.Width * vec.X), (int)(sprite.Height * vec.Y));
       }
    }

   
}
