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
    public class Enemy : gameElement //creates different enemies
    {
        int ID;
        int HP, DMG;
        int X, Y;
        double screen_width, screen_height;
        string name;
        List<Texture2D> All_images = new List<Texture2D>();
        List<projectile> enemy_projectiles = new List<projectile>();
        public List<projectile> projectiles = new List<projectile>();
        Player player1;
        int PlayerposX, PlayerposY;
        int size_x ,size_y;
        public bool dead = false;
        Sound sound;
        bool isplayed = false;
        public int projectilesPS, projectileCNTMAX, projectileCNT;

        public List<button> buttons
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

        public Enemy(int ID,int X,int Y,double screen_width,double screen_height,List<Texture2D>All_images,Player player1, Sound sound)
        {                                                       //different IDs will decide which enemy will be spawned
            this.ID = ID;
            this.X = X;
            this.Y = Y;
            this.All_images = All_images;
            this.screen_height = screen_height;
            this.screen_width = screen_width;
            this.player1 = player1;
            this.size_x = (int)(screen_width / 10);
            this.size_y = (int)(screen_height / 10);
            this.sound = sound;
            this.projectilesPS = 3;
            this.projectileCNTMAX = 60 / projectilesPS;
            this.projectileCNT = 0;

            if (ID == 1)
            {
                this.name = "Enemy1";
                this.HP = 100;
                this.DMG = 5;
            }
            else if (ID==2)
            {
                this.name = "Enemy2";
                this.HP = 200;
                this.DMG = 10;

            }
            if(ID==3)
            {
                this.name = "Enemy3";
                this.HP = 300;
                this.DMG = 20;
            }
            if(ID==4)
            {
                this.size_x = this.size_x * 5;
                this.size_y = this.size_y * 5;
                this.X = (int)(screen_width * 0.60);
                this.Y = (int)(screen_height * 0.2);
                this.name = "Boss";
                this.HP = 20000;
                this.DMG = 20;
                
            }
        }
        public void MoveToPlayer()     //decides where the player is , then moves sto player with a given speed
        {
            PlayerposX = player1.GetPositionX();
            PlayerposY = player1.GetPositionY();
            if (this.ID==1)
            {
                if (PlayerposX > this.X) { this.X = this.X + 5; }
                if (PlayerposX < this.X) { this.X = this.X - 5; }
                if (PlayerposY > this.Y) { this.Y = this.Y + 5; }
                if (PlayerposY < this.Y) { this.Y = this.Y - 5; }
            }
            if (this.ID == 2)
            {
                if (PlayerposX > this.X) { this.X = this.X + 2; }
                if (PlayerposX < this.X) { this.X = this.X - 2; }
                if (PlayerposY > this.Y) { this.Y = this.Y + 2; }
                if (PlayerposY < this.Y) { this.Y = this.Y - 2; }
            }
        }
        public void shoot() //decides where player is , then shoots at the target if the projectile count is > 20 , so it shoots 3 times per second
        {

            if (ID == 3 || ID==4)
            {
                if (projectileCNT < projectileCNTMAX)
                {
                    projectileCNT++;
                }

                else if (projectileCNT >= projectileCNTMAX)
                {
                    enemy_projectiles.Add(new projectile(this.DMG, this.X, this.Y, this.player1.GetPositionX()+(player1.size_x/2), this.player1.GetPositionY()+(this.player1.size_y/2), this.screen_width, this.screen_height, this.All_images, this));
                    projectileCNT = 0;

                    foreach (projectile PRO in enemy_projectiles)
                    {
                        if (PRO.position.X >= player1.X && PRO.position.X <= player1.X + player1.size_x && PRO.position.Y >= player1.Y && PRO.position.Y < player1.Y + size_y)
                        { player1.GetHit(PRO.damage); }
                    }
                }
                    

                
            }
        }
        public void updateScreenSize(int width, int height)
        {
            this.screen_width = width;
            this.screen_height = height;
            this.size_x = (int)(width / 10);
            this.size_y = (int)(height / 10);
            if (ID == 4)
            {
                this.size_x = this.size_x * 5;
                this.size_y = this.size_y * 5;
                this.X = (int)(screen_width * 0.60);
                this.Y = (int)(screen_height * 0.2);
            }
        }
        public void GetHit() // checks if enemy is hit by a projectile from player
        {
            //foreach (projectile PRO in projectiles)
            //{
            //if (this.X >= PRO.X1() && this.X < PRO.X2() && this.Y >= PRO.Y1() && this.Y < PRO.Y2())
            //{

            foreach (projectile PRO in projectiles)
            {

                if (PRO.position.X > this.X && PRO.position.X <= this.X+size_x && PRO.position.Y >= this.Y && PRO.position.Y < this.Y+size_y)
                {
                    this.HP -= PRO.Hits();
                    
                }
            }
        }
        public void HitPlayer() // checks if hitboxes collide , and then gives dmg to player
        {
            if (this.X >= player1.X && this.X <= player1.X + player1.size_x && this.Y >= player1.Y && this.Y < player1.Y + size_y)
            {
                player1.GetHit(this.DMG);
            }
        }

        public bool IsDead() // checks if zombie is dead
        {
            if (this.HP <= 0)
            {
                if (ID == 1)
                {
                    player1.CurrentScore(100);
                }

                if (ID == 2)
                {
                    player1.CurrentScore(200);
                }

                if (ID == 3)
                {
                    player1.CurrentScore(300);
                }

                if (ID == 4)
                {
                    player1.CurrentScore(500);
                    
                }
                dead = true;
                PlayDeadSound();
                return dead;
            }
            else return dead;
        }
        public void update(game game1)
        {
            projectiles = player1.projectiles;
            if (IsDead() == false)
            {

                GetHit();
                shoot();
                IsDead();
                MoveToPlayer();
                
            }

            foreach (projectile PRO in projectiles)
            {
                PRO.update(game1);
            }
            foreach (projectile PRO in enemy_projectiles)
            {
                    PRO.update(game1);
            }

            HitPlayer();
        }

        public void PlayDeadSound() //plays dead sound
        {
            if(dead == true && isplayed == false)
            {
                if(ID == 4)
                {
                    sound.UnicornDeadSound();
                }
                else
                {
                    sound.ZombieDeadSound();
                }                
                isplayed = true;
            }
           
        }

        public void draw(SpriteBatch spritebatch)
        {
            if (dead==false)
            {
                Rectangle destinationRectangle = new Rectangle(this.X, this.Y, size_x, size_y);

                foreach (projectile PRO in enemy_projectiles)
                {
                    PRO.draw(spritebatch);
                }

                if (this.ID == 1)
                {
                    if (dead == false) { spritebatch.Draw(All_images[1], destinationRectangle, Color.White); }
                }
                else if (this.ID == 2)
                {
                    if (dead == false) { spritebatch.Draw(All_images[2], destinationRectangle, Color.White); }
                }
                else if (this.ID == 3)
                {
                    if (dead == false) { spritebatch.Draw(All_images[3], destinationRectangle, Color.White); }
                }
                else if (this.ID == 4)
                {
                    destinationRectangle = new Rectangle(this.X, this.Y, size_x, size_y);
                    if (dead == false) { spritebatch.Draw(All_images[4], destinationRectangle, Color.White); }
                }
            }

        }
    }
    public abstract class EnemyFactory
    {
        public static Enemy create(int id, double screen_width, double screen_heigth, List<Texture2D>All_images, Player player1, Random rand, Sound sound)
        {
            int x = rand.Next(0, (int)screen_width);
            int y = rand.Next(0, (int)screen_heigth);
            int centrX = (int)((player1.X + (player1.X + player1.size_x)) / 2);
            int centrY = (int)((player1.Y + (player1.Y + player1.size_y)) / 2);
            int difX = player1.X - x;
            if (difX < 0)
                difX *= -1;
            int difY = player1.Y - y;
            if (difY < 0)
                difY *= -1;
            while (difX < (int)screen_width / 6)
            {
                x = rand.Next(0, (int)screen_width);
                difX = player1.X - x;
                if (difX < 0)
                    difX *= -1;
            }
            while (difY < (int)screen_heigth / 6)
            {
                y = rand.Next(0, (int)screen_heigth);
                difY = player1.Y - y;
                if (difY < 0)
                    difY *= -1;
            }
            switch (id)
            {
                case 1:
                    return new Enemy(1, x, y, screen_width, screen_heigth, All_images, player1, sound);
                case 2:
                    return new Enemy(2, x, y, screen_width, screen_heigth, All_images, player1, sound);
                case 3:
                    return new Enemy(3, x, y, screen_width, screen_heigth, All_images, player1, sound);
                case 4:
                    return new Enemy(4, x, y, screen_width, screen_heigth, All_images, player1, sound);
                default:
                    throw new Exception("invalid id");
            }
        }
    }
}
