﻿using System;
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
using Microsoft.Xna.Framework.Content;

namespace project_4_algemeen
{
    class Play : gameElement
    {
        GraphicsDeviceManager graphics;

        SpriteFont Font;
        double screen_width, screen_height;
        float relativeSize;
        Action<game> exit;
        List<button> Buttons = new List<button>();
        List<textbox> Textboxes = new List<textbox>();
        game game1;
        string name;
        List<Texture2D> All_images;        
        platform platform;
        Sound sound;
        gameElement Origin;
        
        public Play(double screen_width, double screen_height, float relativeSize, SpriteFont font, GraphicsDeviceManager graphics, game game1,List<Texture2D> All_images, platform platform, Sound sound, gameElement Origin)

        {
            this.graphics = graphics;
            this.Font = font;
            this.screen_width = screen_width;
            this.screen_height = screen_height;
            this.relativeSize = relativeSize;
            this.game1 = game1;
            this.All_images = All_images;
            this.platform = platform;
            this.sound = sound;
            this.Origin = Origin;



            //this.texture = new Texture2D(graphics.GraphicsDevice, (int)(100), (int)(100));
            //Color[] data = new Color[(int)(100) * (int)(100)];
            //for (int i = 0; i < data.Length; ++i) data[i] = Color.White;
            //this.texture.SetData(data);

            //All level instances 

            //Buttons.Add(new button((int)(screen_width - (this.screen_width / 6)), (int)(this.screen_height - this.screen_height / 6), (int)this.screen_width / 8, (int)this.screen_height / 8, "Start!", this.Font, this.relativeSize, Color.White, Color.LightGray, level1 = new Level_1("Level1", this.screen_width, this.screen_height,All_images), graphics));
            //Buttons.Add(new button((int)(screen_width - (this.screen_width / 6)), (int)(this.screen_height - this.screen_height / 6), (int)this.screen_width / 8, (int)this.screen_height / 8, "Start!", this.Font, this.relativeSize, Color.White, Color.LightGray, level2 = new Level_2("Level2", this.screen_width, this.screen_height, All_images), graphics));
            //Buttons.Add(new button((int)(screen_width - (this.screen_width / 6)), (int)(this.screen_height - this.screen_height / 6), (int)this.screen_width / 8, (int)this.screen_height / 8, "Start!", this.Font, this.relativeSize, Color.White, Color.LightGray, level3 = new Level_3("Level3", this.screen_width, this.screen_height, All_images), graphics));
            Buttons.Add(new button(All_images[23],(int)(screen_width * 0.4), (int)(this.screen_height*0.5), (int)(screen_width * 0.2), (int)(screen_height * 0.1), "Start!", this.Font, this.relativeSize, Color.White, Color.LightGray,  new Switch_level(this.All_images,this.game1,this.screen_width,this.screen_height, this.relativeSize, this.exit, this.platform,this.Font,this.graphics, this.sound, this.Origin), graphics));


            //Buttons.Add(new button((int)(screen_width - (screen_width / 6)), (int)(screen_height - screen_height / 3), (int)screen_width / 8, (int)screen_height / 8, "next", font, relativeSize, Color.White, Color.LightGray, new Instructions("Play_instructions", this.screen_width, this.screen_height, this.relativeSize, this.Font, this.graphics, this.game1), graphics));


            //CurrentScore();
            //CurrentScoreString();

        }
        public void updateScreenSize(int width, int height)
        {
            this.screen_width = width;
            this.screen_height = height;
            Buttons[0].X = (int)(width * 0.4);
            Buttons[0].Y = (int)(height * 0.5);
            Buttons[0].width = (int)(width *0.2);
            Buttons[0].heigth = (int)(height *0.1);
            //Buttons[0].createTexture(graphics);
        }

        public void update(game game1)
        {

            
            foreach (button b in Buttons)
            {
                b.update(game1);
            }
            foreach (textbox t in textboxes)
            {
                t.update();
            }
        }

        public void draw(SpriteBatch spritebatch)
        {
            Rectangle destinationRectangle = new Rectangle(0, 0, (int)screen_width, (int)screen_height);
            spritebatch.Draw(All_images[13], destinationRectangle, Color.White);

            foreach (button b in Buttons)
            {
                b.draw(spritebatch);
            }
            foreach (textbox t in textboxes)
            {
                t.draw(spritebatch);
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

     
    }
}
