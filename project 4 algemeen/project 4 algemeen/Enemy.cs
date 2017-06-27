using Microsoft.Xna.Framework;
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
    class Enemy
    {
        //will need position of player
        int ID;
        int HP, DMG;
        int X, Y;
        double screen_width, screen_height;
        string name;
        List<Texture2D> All_images = new List<Texture2D>();

        public Enemy(int ID,int X,int Y,double screen_width,double screen_height,List<Texture2D>All_images)
        {
            this.ID = ID;
            this.X = X;
            this.Y = Y;
            this.All_images = All_images;
            this.screen_height = screen_height;
            this.screen_width = screen_width;

            if (ID == 1)
            {
                this.name = "Enemey1";
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
        public void shoot()
        {

        }

        public void update(game game1)
        {
            X = X  -1;
        }

        public void draw(SpriteBatch spritebatch)
        {
            Rectangle destinationRectangle = new Rectangle(this.X, this.Y, (int)this.screen_width / 5, (int)this.screen_height / 5);

            if     (this.ID == 1){ spritebatch.Draw(All_images[1], destinationRectangle, Color.White);}
            else if(this.ID == 2){ spritebatch.Draw(All_images[2], destinationRectangle, Color.White);}
            else if(this.ID == 3){ spritebatch.Draw(All_images[3], destinationRectangle, Color.White);}
            else if(this.ID == 4){ spritebatch.Draw(All_images[4], destinationRectangle, Color.White);}


        }
    }
}
