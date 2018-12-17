using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IEngine.EngineBase.Components;
using Microsoft.Xna.Framework;


/*************************************************************
** MadeBy		：			IceCubePill						**
** Time			:			 2018/12/16 23:52:23							**
** Description	：											**
**************************************************************/
namespace IEngine.EngineBase
{
    public class physicManager : SingleType<physicManager>
    {
        internal override void OnConstruct(Game1 game)
        {
            base.OnConstruct(game);
        }

        private Dictionary<uint, BoxCollider> _collisionerDic = new Dictionary<uint, BoxCollider>();
        private List<BoxCollider> _listCollsionableList = new List<BoxCollider>();

        public void AddCollision(uint id, BoxCollider collider)
        {
            _collisionerDic.Add(id, collider);
            _listCollsionableList.Add(collider);
        }

        public void RemoveCollsion(uint id)
        {
            _listCollsionableList.Remove(_collisionerDic[id]);
            _collisionerDic.Remove(id);

        }

        List<BoxCollider> CollsionBox = new List<BoxCollider>();//缓存需要被移动的单位
        public void CheakCollider(BoxCollider collder, ref Vector3 offset)
        {
            CollsionBox.Clear();
            foreach (var boxCollider in _listCollsionableList)
            {
                if (boxCollider._guid == collder._guid) continue;
                int offset_x, offset_y;
                if (offset.X > 0)
                    offset_x = collder.box.X + collder.box.Width;
                else
                    offset_x = collder.box.X;
                if (offset.Y > 0)
                    offset_y = collder.box.Y + collder.box.Height;
                else
                    offset_y = collder.box.Y;

                if (Mathf.IsInRange(boxCollider.box.X, boxCollider.box.X + boxCollider.box.Width, offset_x+(int)offset.X)
                    && (Mathf.IsInRange(boxCollider.box.Y, boxCollider.box.Y + boxCollider.box.Height, offset_y)))

                    if (boxCollider.Freze_x)
                        offset = new Vector3(0, offset.Y, offset.Z);
                    else if (!CollsionBox.Contains(boxCollider))
                        CollsionBox.Add(boxCollider);

                if (Mathf.IsInRange(boxCollider.box.Y, boxCollider.box.Y + boxCollider.box.Height, offset_y+(int)offset.Y)
                    && (Mathf.IsInRange(boxCollider.box.X, boxCollider.box.X + boxCollider.box.Width, offset_x)))
                    if (boxCollider.Freze_y)
                        offset = new Vector3(offset.X, 0, offset.Z);
                    else if (!CollsionBox.Contains(boxCollider))
                        CollsionBox.Add(boxCollider);


            }
            if (offset != Vector3.Zero&& CollsionBox.Count>0)//遍历偏移
                foreach (BoxCollider t in CollsionBox)
                    t.gameObject.Position += offset;


        }

    }

}
