using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System.Linq;
using System;

using Microsoft.VisualBasic;
using project_4_algemeen;

using System.Collections.Generic;


namespace Project_game4
{
    /// <summary>
    /// This is the main type for your game.
    /// </summary>
    public class Game1 : Game, game
    {
        public GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;
        gameElement Current;
        SpriteFont Font, Big_Font;
        public int screen_width;
		public int screen_height;
        public float relativeSize;
        List<Texture2D> All_images=new List<Texture2D>();
        public Texture2D Level_1_Background;


        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";

            
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
        /// Allows the game to perform any initialization it needs to before starting to run.
        /// This is where it can query for any required services and load any non-graphic
        /// related content.  Calling base.Initialize will enumerate through any components
        /// and initialize them as well.
        /// </summary>
        protected override void Initialize()
        {
            // TODO: Add your initialization logic here
            graphics.IsFullScreen = false;
            graphics.PreferredBackBufferWidth = Convert.ToInt32(GraphicsDevice.DisplayMode.Width * 0.9f);
            graphics.PreferredBackBufferHeight = Convert.ToInt32(GraphicsDevice.DisplayMode.Height * 0.9f);
            relativeSize = 1;
            graphics.ApplyChanges();
            Window.AllowUserResizing = true;
            this.IsMouseVisible = true;
			screen_width = graphics.PreferredBackBufferWidth;
			screen_height = graphics.PreferredBackBufferHeight;

            
            base.Initialize();

            base.Initialize();
        }

       
        protected override void LoadContent()
        {
            // Create a new SpriteBatch, which can be used to draw textures.
            spriteBatch = new SpriteBatch(GraphicsDevice);
            Font = Content.Load<SpriteFont>("FONT");
            Big_Font = Content.Load<SpriteFont>("Big_Font");
            this.All_images.Add(Content.Load<Texture2D>("Level_1_background")); //0
            this.All_images.Add(Content.Load<Texture2D>("enemyneutral2")); //1 
            this.All_images.Add(Content.Load<Texture2D>("enemy4b")); //2
            this.All_images.Add(Content.Load<Texture2D>("enemy3")); //3
            this.All_images.Add(Content.Load<Texture2D>("endboss")); //4
            //All_images.Add(this.Content.Load<Texture2D>("Level_1_background"));


            Current = new project_4_algemeen.Menu(this.screen_width,this.screen_height,this.relativeSize,this.Font,this.graphics,this,this.All_images);
            
           
        }
        public void exit(game game1)
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
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape)) { Exit(); }


           
            current.update(this);


            // TODO: Add your update logic here

            base.Update(gameTime);
        }

        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.DarkOliveGreen);

            spriteBatch.Begin();
           
            current.draw(spriteBatch);
            spriteBatch.End();
            // TODO: Add your drawing code here

            base.Draw(gameTime);
        }
        public void Quit()
        {
            this.Exit();
        }
    }

    
}
