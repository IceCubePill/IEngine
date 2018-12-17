using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;


/*************************************************************
** MadeBy		：			IceCubePill						**
** Time			:			 2018/10/17 13:37:40							**
** Description	：					场景管理器						**
**************************************************************/
namespace IEngine.EngineBase
{
    public class SceneManager:SingleType<SceneManager>
    {
        private const string DEFULT_SCENE = "DefultScene";
        public Scene currentScene;
        private Dictionary<string, Scene> sceneDic = new Dictionary<string, Scene>();

        internal override void OnConstruct(Game1 game)
        {
          
            currentScene=new Scene(DEFULT_SCENE);
            sceneDic.Add(DEFULT_SCENE,currentScene);
        }
    }
}
