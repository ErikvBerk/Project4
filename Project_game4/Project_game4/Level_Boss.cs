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
    class Level_Boss : gameElement
    {
        // thins that this class will receive : Player , enemies , list of images 
        List<Enemy> Enemies = new List<Enemy>();
        List<Texture2D> All_images = new List<Texture2D>();
        string name;
        double screen_width, screen_height;
        List<button> Buttons = new List<button>();
        List<textbox> Textboxes = new List<textbox>();
        Player player1;
        game game1;

        public Level_Boss(string name, double screen_width, double screen_height, List<Texture2D> All_images,game game1)
        {

            this.screen_width = screen_width;
            this.screen_height = screen_height;
            this.All_images = All_images;
            this.game1 = game1;

            Enemies.Add(new Enemy(4, 800, 200, this.screen_width, this.screen_height, All_images));

            player1 = new Player(this.All_images, this.game1,this.screen_width,this.screen_height);

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

        public void draw(SpriteBatch spritebatch)
        {
            Rectangle destinationRectangle = new Rectangle(0, 0, (int)this.screen_width, (int)this.screen_height);
            spritebatch.Draw(All_images[0], destinationRectangle, Color.White);
            foreach (Enemy enemy in Enemies)
            {
                enemy.draw(spritebatch);
            }
            player1.draw(spritebatch);
        }

        public void update(game game1)
        {
            player1.update(game1);
            foreach (Enemy enemy in Enemies)
            {
                enemy.update(game1);
            }
        }
    }
}
