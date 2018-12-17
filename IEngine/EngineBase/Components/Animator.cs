using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;


/*************************************************************
** MadeBy		：			IceCubePill						**
** Time			:			 2018/12/17 22:25:58							**
** Description	：											**
**************************************************************/
namespace IEngine.EngineBase.Components
{
   public class Animator:Component
   {
        private SpriteRender sr;
        private int row=1;
        private int line=1;
        private int frame_count=0;
       private int fpi_count = 0;
        public int framesPerImage = 1;
        List<Rectangle> RectList=new List<Rectangle>();
        public override void OnAwake()
        {
            base.OnAwake();
             sr = gameObject.GetComponent<SpriteRender>();
            if (sr==null)//如果没有sr，直接关闭组件
                Enable = false;
            
        }


       public void SliceImage(int _row,int _line,int fpi)
       {
           sr = gameObject.GetComponent<SpriteRender>();
            row = _row;
           line = _line;
           framesPerImage = fpi;
           int Slice_x= sr.Sprite.Width / row;
           int Slice_y = sr.Sprite.Height / line;
           for (int i = 0; i < row; i++)
              for (int j = 0; j < line; j++)
               {
                   RectList.Add(new Rectangle(j* Slice_x,i*Slice_y,Slice_x,Slice_y));
               }
          
        }

       public override void OnUpdate()
       {
           base.OnUpdate();
           if (RectList.Count<0)return;

        
            
           fpi_count++;
           if (fpi_count>=framesPerImage)
           {
               fpi_count = 0;
               frame_count++;
               if (frame_count >= RectList.Count)
                   frame_count = 0;
                sr.cutingRectangle = RectList[frame_count];
            }
         
           
         
             
          

        }
   }
}
