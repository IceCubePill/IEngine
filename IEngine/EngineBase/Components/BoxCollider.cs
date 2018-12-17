using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;


/*************************************************************
** MadeBy		：			IceCubePill						**
** Time			:			 2018/12/17 0:17:15							**
** Description	：											**
**************************************************************/
namespace IEngine.EngineBase.Components
{
    public class BoxCollider : Component
    {
        internal Rectangle box;
        private Vector2 _boxScale;
        public Vector2 BoxScale
        {
            get { return _boxScale; }
            set
            {
                _boxScale = value;
                box= new Rectangle(0, 0, (int)(2 * _boxScale.X), (int)(2 * _boxScale.Y));
            }
        }
        /// <summary>
        /// 是不是主动触发器
        /// </summary>
        public bool isTrigger = false;
        //冻结某个方向的碰撞移动
        public bool Freze_x = false;
        public bool Freze_y = false;
        public override void OnAwake()
        {
            base.OnAwake();
            var sr = this.gameObject.GetComponent<SpriteRender>();
            _boxScale = sr!=null ? new Vector2(sr.rectangle.Width,sr.rectangle.Height) : new Vector2(100, 100); //默认100*100像素的大小
            box =  new Rectangle((int)gameObject.Position.X, (int)gameObject.Position.Y, (int)( BoxScale.X), (int)(BoxScale.Y));
            physicManager.init.AddCollision(_guid,this);
            if (isTrigger)
                gameObject.CheackCollider += CheackCollider;

        }

        public override void OnRemove()
        {
            base.OnRemove();
            physicManager.init.RemoveCollsion(_guid);
            gameObject.CheackCollider -= CheackCollider;
        }

        public Vector3 CheackCollider(Vector3 offset)
        {
           physicManager.init.CheakCollider(this,ref offset);
            return offset;
        }
        /// <summary>
        /// 更新物理
        /// </summary>
        public override void OnUpdate()
        {
            base.OnUpdate();
            box = new Rectangle((int)gameObject.Position.X, (int)gameObject.Position.Y, (int)(BoxScale.X), (int)(BoxScale.Y));

        }
    }

   
}
