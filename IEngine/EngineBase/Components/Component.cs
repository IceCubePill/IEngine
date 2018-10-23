using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IEngine.EngineBase.SceneManager;


/*************************************************************
** MadeBy		：			IceCubePill						**
** Time			:			 2018/10/17 15:38:02							**
** Description	：											**
**************************************************************/
namespace IEngine.EngineBase.Components
{
   public abstract class Component
   {
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
