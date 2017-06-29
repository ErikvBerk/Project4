using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System.Linq;
using System;

using Microsoft.VisualBasic;
using project_4_algemeen;

using System.Collections.Generic;



namespace project_4_algemeen
{
    /// <summary>
    /// This is the main type for your game.
    /// </summary>
    public class Player : gameElement
    {
        List<Texture2D> All_images;
        public List<projectile> projectiles=new List<projectile>();
        public Location[] position;
        Keys[] activeKeys;
        public Location direction;
        Random random;
        public int X, Y;
        public int lenght;
        public int texdirection;
        public int mouseX, mouseY;
        int size_x, size_y;
        KeyboardState keyboard;
        game game1;
        double screen_width, screen_height;
        public List<button> buttons = new List<button>();
        int damage = 50;


        public Player(List<Texture2D> All_images, game game1, double screen_width, double screen_height)
        {
            this.All_images = All_images;
            this.lenght = 1;
            this.position = new Location[lenght];
            this.position[0] = new Location(0, 0);
            this.direction = new Location(1, 0);
            this.random = new Random();
            this.texdirection = 1;
            this.game1 = game1;
            this.screen_width = screen_width;
            this.screen_height = screen_height;
            this.damage = damage;

        }
        public virtual void update(game game1)
        {
            for (int i = lenght - 1; i > 0; i--)
            {
                if (i == 0)
                    position[i] = position[i] + direction;
                else
                    position[i] = position[i - 1];
            }

            foreach (projectile p in projectiles)
            {
                p.update(game1);
            }

            keyboard = Keyboard.GetState();
            activeKeys = keyboard.GetPressedKeys();

            Move(activeKeys);
            Shoot();



            //if (texdirection == 1)
            //    this.playertex = playertex;
            //            if (texdirection == 2)
            //                this.playertex = playertex2;
            //            if (texdirection == 3)
            //                this.playertex = playertex3;
            //            if (texdirection == 4)
            //                this.playertex = playertex4;

            position[0] = position[0] + direction;
            direction = new Location(0, 0);

        }
        public virtual void draw(SpriteBatch spritebatch)
        {
            size_x = (int)this.screen_width / 12;
            size_y = (int)this.screen_height / 10;
            Rectangle destinationRectangle = new Rectangle(this.X, this.Y, size_x, size_y);
            //spritebatch.Draw(All_images[0], destinationRectangle, Color.White);
            // for (int i = 0; i < lenght; i++)
            spritebatch.Draw(All_images[5], destinationRectangle, Color.White);
            foreach(projectile p in projectiles)
            {
                p.draw(spritebatch);
            }

        }
        public virtual void Shoot()
        {
            MouseState mouse = Mouse.GetState();
            if(mouse.LeftButton== ButtonState.Pressed)
            {
                mouseX = mouse.X;
                mouseY = mouse.Y;

                projectiles.Add(new projectile(this.damage,this.X+ (int)(size_x/2), this.Y+(int)(size_y / 2), this.mouseX, this.mouseY, this.screen_width, this.screen_height, this.All_images,this));

            }
        }
        public int GetPositionX()
        {
            return this.X;
        }
        public int GetPositionY()
        {
            return this.Y;
        }

        public virtual void Move(Keys[] keys)
        {

            //if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape)) { Exit(); }

            if (this.X > (int)this.screen_width - size_x) { this.X = (int)this.screen_width - size_x; }
            if (this.Y > (int)this.screen_height - size_y) { this.Y = (int)this.screen_height - size_y; }
            if (this.X < 1) { this.X = 1; }
            if (this.Y < 1) { this.Y = 1; }
            foreach (Keys k in keys)
            {
                if (k == Keys.Right || k == Keys.D)
                {

                    this.X += 10;
                    this.texdirection = 1;

                }
                if (k == Keys.Down || k == Keys.S)
                {
                    this.Y += 10;
                    this.texdirection = 2;
                }
                if (k == Keys.Left || k == Keys.A)
                {

                    this.X -= 10;
                    this.texdirection = 3;
                }
                if (k == Keys.Up || k == Keys.W)
                {
                    this.Y -= 10;
                    this.texdirection = 4;
                }

            }
            //if (cnt == 0)
            //{
            //    this.update();
            //    cnt = 1;
            //}
            //else
            //    cnt--;
        }
        public Keys[] ActiveKeys
        {
            get
            {
                return activeKeys;
            }
            set
            {
                activeKeys = value;
            }
        }

        List<button> gameElement.buttons
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        public List<textbox> textboxes
        {
            get
            {
                throw new NotImplementedException();
            }
        }
    }
    public class AndroidPlayer : Player
    {
        Keys[] keys = new Keys[2];
        public AndroidPlayer(List<Texture2D> All_images, game game, double screen_width, double screen_height, SpriteFont font, GraphicsDeviceManager graphics) : base(All_images, game, screen_width, screen_height)
        {

        }
        public override void update(game game1)
        {
            for (int i = lenght - 1; i > 0; i--)
            {
                if (i == 0)
                    position[i] = position[i] + direction;
                else
                    position[i] = position[i - 1];
            }

            position[0] = position[0] + direction;
            direction = new Location(0, 0);
        }
        public override void Move(Keys[] keys)
        {
            base.Move(keys);
        }
        public override void draw(SpriteBatch spritebatch)
        {
            base.draw(spritebatch);
        }
    }
    public class Location
    {
        public int X, Y;
        public Location(int x, int y)
        {
            this.X = x;
            this.Y = y;
        }
        public static Location operator +(Location l1, Location l2)
        {
            int x = l1.X + l2.X;
            int y = l1.Y + l2.Y;
            return new Location(x, y);
        }
    }
}
