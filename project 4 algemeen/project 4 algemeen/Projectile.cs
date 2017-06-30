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
    public class projectile : gameElement
    {
        
        int PlayerposX, PlayerposY;
        public int mouseX, mouseY;
        public int DirectionX, DirectionY;
        gameElement character;
        public Vector2 position;
        List<Texture2D> All_images = new List<Texture2D>();
        double screen_width, screen_height;
        double speedX,speedY;
        public int damage=500;
        public int projectile_HP;

        public projectile(int damage,int PlayerposX,int PlayerposY,int mouseX , int mouseY , double screen_width,double screen_height,List<Texture2D> All_images,gameElement character)
        {
            this.damage = damage;
            this.mouseX = mouseX;
            this.mouseY = mouseY;
            this.PlayerposX = PlayerposX;
            this.PlayerposY = PlayerposY;
            this.screen_width = screen_width;
            this.screen_height = screen_height;
            this.character = character;
            this.position.X = 1+this.PlayerposX;
            this.position.Y = 1+this.PlayerposY;
            this.All_images = All_images;
            this.character = character;
            this.projectile_HP = damage;

            

            //if (this.PlayerposX == 0) { this.PlayerposX += 1; }
            //if (this.PlayerposY == 0) { this.PlayerposY += 1; }

            this.speedX = 0.25;
            this.speedY = 0.25;

        }
        public void ShootToTarget()
        {
            DirectionX = (mouseX - PlayerposX);
            DirectionY = (mouseY - PlayerposY);

            position.X = position.X + (int)(DirectionX*speedX);
            position.Y = position.Y + (int)(DirectionY*speedY);

        }
        public int Hits()
        {
            projectile_HP -= damage;
            return this.damage;
        }
        public virtual void update(game game1)
        {
            ShootToTarget();
        }
        public int X1()
        {
            return (int)position.X;
        }
        public int X2()
        {
            return (int)position.X + 30;
        }
        public int Y1()
        {
            return (int)position.Y;
        }
        public int Y2()
        {
            return (int)position.Y + 30;
        }
        public void draw(SpriteBatch spritebatch)
        {
            if (this.projectile_HP > 0)
            {
                Rectangle destinationRectangle = new Rectangle((int)position.X, (int)position.Y, 30, 30);
                spritebatch.Draw(All_images[6], destinationRectangle, Color.White);
            }
        }
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
    }
    public class androidProjectile : projectile
    {
        public androidProjectile(int damage,int PlayerposX,int PlayerposY,int mouseX,int mouseY,double screen_width,double screen_height,List<Texture2D>All_images,gameElement character) : base(damage, PlayerposX, PlayerposY, mouseX, mouseY, screen_width, screen_height, All_images, character)
        {

        }
        public override void update(game game1)
        {
            position.X += mouseX;
            position.Y += mouseY;
        }
    }
}
        
