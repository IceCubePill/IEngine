using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;



/*************************************************************
** MadeBy		：			IceCubePill						**
** Time			:			 2018/10/17 15:38:02							**
** Description	：											**
**************************************************************/
namespace IEngine.EngineBase.Components
{
   public abstract class Component
   {
       protected Component()
       {
           _guid = _guidRoot;
           _guidRoot++;
          
       }
       private static uint _guidRoot = 0;
       public readonly uint _guid;
       private bool m_enable = true;

       public bool Enable
       {
           get
           {
               return m_enable;
           }
           set
           {
              
               gameObject.scene.OnUpdateAction -= OnUpdate;
                if (value==true)
                   gameObject.scene.OnUpdateAction += OnUpdate;
               m_enable = value;
               

           }
       }

       public GameObject gameObject;

       public T AddComponen<T>() where T : Component,new()
       {
          
            return  gameObject.AddComponent<T>();
       }

       public virtual void  OnAwake()
       {
          
       }
    
       public virtual void OnUpdate()
       {

       }

       public virtual void OnRemove()
       {
           gameObject.scene.OnAwakeAction -= OnAwake;
           gameObject.scene.OnUpdateAction -= OnUpdate;
        }
    }
}
