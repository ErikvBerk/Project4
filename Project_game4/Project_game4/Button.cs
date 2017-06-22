using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Microsoft.Xna.Framework.Input;
using Microsoft.VisualBasic;

namespace Project_game4
{

    public class Button
    {
        int buttonX, buttonY, buttonWidth, buttonHeigth;
        string Name;
        Texture2D Texture;
        public bool isClicked;
        public bool isHovered;
        public bool isClickable;
        public bool hasBeenClicked;
        public bool Clicked;
        Vector2 Position;
        public Color Color;
        SpriteFont font;
        
        

        public int ButtonX
        {
            get
            {
                return buttonX;
            }
        }

        public int ButtonY
        {
            get
            {
                return buttonY;
            }
        }

        public Button(string name, Texture2D texture, int buttonX, int buttonY, SpriteFont font,int Width,int Height,Color color)
        {
            this.Name = name;
            this.Texture = texture;
            this.buttonX = buttonX;
            this.buttonY = buttonY;
            this.buttonWidth = Width;
            this.buttonHeigth = Height;
            this.Position = new Vector2(this.buttonX, this.buttonY);
            this.font = font;
            this.isClickable = true;
            this.Color = color;
        }

        public void Update()
        {
            var mouseState = Mouse.GetState();

            if((mouseState.X >=buttonX && mouseState.X<= (buttonX+buttonWidth)) && (mouseState.Y >= buttonY && mouseState.Y<(buttonY + buttonHeigth)))          
            {
                this.isHovered = true;
                this.Color = Color.Green;

                Console.WriteLine("Hover works");


                Clicked = mouseState.LeftButton == ButtonState.Pressed;

                if (this.Clicked == true)
                {                    
                    this.Color = Color.Green;           
                    this.hasBeenClicked = true;

                    Console.WriteLine(mouseState.X);
                    Console.WriteLine("Clicked works");

                }
                    if (hasBeenClicked == true)
                    {
                    //Execute Action here
                    Console.WriteLine("hasBeenClicked works");

                    }
                }
            else
            {
                this.isHovered = false;
                this.Clicked = false;
                this.Color = Color.Red;
            }


        }

            
            
            
        
        public void Draw(SpriteBatch spriteBatch)
        {
            if (isHovered)
                spriteBatch.Draw(this.Texture, this.Position, this.Color);
            else
                spriteBatch.Draw(this.Texture, this.Position, this.Color);

            
            spriteBatch.Draw(Texture, Position,Color);
            spriteBatch.DrawString(this.font, this.Name, new Vector2(this.buttonX + 5, this.buttonY + 7), Color.Black);

        }
        
    }
}