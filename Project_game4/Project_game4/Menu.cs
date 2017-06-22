using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Project_game4;

namespace Project_game4
{
    class Menu : IGUIelement
    {
        GraphicsDeviceManager graphics;
        project_4_algemeen.button Play;
        project_4_algemeen.button Highscore;
        project_4_algemeen.button Instructions;
        project_4_algemeen.button Exit;
        SpriteBatch spriteBatch;
        SpriteFont Font;
        Texture2D rect;

        public Menu(GraphicsDeviceManager graphics, Texture2D rect, SpriteFont Font)
        {
            this.graphics = graphics;
            this.Font = Font;

            //oud Play = new Button("Play", rect, 100, 200, this.Font,200,30,Color.Red);
            Play = new project_4_algemeen.button(770, 400, 750, 200, "Play", Font, Color.DarkKhaki, Color.OliveDrab, () => Hi(), graphics);
            Highscore = new project_4_algemeen.button(770, 550, 750, 200, "Highscores!", Font, Color.DarkKhaki, Color.OliveDrab, () => Hi(), graphics);
            Instructions = new project_4_algemeen.button(770, 700, 750, 200, "Instructions!", Font, Color.DarkKhaki, Color.OliveDrab, () => Hi(), graphics);
            Exit = new project_4_algemeen.button(770, 850, 750, 200, "Exit!", Font, Color.Maroon, Color.Red, () => Hi(), graphics);

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
