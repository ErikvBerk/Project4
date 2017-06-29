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
    public class Enemy
    {
        int ID;
        int HP, DMG;
        int X, Y;
        double screen_width, screen_height;
        string name;
        List<Texture2D> All_images = new List<Texture2D>();
        public List<projectile> projectiles = new List<projectile>();
        Player player1;
        int PlayerposX, PlayerposY;
        public Enemy(int ID,int X,int Y,double screen_width,double screen_height,List<Texture2D>All_images,Player player1)
        {
            this.ID = ID;
            this.X = X;
            this.Y = Y;
            this.All_images = All_images;
            this.screen_height = screen_height;
            this.screen_width = screen_width;
            this.player1 = player1;

            if (ID == 1)
            {
                this.name = "Enemy1";
                this.HP = 100;
                this.DMG = 100;
            }
            else if (ID==2)
            {
                this.name = "Enemy2";
                this.HP = 200;
                this.DMG = 100;

            }
            if(ID==3)
            {
                this.name = "Enemy3";
                this.HP = 300;
                this.DMG = 100;
            }
            if(ID==4)
            {
                this.name = "Boss";
                this.HP = 20000;
                this.DMG = 50;
            }
        }
        public void MoveToPlayer()
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
        public void shoot()
        {

        }
        public void GetHit()
        {
            //foreach (projectile PRO in projectiles)
            //{
            //if (this.X >= PRO.X1() && this.X < PRO.X2() && this.Y >= PRO.Y1() && this.Y < PRO.Y2())
            //{

            this.HP = this.HP - 5;

            //}

            //}
            

        }
        public bool Dead()
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
                return true;
            }
            else return false;
        }
        public void update(game game1)
        {
            if (!Dead())
            {
                MoveToPlayer();
            
                foreach(projectile PRO in projectiles)
                {
                    if (PRO.position.X >= X && PRO.position.X < X + (int)(screen_width / 5) && PRO.position.Y >= Y && PRO.position.Y < Y + (int)(screen_height / 5))
                    {
                        GetHit();
                    }
                }
            }



            // X = X  -0;
        }
        public void draw(SpriteBatch spritebatch)
        {
            if (!Dead())
            {
                Rectangle destinationRectangle = new Rectangle(this.X, this.Y, (int)this.screen_width / 5, (int)this.screen_height / 5);

                if (this.ID == 1)
                {
                    if (Dead() == false) { spritebatch.Draw(All_images[1], destinationRectangle, Color.White); }
                }
                else if (this.ID == 2)
                {
                    if (Dead() == false) { spritebatch.Draw(All_images[2], destinationRectangle, Color.White); }
                }
                else if (this.ID == 3)
                {
                    if (Dead() == false) { spritebatch.Draw(All_images[3], destinationRectangle, Color.White); }
                }
                else if (this.ID == 4)
                {
                    if (Dead() == false) { spritebatch.Draw(All_images[4], destinationRectangle, Color.White); }
                }
            }

        }
    }
    public abstract class EnemyFactory
    {
        public static Enemy create(int id, double screen_width, double screen_heigth, List<Texture2D>All_images, Player player1)
        {
            Random rand = new Random();
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
                    return new Enemy(1, x, y, screen_width, screen_heigth, All_images, player1);
                case 2:
                    return new Enemy(2, x, y, screen_width, screen_heigth, All_images, player1);
                case 3:
                    return new Enemy(3, x, y, screen_width, screen_heigth, All_images, player1);
                case 4:
                    return new Enemy(4, x, y, screen_width, screen_heigth, All_images, player1);
                default:
                    throw new Exception("invalid id");
            }
        }
    }
}
