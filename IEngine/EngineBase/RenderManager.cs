using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IEngine.EngineBase.Components;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;


/*************************************************************
** MadeBy		：			IceCubePill						**
** Time			:			 2018/10/22 15:02:23							**
** Description	：											**
**************************************************************/
namespace IEngine.EngineBase
{
    public class RenderManager : SingleType<RenderManager>
    {
        private GraphicsDeviceManager GDM;
        private GraphicsDevice GD;
        private SpriteBatch spriteBatch;
        public override void OnConstruct(Game1 game)
        {
            GDM = game.graphicManager;
            GD = game.GraphicsDevice;
            spriteBatch=new SpriteBatch(game.GraphicsDevice);
            SetScreen(1024, 720);//默认分辨率
        }

        private List<SpriteRender> spriteList = new List<SpriteRender>();

        public void AddRender(SpriteRender sr)
        {
           
            if (spriteList.Count > 0)
            {
                int i = spriteList.Count / 2;//二分遍历
                if (sr.gameObject.Position.Z < spriteList[i].gameObject.Position.Z)//往前遍历
                {
                    while (sr.gameObject.Position.Z < spriteList[i].gameObject.Position.Z)
                    {
                        i--;
                        if (i < 0)
                        {
                            i = 0;
                            break;
                        }
                    }
                }
                else
                {
                    while (sr.gameObject.Position.Z > spriteList[i].gameObject.Position.Z)//往后遍历
                    {
                        i++;
                        if (i >=spriteList.Count)
                        {
                            i = spriteList.Count - 1;
                            break;
                        }
                    }
                }


                spriteList.Insert(i, sr);
            }
            else
            { spriteList.Add(sr); }
        }

        public void SetScreen(int width,int height)
        {
            GDM.PreferredBackBufferWidth = width;
            GDM.PreferredBackBufferHeight = height;
            GDM.ApplyChanges();
        }

        public void Draw()
        {
            GD.Clear(Color.Blue);
            spriteBatch.Begin();
            foreach (var sr in spriteList)
            {
               
               spriteBatch.Draw(sr.Sprite,sr.rectangle,sr.cutingRectangle,sr.color,sr.gameObject.Rotation,sr.gameObject.Position.ToV2(),sr.spriteEffect,sr.gameObject.Position.Z);
            }
            spriteBatch.End();
        }

        public Texture2D GetDefultTexture()
        {
            return new Texture2D(GD,100,100);
        }
    }
}
