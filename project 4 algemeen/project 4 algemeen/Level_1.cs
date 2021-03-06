﻿using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Input.Touch;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using project_4_algemeen;

namespace project_4_algemeen
{
    public class Level_1 : gameElement  //contains all enemy and enemies of the first level
    {
        // thins that this class will receive : Player , enemies , list of images 
        List<Enemy> Enemies = new List<Enemy>();
        List<Texture2D> All_images = new List<Texture2D>();
        List<projectile> projectiles = new List<projectile>();
        string name;
        double screen_width, screen_height;
        List<button> Buttons = new List<button>();
        List<textbox> Textboxes = new List<textbox>();
        game game1;
        platform platform;
        SpriteFont Font;
        GraphicsDeviceManager graphics;
        Player player1;
        public bool levelcleared = false;
        Sound sound;
        Random rand;
        



        public Level_1(string name, double screen_width, double screen_height, List<Texture2D> All_images,game game1, platform platform, SpriteFont font, GraphicsDeviceManager graphics,Player player1,List<projectile>projectiles, Sound sound)
        {

            this.screen_width = screen_width;
            this.screen_height = screen_height;
            this.All_images = All_images;
            this.game1 = game1;
            this.platform = platform;
            this.Font = font;
            this.graphics = graphics;
            this.player1 = player1;
            this.projectiles = projectiles;
            this.sound = sound;



            if (platform == platform.android) // if the playform is android , then it will draw buttons to control the player
            {
                Color buttonColor = new Color(255, 255, 255, 127);

                //movebuttons
                buttons.Add(new button((int)0, (int)(screen_height - (screen_width / 3)), (int)screen_width / 9, (int)screen_width / 9, " left \n up ", font, (float)screen_height / 720, buttonColor, buttonColor, (game) => leftUp(game), graphics, 0.3f));
                buttons.Add(new button((int)(0 + (screen_width / 9)), (int)(screen_height - (screen_width / 3)), (int)screen_width / 9, (int)screen_width / 9, "up", font, (float)screen_height / 720, buttonColor, buttonColor, (game) => up(game), graphics, 0.3f));
                buttons.Add(new button((int)(0 + ((screen_width / 9) * 2)), (int)(screen_height - (screen_width / 3)), (int)screen_width / 9, (int)screen_width / 9, " right \n up ", font, (float)screen_height / 720, buttonColor, buttonColor, (game) => rightUp(game), graphics, 0.3f));
                buttons.Add(new button((int)0, (int)(screen_height - (screen_width / 3) + (screen_width / 9)), (int)screen_width / 9, (int)screen_width / 9, "left", font, (float)screen_height / 720, buttonColor, buttonColor, (game) => left(game), graphics, 0.3f));
                buttons.Add(new button((int)(0 + ((screen_width / 9) * 2)), (int)(screen_height - (screen_width / 3) + (screen_width / 9)), (int)screen_width / 9, (int)screen_width / 9, "right", font, (float)screen_height / 720, buttonColor, buttonColor, (game) => right(game), graphics, 0.3f));
                buttons.Add(new button((int)0, (int)(screen_height - (screen_width / 3) + ((screen_width / 9) * 2)), (int)screen_width / 9, (int)screen_width / 9, " left \n down ", font, (float)screen_height / 720, buttonColor, buttonColor, (game) => leftDown(game), graphics, 0.3f));
                buttons.Add(new button((int)(0 + (screen_width / 9)), (int)(screen_height - (screen_width / 3) + ((screen_width / 9) * 2)), (int)screen_width / 9, (int)screen_width / 9, "down", font, (float)screen_height / 720, buttonColor, buttonColor, (game) => down(game), graphics, 0.3f));
                buttons.Add(new button((int)(0 + ((screen_width / 9) * 2)), (int)(screen_height - (screen_width / 3) + ((screen_width / 9) * 2)), (int)screen_width / 9, (int)screen_width / 9, " right \n down ", font, (float)screen_height / 720, buttonColor, buttonColor, (game) => rightDown(game), graphics, 0.3f));

                //shootbuttons
                buttons.Add(new button((int)(screen_width-(screen_width/3)), (int)(screen_height - (screen_width / 3)), (int)screen_width / 9, (int)screen_width / 9, " shoot \n left \n up ", font, (float)screen_height / 720, buttonColor, buttonColor, (game) => shootLeftUp(game), graphics, 0.3f));
                buttons.Add(new button((int)(screen_width - (screen_width / 3) + (screen_width / 9)), (int)(screen_height - (screen_width / 3)), (int)screen_width / 9, (int)screen_width / 9, " shoot \n up ", font, (float)screen_height / 720, buttonColor, buttonColor, (game) => shootUp(game), graphics, 0.3f));
                buttons.Add(new button((int)(screen_width - (screen_width / 3) + ((screen_width / 9) * 2)), (int)(screen_height - (screen_width / 3)), (int)screen_width / 9, (int)screen_width / 9, " shoot \n right \n up ", font, (float)screen_height / 720, buttonColor, buttonColor, (game) => shootRightUp(game), graphics, 0.3f));
                buttons.Add(new button((int)(screen_width - (screen_width / 3)), (int)(screen_height - (screen_width / 3) + (screen_width / 9)), (int)screen_width / 9, (int)screen_width / 9, " shoot \n left ", font, (float)screen_height / 720, buttonColor, buttonColor, (game) => shootLeft(game), graphics, 0.3f));
                buttons.Add(new button((int)(screen_width - (screen_width / 3) + ((screen_width / 9) * 2)), (int)(screen_height - (screen_width / 3) + (screen_width / 9)), (int)screen_width / 9, (int)screen_width / 9, " shoot \n right ", font, (float)screen_height / 720, buttonColor, buttonColor, (game) => shootRight(game), graphics, 0.3f));
                buttons.Add(new button((int)(screen_width - (screen_width / 3)), (int)(screen_height - (screen_width / 3) + ((screen_width / 9) * 2)), (int)screen_width / 9, (int)screen_width / 9, " shoot \n left \n down ", font, (float)screen_height / 720, buttonColor, buttonColor, (game) => shootLeftDown(game), graphics, 0.3f));
                buttons.Add(new button((int)(screen_width - (screen_width / 3) + (screen_width / 9)), (int)(screen_height - (screen_width / 3) + ((screen_width / 9) * 2)), (int)screen_width / 9, (int)screen_width / 9, " shoot \n down ", font, (float)screen_height / 720, buttonColor, buttonColor, (game) => shootDown(game), graphics, 0.3f));
                buttons.Add(new button((int)(screen_width - (screen_width / 3) + ((screen_width / 9) * 2)), (int)(screen_height - (screen_width / 3) + ((screen_width / 9) * 2)), (int)screen_width / 9, (int)screen_width / 9, " shoot \n right \n down ", font, (float)screen_height / 720, buttonColor, buttonColor, (game) => shootRightDown(game), graphics, 0.3f));
            }

            rand = new Random();

            Enemies.Add(EnemyFactory.create(1, this.screen_width, this.screen_height, All_images, this.player1, rand, sound));
            Enemies.Add(EnemyFactory.create(2, this.screen_width, this.screen_height, All_images, this.player1, rand, sound));
            Enemies.Add(EnemyFactory.create(1, this.screen_width, this.screen_height, All_images, this.player1, rand, sound));
            
        }

