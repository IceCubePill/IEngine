﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IEngine.EngineBase.SceneManager;
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
                rectangle =new Rectangle((int)(gameObject.Position.X ), (int)(gameObject.Position.Y),sprite.Width,sprite.Height);
               
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
            RenderManager.init.AddRender(this);
        }
    }
}
