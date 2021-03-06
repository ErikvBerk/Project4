﻿using Microsoft.Xna.Framework;
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
    class Player
    {
        List<Texture2D> All_images;
        Location[] position;
        Keys[] activeKeys;
        public Location direction;
        Random random;
        int X, Y;
        public int lenght;
        public int texdirection;
        int size_x,size_y;
        KeyboardState keyboard;
        game game1;
        double screen_width, screen_height;
        public Player(List<Texture2D> All_images,game game,double screen_width,double screen_height)
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
            
        }
        public void update(game game1)

        

        {
            for (int i = lenght - 1; i > 0; i--)
            {
                if (i == 0)
                    position[i] = position[i] + direction;
                else
                    position[i] = position[i - 1];
            }


            keyboard = Keyboard.GetState();
            activeKeys = keyboard.GetPressedKeys();

            Move();


           
            //if (texdirection == 1)
            //    this.playertex = playertex;
            //            if (texdirection == 2)
            //                this.playertex = playertex2;
            //            if (texdirection == 3)
            //                this.playertex = playertex3;
            //            if (texdirection == 4)
            //                this.playertex = playertex4;

            position[0] = position[0] + direction;
            direction = new Location (0, 0);

        }
        public void draw(SpriteBatch spritebatch)
        {
            size_x = (int)this.screen_width / 12;
            size_y = (int)this.screen_height / 10;
            Rectangle destinationRectangle = new Rectangle(this.X, this.Y, size_x, size_y);
            //spritebatch.Draw(All_images[0], destinationRectangle, Color.White);
            // for (int i = 0; i < lenght; i++)
            spritebatch.Draw(All_images[5], destinationRectangle, Color.White);

        }
        int cnt = 1;

        public virtual void Move()
        {

            //if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape)) { Exit(); }

            if (this.X>(int)this.screen_width - size_x)
                this.X = (int)this.screen_width -size_x;
            if (this.Y > (int)this.screen_height - size_y)
                this.Y = (int)this.screen_height - size_y;
            if (this.X < -2)
                this.X = -1;
            if (this.Y < -2)
                this.Y = -1;
            foreach (Keys k in activeKeys)

            {
                if ( k==Keys.Right || k == Keys.D)
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

        
    }
    class AndroidPlayer : Player
    {
        public AndroidPlayer(List<Texture2D> All_images, game game, double screen_width, double screen_height) : base(All_images, game, screen_width, screen_height)
        {

        }
        public override void Move()
        {
            Keys[] keys = new Keys[2]();
            base.ActiveKeys = new Keys[2];
            ActiveKeys[0]
            base.Move();
        }
    }
    class Location
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
