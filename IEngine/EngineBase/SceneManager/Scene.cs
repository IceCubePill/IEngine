using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


/*************************************************************
** MadeBy		：			IceCubePill						**
** Time			:			 2018/10/17 13:40:50							**
** Description	：											**
**************************************************************/
namespace IEngine.EngineBase
{
    public class Scene
    {
        public readonly List<GameObject> rootObjects = new List<GameObject>();
        public string name;
        public Scene(string name)
        {
            this.name = name;
        }
        public Action OnAwakeAction;
        public Action OnUpdateAction;

        public GameObject AddGameObject(GameObject obj)
        {
            rootObjects.Add(obj);

            return obj;
        }


    }
}
