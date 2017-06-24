using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

using Microsoft.Xna.Framework.Input.Touch;



using Microsoft.VisualBasic;
using project_4_algemeen;

namespace Project_game4
{
    public class androidButtonAdapter
    {
        button button;
        public androidButtonAdapter(button button)
        {
            this.button = button;
        }
        public void update(TouchCollection currenttouch)
        {
            foreach (TouchLocation t in currenttouch)
            {
                if (t.Position.X >= this.button.X && t.Position.X < this.button.X + this.button.width && t.Position.Y >= this.button.Y && t.Position.Y < this.button.Y + this.button.heigth)
                {
                    if (t.State == TouchLocationState.Pressed)
                    {
                        button.onclick();
                    }
                }
            }
        }
        public void draw(SpriteBatch spritebatch)
        {
            this.button.draw(spritebatch);
        }
    }
    public class button
    {
        public int X, Y, width, heigth;
        Texture2D texture;
        Color Color, hoverColor, CurrentColor;
        public I_Button_classes Class_call;
        public bool visible;
        bool clicked=false;
        public bool HasBeenClicked;
        String Text;
        SpriteFont Font;
        SpriteBatch spritebatch;
        GraphicsDeviceManager graphics;

        public button(int x, int y, int width, int heigth, String text, SpriteFont font, float textsize, Color color, Color hovercolor, I_Button_classes Class_call, GraphicsDeviceManager graphics)
        {
            this.X = x;
            this.Y = y;
            this.width = width;
            this.heigth = heigth;
            this.Color = color;
            this.hoverColor = hovercolor;
            this.Class_call = Class_call;
            this.CurrentColor = this.Color;
            visible = true;
            this.Text = text;
            this.Font = font;
            this.graphics = graphics;
            


            createTexture(graphics);
        }
        public void createTexture(GraphicsDeviceManager graphics) //creates the texture (background) for the buttons
        {
            this.texture = new Texture2D(graphics.GraphicsDevice, (int)(this.width), (int)(this.heigth));
            Color[] data = new Color[(int)(this.width) * (int)(this.heigth)];
            for (int i = 0; i < data.Length; ++i) data[i] = Color.White;
            this.texture.SetData(data);
        }
        public void onclick()
        {

            
            if (clicked==true)
            {
                HasBeenClicked = clicked;
                clicked = false;
            }
            else { HasBeenClicked = false; }

        }
        public void isClicked()
        {
            
        }
        public void update()
        {
            var mousestate = Mouse.GetState();  //Position of mouse , if statement creates the hitbox for the buttons.

            if (mousestate.X >= this.X && mousestate.X < (this.X + this.width) && mousestate.Y >= this.Y && mousestate.Y < (this.Y + this.heigth))
            {
                this.CurrentColor = hoverColor;
                if (mousestate.LeftButton == ButtonState.Pressed)
                {

                    
                    this.CurrentColor = this.hoverColor;
                    clicked = true;
                    onclick();

                }
            }
            else
            {
                this.CurrentColor = this.Color;
            }
        }
        public void draw(SpriteBatch spritebatch) 
        {
            
            if (visible)
                spritebatch.Draw(texture, new Vector2(this.X, this.Y), this.CurrentColor);  //draws the background color texture
            spritebatch.DrawString(Font, Text, new Vector2(this.X, this.Y), Color.Black);  //draws the strings on the buttons

            
        }
    }
}

