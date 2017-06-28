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
        Vector2 position;
        List<Texture2D> All_images = new List<Texture2D>();
        double screen_width, screen_height;
        int speedX,speedY;

        public projectile(int PlayerposX,int PlayerposY,int mouseX , int mouseY , double screen_width,double screen_height,List<Texture2D> All_images,gameElement character)
        {
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

            //if (this.PlayerposX == 0) { this.PlayerposX += 1; }
            //if (this.PlayerposY == 0) { this.PlayerposY += 1; }

            this.speedX = 1;
            this.speedY = 1;

        }
        public void ShootToTarget()
        {
            DirectionX = (mouseX - PlayerposX);
            DirectionY = (mouseY - PlayerposY);

            position.X = position.X + (DirectionX*speedX);
            position.Y = position.Y + (DirectionY*speedY);

        }
        public void update(game game1)
        {
            ShootToTarget();
            
            
        }

        public void draw(SpriteBatch spritebatch)
        {
            
            Rectangle destinationRectangle = new Rectangle((int)position.X,(int)position.Y, 30, 30);
            spritebatch.Draw(All_images[1], destinationRectangle, Color.White);
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
}
        