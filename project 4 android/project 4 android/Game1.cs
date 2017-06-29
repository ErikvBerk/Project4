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
    public class Game1 : Game, game
    {
        public GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;
        public int screen_height, screen_width;
        public float relativeSize;
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

        public gameElement Current = new Menu();
        List<androidButtonAdapter> buttonAdapters = new List<androidButtonAdapter>();
        List<androidTextBoxAdapter> textboxAdapters = new List<androidTextBoxAdapter>();
        List<Texture2D> All_images = new List<Texture2D>();
        protected override void LoadContent()
        {
            // Create a new SpriteBatch, which can be used to draw textures.
            spriteBatch = new SpriteBatch(GraphicsDevice);

            // Load the font used by the text
            SpriteFont font = Content.Load<SpriteFont>("FONT");
            SpriteFont Big_Font = Content.Load<SpriteFont>("Big_Font");
            this.All_images.Add(Content.Load<Texture2D>("Level_1_background")); //0
            this.All_images.Add(Content.Load<Texture2D>("enemyneutral2")); //1 
            this.All_images.Add(Content.Load<Texture2D>("enemy4b")); //2
            this.All_images.Add(Content.Load<Texture2D>("enemy3")); //3
            this.All_images.Add(Content.Load<Texture2D>("endboss")); //4
            this.All_images.Add(Content.Load<Texture2D>("P0")); //5
            this.All_images.Add(Content.Load<Texture2D>("bullet")); //6

            Current = new Menu(graphics, font, screen_height, screen_width, relativeSize, (game1) => exit(game1), this, All_images, platform.android);
            //new Instructies(screen_width, screen_height, font, relativeSize, exit, graphics);
            //new Menu(graphics, font, screen_height, screen_width, relativeSize, exit);

            // create adapters for the buttons of the instructions screen
            foreach (button b in Current.buttons)
            {
                buttonAdapters.Add(new androidButtonAdapter(b));
            }
            foreach(textbox t in Current.textboxes)
            {
                textboxAdapters.Add(new androidTextBoxAdapter(t));
            }
        }
        // function used to exit the program
        private void exit(game game1)
        {
            Exit();
        }


        public gameElement current
        {
            get
            {
                return Current;
            }
            set
            {
                Current = value;
            }
        }

        /// <summary>
        /// UnloadContent will be called once per game and is the place to unload
        /// game-specific content.
        /// </summary>
        protected override void UnloadContent()
        {
            // TODO: Unload any non ContentManager content here
        }
        gameElement LastKnown;
        /// <summary>
        /// Allows the game to run logic such as updating the world,
        /// checking for collisions, gathering input, and playing audio.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed)
                Exit();
            Type type = null;
            try
            {
                type = Current.GetType();
            }
            catch
            {
                Current = LastKnown;
                type = Current.GetType();
            }
            // get all the places where the screen is touched
            var currentTouch = Microsoft.Xna.Framework.Input.Touch.TouchPanel.GetState();
            // update the adapters
            foreach(androidButtonAdapter b in buttonAdapters)
            {
                b.update(currentTouch, this);
            }
            foreach (androidTextBoxAdapter t in textboxAdapters)
            {
                try
                {
                    t.update(currentTouch);
                }
                catch { }
            }
            Type newtype = null;
            try
            {
                newtype = Current.GetType();
            }
            catch
            {
                newtype = type;
            }
            if (newtype != type)
            {
                resetButtons();
            }
            if (Current != null)
                LastKnown = Current;
            base.Update(gameTime);
        }
        Switch_level sl = new Switch_level();
        public void resetButtons()
        {
            buttonAdapters.Clear();
            if (Current.GetType() == sl.GetType())
            {
                foreach(button b in Current.buttons)
                {
                    buttonAdapters.Add(new moveButton(b));
                }
            }
            else
            {
                foreach (button b in Current.buttons)
                {
                    buttonAdapters.Add(new androidButtonAdapter(b));
                }
            }
            textboxAdapters.Clear();
            foreach (textbox t in Current.textboxes)
            {
                textboxAdapters.Add(new androidTextBoxAdapter(t));
            }
        }

        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.DarkOliveGreen);

            // begin the spriteBatch
            spriteBatch.Begin();
            // draw the current screen
            try
            {
                Current.draw(spriteBatch);
            }
            catch
            {

            }
            // end the spriteBatch
            spriteBatch.End();
            base.Draw(gameTime);
        }
    }
}
