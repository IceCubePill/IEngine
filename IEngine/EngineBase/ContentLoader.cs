using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IEngine;
using IEngine.EngineBase;
using IEngine.EngineBase.Components;
using Microsoft.Xna.Framework;


/*************************************************************
** MadeBy		：			IceCubePill						**
** Time			:			 2018/12/29 0:34:34							**
** Description	：											**
**************************************************************/

public class ContentLoader
{
    public ContentLoader(Scene scene)
    {
        gameScene = scene;
    }
    private Scene gameScene;

    public void LoadContent()
    {
       

        GameObject obj = GameObject.CreatNewGameObject(gameScene, null);
        SpriteRender sr = obj.AddComponent<SpriteRender>();
        sr.Sprite = ResoucesManager.init.GetTexture("Assets/020");
        obj.Position=new Vector3(0,0,0);
        obj.Scale = new Vector2(0.3f, 0.3f);
        Animator anima = obj.AddComponent<Animator>();
        anima.SliceImage(4, 4, 5);

        obj.AddComponent<AudioListener>();
        AudioSource _audio = obj.AddComponent<AudioSource>();
        _audio.AudioClip = ResoucesManager.init.GetSoundEffect("Assets/PaddleBounceSound");
        TimerTick tick = obj.AddComponent<TimerTick>();
        tick.TickListen += () => { _audio.Play(); };
        obj.AddComponent<TestBehaiour>();
        BoxCollider box_0 = obj.AddComponent<BoxCollider>();
        box_0.isTrigger = true;


        GameObject obj_collider = GameObject.CreatNewGameObject(gameScene, null);
        obj_collider.Position = new Vector3(100, 100,0);
        obj_collider.Scale = new Vector2(0.3f, 0.3f);
        SpriteRender sr_collider = obj_collider.AddComponent<SpriteRender>();
        sr_collider.Sprite = ResoucesManager.init.GetTexture("Assets/Block");
        BoxCollider box_1 = obj_collider.AddComponent<BoxCollider>();


        GameObject obj_collider_2 = GameObject.CreatNewGameObject(gameScene, null);
        obj_collider_2.Position = new Vector3(500, 500, 0);
        obj_collider_2.Scale = new Vector2(0.3f, 0.3f);
        SpriteRender sr_collider_2 = obj_collider_2.AddComponent<SpriteRender>();
        sr_collider_2.Sprite = ResoucesManager.init.GetTexture("Assets/Block_2");
        BoxCollider box_2 = obj_collider_2.AddComponent<BoxCollider>();
        box_2.Freze_x = true;
        box_2.Freze_y = true;

        GameObject obj_back= GameObject.CreatNewGameObject(gameScene, null);
        obj_back.Position = new Vector3(0,0,-5f);
        obj_back.Scale = new Vector2(2.0f, 1.5f);
        SpriteRender sr_back = obj_back.AddComponent<SpriteRender>();
        sr_back.Sprite = ResoucesManager.init.GetTexture("Assets/Back");
       

    }
}

