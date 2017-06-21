using Android.Content.PM;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Input.Touch;
using System;

namespace project_4_android
{
    /// <summary>
    /// This is the main type for your game.
    /// </summary>
    public class Game1 : Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;
        int screen_height, screen_width;
        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";

            graphics.IsFullScreen = true;
            graphics.SupportedOrientations = DisplayOrientation.LandscapeLeft | DisplayOrientation.LandscapeRight;
            graphics.ApplyChanges();
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

            screen_width = GraphicsDevice.DisplayMode.Width;
            screen_height = GraphicsDevice.DisplayMode.Height;
            graphics.PreferredBackBufferWidth = screen_width;
            graphics.PreferredBackBufferHeight = screen_height;
            graphics.ApplyChanges();
            base.Initialize();
        }

        /// <summary>
        /// LoadContent will be called once per game and is the place to load
        /// all of your content.
        /// </summary>
        button test1, test2, test3, test4;
        androidButtonAdapter adapterTest1, adapterTest2, adapterTest3, adapterTest4;
        protected override void LoadContent()
        {
            // Create a new SpriteBatch, which can be used to draw textures.
            spriteBatch = new SpriteBatch(GraphicsDevice);

            // TODO: use this.Content to load your game content here
            Texture2D rect = new Texture2D(graphics.GraphicsDevice, (int)(screen_width / 2), (int)(screen_height / 2));
            Color[] data = new Color[(int)(screen_width / 2) * (int)(screen_height / 2)];
            for (int i = 0; i < data.Length; ++i) data[i] = Color.White;
            rect.SetData(data);
            test1 = new button(0, 0, (int)(screen_width / 2), (int)(screen_height / 2), rect);
            test2 = new button((int)(screen_width / 2), (int)(screen_height / 2), (int)(screen_width / 2), (int)(screen_height / 2), rect);
            test3 = new button(0, (int)(screen_height / 2), (int)(screen_width / 2), (int)(screen_height / 2), rect);
            test4 = new button((int)(screen_width / 2), 0, (int)(screen_width / 2), (int)(screen_height / 2), rect);
            test3.visible = false;
            test4.visible = false;
            adapterTest1 = new androidButtonAdapter(test1);
            adapterTest2 = new androidButtonAdapter(test2);
            adapterTest3 = new androidButtonAdapter(test3);
            adapterTest4 = new androidButtonAdapter(test4);
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
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed)
                Exit();

            // TODO: Add your update logic here

            var currentTouch = Microsoft.Xna.Framework.Input.Touch.TouchPanel.GetState();
            adapterTest1.update(currentTouch);
            adapterTest2.update(currentTouch);
            adapterTest3.update(currentTouch);
            adapterTest4.update(currentTouch);
            base.Update(gameTime);
        }

        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            // TODO: Add your drawing code here
            spriteBatch.Begin();
            adapterTest1.draw(spriteBatch);
            adapterTest2.draw(spriteBatch);
            adapterTest3.draw(spriteBatch);
            adapterTest4.draw(spriteBatch);
            spriteBatch.End();
            base.Draw(gameTime);
        }
    }
}