        public void updateScreenSize(int width, int height) // updates screensize if the screensize changes
        {
            this.screen_width = width;
            this.screen_height = height;
            player1.updateScreenSize(width, height);
            foreach(Enemy e in Enemies)
            {
                e.updateScreenSize(width, height);
            }
        }
        public List<button> buttons
        {
            get
            {
                return this.Buttons;
            }
        }
        public List<textbox> textboxes
        {
            get
            {
                return Textboxes;
            }
        }
        public void draw(SpriteBatch spritebatch)
        {
            Rectangle destinationRectangle = new Rectangle(0, 0, (int)this.screen_width, (int)this.screen_height);
            spritebatch.Draw(All_images[0], destinationRectangle, Color.White);
            foreach (Enemy enemy in Enemies)
            {
                enemy.draw(spritebatch);
            }
            if (player1.dead == false)
            {
                player1.draw(spritebatch);
            }
            
            if (platform == platform.android)
            {
                foreach (button b in Buttons)
                {
                    b.draw(spritebatch);
                }
            }
        }
        public void update(game game1) // updates levels
        {
            if (player1.dead == false)
            {
                player1.update(game1);
            }

            int chance = rand.Next(0, 10000);
            if (chance >= 0 && chance < 5)
            {
                Enemies.Add(EnemyFactory.create(1, screen_width, screen_height, All_images, player1, rand, sound));
            }
            else if (chance == 5)
            {
                Enemies.Add(EnemyFactory.create(2, screen_width, screen_height, All_images, player1, rand, sound));
            }
            
            int dead_count = 0;
            foreach (Enemy enemy in Enemies) //updates the enmies in this level
            {
                
                if (enemy.dead == true)
                {
                    dead_count = dead_count+1;
                }
                else enemy.update(game1);

                if (dead_count == Enemies.Count())
                {
                    levelcleared = true;
                }
            }
        }





        public void leftUp(game game1)
        {
            Keys[] keys = new Keys[2] { Keys.Left, Keys.Up };
            player1.Move(keys);
        }
        public void up(game game1)
        {
            Keys[] keys = new Keys[1] { Keys.Up };
            player1.Move(keys);
        }
        public void rightUp(game game1)
        {
            Keys[] keys = new Keys[2] { Keys.Right, Keys.Up };
            player1.Move(keys);
        }
        public void left(game game1)
        {
            Keys[] keys = new Keys[1] { Keys.Left };
            player1.Move(keys);
        }
        public void right(game game1)
        {
            Keys[] keys = new Keys[1] { Keys.Right };
            player1.Move(keys);
        }
        public void leftDown(game game1)
        {
            Keys[] keys = new Keys[2] { Keys.Left, Keys.Down };
            player1.Move(keys);
        }
        public void down(game game1)
        {
            Keys[] keys = new Keys[1] { Keys.Down };
            player1.Move(keys);
        }
        public void rightDown(game game1)
        {
            Keys[] keys = new Keys[2] { Keys.Right, Keys.Down };
            player1.Move(keys);
        }
        public void shootLeftUp(game game1)
        {
            player1.shootDirection = new Location(-15, -15);
            player1.Shoot();
        }
        public void shootUp(game game1)
        {
            player1.shootDirection = new Location(0, -15);
            player1.Shoot();
        }
        public void shootRightUp(game game1)
        {
            player1.shootDirection = new Location(15, -15);
            player1.Shoot();
        }
        public void shootLeft(game game1)
        {
            player1.shootDirection = new Location(-15, 0);
            player1.Shoot();
        }
        public void shootRight(game game1)
        {
            player1.shootDirection = new Location(15, 0);
            player1.Shoot();
        }
        public void shootLeftDown(game game1)
        {
            player1.shootDirection = new Location(-15, 15);
            player1.Shoot();
        }
        public void shootDown(game game1)
        {
            player1.shootDirection = new Location(0, 15);
            player1.Shoot();
        }
        public void shootRightDown(game game1)
        {
            player1.shootDirection = new Location(15, 15);
            player1.Shoot();
        }
    }
}
