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
    public class Level_Boss : gameElement
    {
        // thins that this class will receive : Player , enemies , list of images 
        List<Enemy> Enemies = new List<Enemy>();
        List<Texture2D> All_images = new List<Texture2D>();
        double screen_width, screen_height;
        List<button> Buttons = new List<button>();
        List<textbox> Textboxes = new List<textbox>();
        List<projectile> projectiles = new List<projectile>();
        public Player player1;
        game game1;
        platform platform;
        gameElement switchLevel;
        int PlayerposX, PlayerposY;

        public Level_Boss() { }
        public Level_Boss(string name, double screen_width, double screen_height, List<Texture2D> All_images,game game1, platform platform, SpriteFont font, GraphicsDeviceManager graphics, Player player1, List<projectile>projectiles,int PlayerposX,int PlayerposY)
        {
            this.screen_width = screen_width;
            this.screen_height = screen_height;
            this.All_images = All_images;
            this.game1 = game1;
            this.player1 = player1;
            this.platform = platform;
            this.projectiles = projectiles;
            this.PlayerposX = PlayerposX;
            this.PlayerposY = PlayerposY;


            if (platform == platform.android)
            {
                Color buttonColor = new Color(255, 255, 255, 127);
                buttons.Add(new button((int)0, (int)(screen_height - (screen_width / 3)), (int)screen_width / 9, (int)screen_width / 9, " left \n up ", font, (float)screen_height / 720, buttonColor, buttonColor, (game) => leftUp(game), graphics, 0.3f));
                buttons.Add(new button((int)(0 + (screen_width / 9)), (int)(screen_height - (screen_width / 3)), (int)screen_width / 9, (int)screen_width / 9, "up", font, (float)screen_height / 720, buttonColor, buttonColor, (game) => up(game), graphics, 0.3f));
                buttons.Add(new button((int)(0 + ((screen_width / 9) * 2)), (int)(screen_height - (screen_width / 3)), (int)screen_width / 9, (int)screen_width / 9, " right \n up ", font, (float)screen_height / 720, buttonColor, buttonColor, (game) => rightUp(game), graphics, 0.3f));
                buttons.Add(new button((int)0, (int)(screen_height - (screen_width / 3) + (screen_width / 9)), (int)screen_width / 9, (int)screen_width / 9, "left", font, (float)screen_height / 720, buttonColor, buttonColor, (game) => left(game), graphics, 0.3f));
                buttons.Add(new button((int)(0 + ((screen_width / 9) * 2)), (int)(screen_height - (screen_width / 3) + (screen_width / 9)), (int)screen_width / 9, (int)screen_width / 9, "right", font, (float)screen_height / 720, buttonColor, buttonColor, (game) => right(game), graphics, 0.3f));
                buttons.Add(new button((int)0, (int)(screen_height - (screen_width / 3) + ((screen_width / 9) * 2)), (int)screen_width / 9, (int)screen_width / 9, " left \n down ", font, (float)screen_height / 720, buttonColor, buttonColor, (game) => leftDown(game), graphics, 0.3f));
                buttons.Add(new button((int)(0 + (screen_width / 9)), (int)(screen_height - (screen_width / 3) + ((screen_width / 9) * 2)), (int)screen_width / 9, (int)screen_width / 9, "down", font, (float)screen_height / 720, buttonColor, buttonColor, (game) => down(game), graphics, 0.3f));
                buttons.Add(new button((int)(0 + ((screen_width / 9) * 2)), (int)(screen_height - (screen_width / 3) + ((screen_width / 9) * 2)), (int)screen_width / 9, (int)screen_width / 9, " right \n down ", font, (float)screen_height / 720, buttonColor, buttonColor, (game) => rightDown(game), graphics, 0.3f));
            }

<<<<<<< HEAD
            Enemies.Add(new Enemy(4, 800, 200, this.screen_width, this.screen_height, All_images, this.player1));
=======
            Enemies.Add(new Enemy(4, 800, 200, this.screen_width, this.screen_height, All_images, projectiles, this.player1));
>>>>>>> niet-master2
        }
        public List<button> buttons
        {
            get
            {
                return this.Buttons;
            }
        }
        public int GetPlayerposX()
        {
            return PlayerposX;
        }
        public int GetPlayerposY()
        {
            return PlayerposY;
        }
        public List<textbox> textboxes
        {
            get
            {
                return Textboxes;
            }
        }

        public bool LevelCleared()
        {

            bool levelcleared = false;
            foreach (Enemy enemy in Enemies)
            {
                levelcleared = !levelcleared && enemy.Dead();

            }
            return (levelcleared);
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
            if (platform == platform.android)
            {
                foreach (button b in Buttons)
                {
                    b.draw(spritebatch);
                }
            }
        }
        public void update(game game1)
        {
            player1.update(game1);
            foreach (Enemy enemy in Enemies)
            {
                enemy.update(game1);
            }
        }
        public void leftUp(game game1)
        {
            Keys[] keys = new Keys[2] { Keys.Left, Keys.Up };
            player1.Move(keys);
        }
        public void up(game game1)
        {
            Keys[] keys = new Keys[1] { Keys.Up };
            player1.Move(keys);
        }
        public void rightUp(game game1)
        {
            Keys[] keys = new Keys[2] { Keys.Right, Keys.Up };
            player1.Move(keys);
        }
        public void left(game game1)
        {
            Keys[] keys = new Keys[1] { Keys.Left };
            player1.Move(keys);
        }
        public void right(game game1)
        {
            Keys[] keys = new Keys[1] { Keys.Right };
            player1.Move(keys);
        }
        public void leftDown(game game1)
        {
            Keys[] keys = new Keys[2] { Keys.Left, Keys.Down };
            player1.Move(keys);
        }
        public void down(game game1)
        {
            Keys[] keys = new Keys[1] { Keys.Down };
            player1.Move(keys);
        }
        public void rightDown(game game1)
        {
            Keys[] keys = new Keys[2] { Keys.Right, Keys.Down };
            player1.Move(keys);
        }
    }
}
