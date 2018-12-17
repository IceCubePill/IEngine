using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IEngine.EngineBase.Components;
using Microsoft.Xna.Framework;

/*************************************************************
** MadeBy		：			IceCubePill						**
** Time			:			 2018/10/17 15:30:30							**
** Description	：											**
**************************************************************/
namespace IEngine.EngineBase
{
    public class GameObject
    {
        private GameObject(){}//隐藏构造方法
        private List<GameObject> m_childrens=new List<GameObject>();
        private readonly Dictionary<string,Component> m_components=new Dictionary<string, Component>();
        public Action<Vector3> IPositionLisenner;
        public Action<float> IRotationLisenner;
        public Action<Vector2> IScaleLisenner;
        public string Name { get; set; } = "gameObject";
        public GameObject parent { get; set; }
        /// <summary>
        /// 物体的位置，按照左上角来计算的
        /// </summary>
        private Vector3 _position = Vector3.Zero;
        private Vector2 _scale= Vector2.One;

        public Vector3 Position
        {
            get { return _position; }
            set
            {
                Vector3 offset = value - _position;
                if (CheackCollider != null)
                    offset = CheackCollider(offset);
                DebugManager.Debug(DebugType.Normol, offset.X+":"+ offset.Y);
                _position = _position+ offset;
                IPositionLisenner?.Invoke(_position);
                foreach (var child in m_childrens)
                {
                    child.Position += offset;
                }
            }
        }
        public Vector2 Scale
        {
            get { return _scale; }
            set
            {
                _scale = value;
              
                IScaleLisenner?.Invoke(_scale);
                foreach (var child in m_childrens)
                {
                    child.Scale = _scale;
                }
            }
        }

        public float _rotate=0;

        public float Rotation
        {
            get { return _rotate; }
            set
            {
                _rotate = value;
                IRotationLisenner(_rotate);
            }
        }
        public Scene scene;
        public Func<Vector3, Vector3> CheackCollider;
        public static  GameObject CreatNewGameObject(Scene s,GameObject parent)
        {
            GameObject obj = new GameObject {scene = s};
            if (parent == null) //添加到场景的根节点
                obj.scene.rootObjects.Add(obj);
            else
                parent.AddGameObject(obj);
            return obj;
        }

        public  GameObject AddGameObject(GameObject go)
        {
            m_childrens.Add(go);
            return go;
        }
        /// <summary>
        /// 添加组件，当添加成功时返回组件,不能同时在一个物体上添加两个相同的组件
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public T AddComponent<T>()where T:Component,new()
        {
            T t = new T {gameObject = this};
            if (m_components.ContainsKey(typeof(T).ToString()))
            {
                DebugManager.Debug(DebugType.Error, "The gameobject :" +Name+" already has the component of : "+t.GetType().ToString());
                return null;
            }
            m_components.Add(typeof(T).ToString(),t);
            scene.OnAwakeAction += t.OnAwake;
            scene.OnUpdateAction += t. OnUpdate;
            return t;
        }

        public T GetComponent<T>() where T : Component
        {
            if (!m_components.ContainsKey(typeof(T).ToString()))
            {
                DebugManager.Debug(DebugType.Error, "There are no Component of :" + typeof(T).ToString());
                return null;
            }
            return m_components[typeof(T).ToString()] as T;
        }

        public void RemoveComponent(Component component)
        {
            
        }

        
    }

   
}
