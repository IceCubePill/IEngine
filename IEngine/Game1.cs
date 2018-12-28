using IEngine.EngineBase;
using IEngine.EngineBase.Components;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using IEngine;

/// <summary>
/// This is the main type for your game.
/// </summary>
public class Game1 : Game
{
    private Scene scene;
    private ContentLoader contentLoader;
    public GraphicsDeviceManager graphicManager;
    public Game1()
    {
        //已经分发至各个manager类
        graphicManager = new GraphicsDeviceManager(this);
        Content.RootDirectory = "Content";

    }

    /// <summary>
    /// Allows the game to perform any initialization it needs to before starting to run.
    /// This is where it can query for any required services and load any non-graphic
    /// related content.  Calling base.Initialize will enumerate through any components
    /// and initialize them as well.
    /// </summary>
    protected override void Initialize()
    {
        // TODO: Add your initialization logic here


        DebugManager.init.OnConstruct(this);
        ResoucesManager.init.OnConstruct(this);
        RenderManager.init.OnConstruct(this);
        SceneManager.init.OnConstruct(this);
        InputManager.init.OnConstruct(this);
        TimeManager.init.OnConstruct(this);
        physicManager.init.OnConstruct(this);
        base.Initialize();

    }

    /// <summary>
    /// LoadContent will be called once per game and is the place to load
    /// all of your content.
    /// </summary>
    protected override void LoadContent()
    {
        // Create a new SpriteBatch, which can be used to draw textures.
        // spriteBatch = new SpriteBatch(GraphicsDevice);
        scene = SceneManager.init.currentScene;
        // TODO: use this.Content to load your game content here

        //todo :add gameobject 
        contentLoader =new ContentLoader(scene);
        contentLoader.LoadContent();

        //todo： 遍历执行所以OnAwake方法
        SceneManager.init.currentScene.OnAwakeAction();




    }

    /// <summary>
    /// UnloadContent will be called once per game and is the place to unload
    /// game-specific content.
    /// </summary>
    protected override void UnloadContent()
    {
        // TODO: Unload any non ContentManager content here
    }

    /// <summary>
    /// Allows the game to run logic such as updating the world,
    /// checking for collisions, gathering input, and playing audio.
    /// </summary>
    /// <param name="gameTime">Provides a snapshot of timing values.</param>
    protected override void Update(GameTime gameTime)
    {
        if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
            Exit();

        // TODO: Add your update logic here
         //时间输入管理
        base.Update(gameTime);
        InputManager.init.GetInPutState();
        TimeManager.init.Timer_SecondsCheck();
        //先逻辑
        scene.OnUpdateAction();
        //后物理

    }

    /// <summary>
    /// This is called when the game should draw itself.
    /// </summary>
    /// <param name="gameTime">Provides a snapshot of timing values.</param>
    protected override void Draw(GameTime gameTime)
    {
        //GraphicsDevice.Clear(Color.CornflowerBlue);

        // TODO: Add your drawing code here
        RenderManager.init.Draw();
        base.Draw(gameTime);
    }
}

