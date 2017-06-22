using Android.Content.PM;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Input.Touch;
using System;
using project_4_algemeen;
using System.Collections.Generic;

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
        float relativeSize;
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
            screen_width = GraphicsDevice.DisplayMode.Width;
            screen_height = GraphicsDevice.DisplayMode.Height;
            relativeSize = (float)screen_height / 720;
            graphics.PreferredBackBufferWidth = screen_width;
            graphics.PreferredBackBufferHeight = screen_height;
            graphics.ApplyChanges();
            base.Initialize();
        }

        /// <summary>
        /// LoadContent will be called once per game and is the place to load
        /// all of your content.
        /// </summary>

        gameElement Current = new Menu();
        List<androidButtonAdapter> buttonAdapters = new List<androidButtonAdapter>();
        protected override void LoadContent()
        {
            // Create a new SpriteBatch, which can be used to draw textures.
            spriteBatch = new SpriteBatch(GraphicsDevice);

            // Load the font used by the text
            SpriteFont font = Content.Load<SpriteFont>("FONT");

            Current = new Menu(graphics, font, screen_height, screen_width, relativeSize, exit);
            //new Instructies(screen_width, screen_height, font, relativeSize, exit, graphics);
            //new Menu(graphics, font, screen_height, screen_width, relativeSize, exit);

            // create adapters for the buttons of the instructions screen
            foreach (button b in Current.buttons)
            {
                buttonAdapters.Add(new androidButtonAdapter(b));
            }
        }
        // function used to exit the program
        private void exit()
        {
            Exit();
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

            // get all the places where the screen is touched
            var currentTouch = Microsoft.Xna.Framework.Input.Touch.TouchPanel.GetState();
            // update the adapters
            foreach(androidButtonAdapter b in buttonAdapters)
            {
                b.update(currentTouch);
            }

            base.Update(gameTime);
        }

        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            // begin the spriteBatch
            spriteBatch.Begin();
            // draw the instructions screen
            Current.draw(spriteBatch);
            // end the spriteBatch
            spriteBatch.End();
            base.Draw(gameTime);
        }
    }
}
