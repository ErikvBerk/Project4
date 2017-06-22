using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Project_game4;

namespace project_4_algemeen
{
    class Menu 
    {
        GraphicsDeviceManager graphics;
        project_4_algemeen.button Play;
        project_4_algemeen.button Highscore;
        project_4_algemeen.button Instructions;
        project_4_algemeen.button Exit;
        SpriteBatch spriteBatch;
        SpriteFont Font;
        Texture2D rect;
        double screen_height;
        double screen_width;

        public Menu(GraphicsDeviceManager graphics, SpriteFont Font, double screen_height, double screen_width)
        {
            this.graphics = graphics;
            this.Font = Font;
            this.screen_height = screen_height;
            this.screen_width = screen_width;

            //oud Play = new Button("Play", rect, 100, 200, this.Font,200,30,Color.Red); (Convert.ToInt32((Math.Ceiling((screen_height*1.00)-(screen_height*0.5)))))
            Play = new project_4_algemeen.button((Convert.ToInt32((Math.Ceiling(screen_width * 0.8)))), (Convert.ToInt32((Math.Ceiling(this.screen_height * 0.18)))), (Convert.ToInt32(Math.Ceiling(screen_width * 0.4))), (Convert.ToInt32(Math.Ceiling(screen_width * 0.1))), "Play!", Font, Color.Khaki, Color.OliveDrab, () => Hi(), graphics);
            Highscore = new project_4_algemeen.button((Convert.ToInt32((Math.Ceiling(screen_width * 0.8)))), (Convert.ToInt32((Math.Ceiling(this.screen_height * 0.26)))), (Convert.ToInt32(Math.Ceiling(screen_width * 0.4))), (Convert.ToInt32(Math.Ceiling(screen_width * 0.1))), "Highscores!", Font, Color.Khaki, Color.OliveDrab, () => Hi(), graphics);
            Instructions = new project_4_algemeen.button((Convert.ToInt32((Math.Ceiling(screen_width * 0.8)))), (Convert.ToInt32((Math.Ceiling(this.screen_height * 0.34)))), (Convert.ToInt32(Math.Ceiling(screen_width * 0.4))), (Convert.ToInt32(Math.Ceiling(screen_width * 0.1))), "Instructions!", Font, Color.Khaki, Color.OliveDrab, () => Hi(), graphics);
            Exit = new project_4_algemeen.button((Convert.ToInt32((Math.Ceiling(screen_width * 0.8)))), (Convert.ToInt32((Math.Ceiling(this.screen_height * 0.42)))), (Convert.ToInt32(Math.Ceiling(screen_width * 0.4))), (Convert.ToInt32(Math.Ceiling(screen_width * 0.1))), "Exit!", Font, Color.Maroon, Color.Red, () => Hi(), graphics);



            Console.WriteLine(screen_height);
            Console.WriteLine(screen_width);
        }
        public void Update()
        {
            Play.update();
            Highscore.update();
            Instructions.update();
            Exit.update();

        }
        public void Draw(SpriteBatch spritebatch)
        {

            Play.draw(spritebatch);
            Highscore.draw(spritebatch);
            Instructions.draw(spritebatch);
            Exit.draw(spritebatch);
            //
            //rect = new Texture2D(graphics.GraphicsDevice, 200, 30);

        }
        public void Hi()
        {

        }

    }
}
