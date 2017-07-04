using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Audio;
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
        public project_4_algemeen.Menu menu = new project_4_algemeen.Menu();
        SpriteFont Font, Big_Font;
        public  string screen_name="Menu";
        int id;
        gameElement Current = new project_4_algemeen.Menu();
        List<project_4_algemeen.button> list_buttons_menu = new List<project_4_algemeen.button>();
        List<Texture2D> All_images = new List<Texture2D>();
        public List<SoundEffect> soundeffects;
        Sound sound;
        

        public double screen_width;
		public double screen_height;
        
        

        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            soundeffects = new List<SoundEffect>();
            Content.RootDirectory = "Content";           
           
            
        }
        public float relativeSize;

        public void resetButtons() { }
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
            graphics.IsFullScreen = true;
            graphics.PreferredBackBufferWidth = GraphicsDevice.DisplayMode.Width;
            graphics.PreferredBackBufferHeight = GraphicsDevice.DisplayMode.Height;
            relativeSize = 1;
            graphics.ApplyChanges();
            Window.AllowUserResizing = true;
            this.IsMouseVisible = true;
			screen_width = graphics.PreferredBackBufferWidth;
			screen_height = graphics.PreferredBackBufferHeight;
            base.Initialize();

            base.Initialize();
        }

        /// <summary>
        /// LoadContent will be called once per game and is the place to load
        /// all of your content.
        /// </summary>
        protected override void LoadContent()
        {
            // Create a new SpriteBatch, which can be used to draw textures.
            spriteBatch = new SpriteBatch(GraphicsDevice);
            Font = Content.Load<SpriteFont>("FONT");
            SpriteFont Big_Font = Content.Load<SpriteFont>("Big_Font");
            this.All_images.Add(Content.Load<Texture2D>("Level_1_background")); //0
            this.All_images.Add(Content.Load<Texture2D>("enemyneutral2")); //1 
            this.All_images.Add(Content.Load<Texture2D>("enemy4b")); //2
            this.All_images.Add(Content.Load<Texture2D>("enemy3")); //3
            this.All_images.Add(Content.Load<Texture2D>("endboss")); //4
            this.All_images.Add(Content.Load<Texture2D>("P0")); //5	    
            this.All_images.Add(Content.Load<Texture2D>("bullet")); //6
            this.All_images.Add(Content.Load<Texture2D>("instructie1")); //7
            this.All_images.Add(Content.Load<Texture2D>("instructie2")); //8
            this.All_images.Add(Content.Load<Texture2D>("fullife")); //9
            this.All_images.Add(Content.Load<Texture2D>("halflife")); //10
            this.All_images.Add(Content.Load<Texture2D>("nolife")); //11

            soundeffects.Add(Content.Load<SoundEffect>("GunSound")); //0
            soundeffects.Add(Content.Load<SoundEffect>("ZombieDeadSound")); //1
            soundeffects.Add(Content.Load<SoundEffect>("PlayerDeadSound")); //2
            soundeffects.Add(Content.Load<SoundEffect>("UnicornSound")); //3
            soundeffects.Add(Content.Load<SoundEffect>("ZombieUnicornDeadSound")); //4
            soundeffects.Add(Content.Load<SoundEffect>("VictorySound")); //5
            soundeffects.Add(Content.Load<SoundEffect>("GameOverSound")); //6
            soundeffects.Add(Content.Load<SoundEffect>("background_music")); //7
            sound = new Sound(soundeffects);


            // TODO: use this.Content to load your game content here
            //rect = new Texture2D(graphics.GraphicsDevice, this.ButtonWith, this.ButtonHeight);
            //Color[] data = new Color[this.ButtonWith * this.ButtonHeight];
            //for (int i = 0; i < data.Length; ++i) data[i] = Color.White;
            //rect.SetData(data);


            //initiate all different classes here , including the ones given to the buttons in other classes
            Current = new project_4_algemeen.Menu(graphics, Font, screen_height, screen_width, relativeSize, exit, this, All_images, sound);
            //menu = new project_4_algemeen.Menu(graphics, Font,screen_width,screen_height,relativeSize, (game1) => exit(game1), list_buttons_menu);
            //list_buttons_menu.Add(new project_4_algemeen.button((int)(screen_width * 0.8), (int)(this.screen_height * 0.18), (int)(screen_width * 0.4), (int)(screen_width * 0.1), "Play!", Font, relativeSize, Color.Khaki, Color.OliveDrab, new Test_Play("Test_Play",Font,400,400, graphics), graphics));
            //new Instructies(screen_width, screen_height, font, relativeSize, exit, graphics);
            //new Menu(graphics, font, screen_height, screen_width, relativeSize, exit);
        }
        private void exit(game game1)
        {
            Exit();
        }
        public void change_Screen()
        {

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
        bool f11pressed;
        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();
            if (Keyboard.GetState().IsKeyDown(Keys.F11))
            {
                f11pressed = true;
            }
            if (Keyboard.GetState().IsKeyUp(Keys.F11))
            {
                if (f11pressed)
                {
                    if (graphics.IsFullScreen)
                    {
                        graphics.IsFullScreen = false;
                        graphics.PreferredBackBufferWidth = (int)(GraphicsDevice.DisplayMode.Width * 0.9f);
                        graphics.PreferredBackBufferHeight = (int)(GraphicsDevice.DisplayMode.Height * 0.9f);
                    }
                    else
                    {
                        graphics.IsFullScreen = true;
                        graphics.PreferredBackBufferWidth = GraphicsDevice.DisplayMode.Width;
                        graphics.PreferredBackBufferHeight = GraphicsDevice.DisplayMode.Height;
                    }
                    graphics.ApplyChanges();
                    f11pressed = false;
                }
            }
            Current.update(this);
            
            
            

            //if (menu.list_buttons_menu[0].clicked == true) { screen_name = menu.list_buttons_menu[0].Class_call.get_name(); }

            //menu.list_buttons_menu[id].update();



            Console.WriteLine(id);
            
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
            
            //if (screen_name == "Menu")  //checks what the "screen_name"  is to determine which draw function to call
            //{
            //    foreach (button BUT in menu.list_buttons_menu) { BUT.draw(spriteBatch); }

            //}
            //else if (screen_name == "Test_Play") { list_buttons_menu[0].Class_call.draw(spriteBatch); }
            Current.draw(spriteBatch);
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
