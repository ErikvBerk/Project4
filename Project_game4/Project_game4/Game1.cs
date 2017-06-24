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
    public class Game1 : Game
    {
        public GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;
        public Menu menu = new Project_game4.Menu();
        SpriteFont Font, Big_Font;
        public  string screen_name="Menu";
        int id=0;
        List<button> list_buttons_menu = new List<button>();
        List<button> list_highscore_buttons = new List<button>();
        

        public double screen_width;
		public double screen_height;
        
        

        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";           
           
            
        }
        public float relativeSize;
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

        /// <summary>
        /// LoadContent will be called once per game and is the place to load
        /// all of your content.
        /// </summary>
        protected override void LoadContent()
        {
            // Create a new SpriteBatch, which can be used to draw textures.
            spriteBatch = new SpriteBatch(GraphicsDevice);
            Font = Content.Load<SpriteFont>("FONT");
            Big_Font = Content.Load<SpriteFont>("Big_Font");


            // TODO: use this.Content to load your game content here
            //rect = new Texture2D(graphics.GraphicsDevice, this.ButtonWith, this.ButtonHeight);
            //Color[] data = new Color[this.ButtonWith * this.ButtonHeight];
            //for (int i = 0; i < data.Length; ++i) data[i] = Color.White;
            //rect.SetData(data);


            //initiate all different classes here , including the ones given to the buttons in other classes
            list_highscore_buttons.Add(new button((int)(screen_width * 0.37), (int)(this.screen_height * 0.35), (int)(screen_width * 0.4), (int)(screen_height * 0.1),"Back", Font, relativeSize, Color.Maroon, Color.Red, new Back("Menu"), graphics));


            menu = new Menu(graphics, Font,screen_width,screen_height,relativeSize, list_buttons_menu);
            list_buttons_menu.Add(new button((int)(screen_width * 0.37), (int)(this.screen_height * 0.35), (int)(screen_width * 0.4), (int)(screen_height * 0.1), "Play!", Font, relativeSize, Color.Khaki, Color.OliveDrab, new Play("Play", Font, Big_Font, 400, 400, graphics), graphics));
            list_buttons_menu.Add(new button((int)(screen_width * 0.37), (int)(this.screen_height * 0.48), (int)(screen_width * 0.4), (int)(screen_height * 0.1), "Highscore!", Font, relativeSize, Color.Khaki, Color.OliveDrab, new Highscores("Highscore", Font, 400, 400, graphics, list_highscore_buttons), graphics));
            list_buttons_menu.Add(new button((int)(screen_width * 0.37), (int)(this.screen_height * 0.61), (int)(screen_width * 0.4), (int)(screen_height * 0.1), "Instructions!", Font, relativeSize, Color.Khaki, Color.OliveDrab, new Instructions("Instructions", Font, 400, 400, graphics), graphics));
            list_buttons_menu.Add(new button((int)(screen_width * 0.37), (int)(this.screen_height * 0.74), (int)(screen_width * 0.4), (int)(screen_height * 0.1), "Exit!", Font, relativeSize, Color.Maroon, Color.Red, new Test_Exit(Exit, "Exit", Font, 400, 400, graphics), graphics));

             //new Instructies(screen_width, screen_height, font, relativeSize, exit, graphics);
            //new Menu(graphics, font, screen_height, screen_width, relativeSize, exit);
        }
        public void exit()
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
        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
            
                Exit();
            menu.update();



            //All menu buttons
            //if (menu.Clicked == true) { screen_name = menu.name; } 
            if      (menu.list_buttons_menu[0].clicked == true) { screen_name = menu.list_buttons_menu[0].Class_call.get_name(); } // Play

            else if (menu.list_buttons_menu[1].clicked == true) // Highscores
            {
                Console.WriteLine(screen_name);
                screen_name = menu.list_buttons_menu[1].Class_call.get_name(); 
                if (list_highscore_buttons[0].clicked == true)
                {
                    
                    screen_name = list_highscore_buttons[0].Class_call.get_name();
                    Console.WriteLine(screen_name);
                }
            } 
            else if (menu.list_buttons_menu[2].clicked == true) { screen_name = menu.list_buttons_menu[2].Class_call.get_name(); } // Instructions
            else if (menu.list_buttons_menu[3].clicked == true) { screen_name = menu.list_buttons_menu[3].Class_call.get_name(); } // Exit



            



           
            
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

            if (screen_name == "Menu")  //checks what the "screen_name"  is to determine which draw function to call
            {
                menu.draw(spriteBatch);
                

            }
            else if (screen_name == "Play") { list_buttons_menu[0].Class_call.draw(spriteBatch); } //draws everything of play
            else if (screen_name == "Highscore") { list_buttons_menu[1].Class_call.draw(spriteBatch); } //draws everything of highscore
            else if (screen_name == "Instructions") { list_buttons_menu[2].Class_call.draw(spriteBatch); } // draws everything of instructions
            else if (screen_name == "Exit") { list_buttons_menu[3].Class_call.action(); }  // if we make an exit screen , call .action() somewhere else.

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
