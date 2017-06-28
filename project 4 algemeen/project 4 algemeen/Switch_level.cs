using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;


namespace project_4_algemeen
{
    class Switch_level:gameElement
    {
        List<Texture2D> All_images = new List<Texture2D>();
        List<button> Buttons = new List<button>();
        List<textbox> Textboxes = new List<textbox>();
        game game1;
        double screen_width, screen_height;
        Player player1;
        Level_1 level1;
        Level_2 level2;
        Level_3 level3;
        Level_Boss levelBoss;
        platform platform;
        SpriteFont Font;
        GraphicsDeviceManager graphics;
        EndGame EndGame;

        public Switch_level(List<Texture2D> All_images,game game1,double screen_width,double screen_height,platform platform,SpriteFont font, GraphicsDeviceManager graphics)
        {
            this.All_images = All_images;
            this.game1 = game1;
            this.screen_width = screen_width;
            this.screen_height = screen_height;
            this.platform = platform;
            this.Font = font;
            this.graphics = graphics;



            switch (platform)
            {
                case platform.android:
                    player1 = new AndroidPlayer(All_images, game1, screen_width, screen_height, font, graphics);
                    break;
                case platform.windows:
                    player1 = new Player(this.All_images, this.game1, this.screen_width, this.screen_height);
                    break;
                default:
                    break;
            }

            level1 = new Level_1("Level 1", this.screen_width, this.screen_height, this.All_images, this.game1, this.platform,this.Font, this.graphics, this.player1);
            level2 = new Level_2("Level 2", this.screen_width, this.screen_height, this.All_images, this.game1, this.platform,this.Font, this.graphics, this.player1);
            level3 = new Level_3("Level 3", this.screen_width, this.screen_height, this.All_images, this.game1, this.platform,this.Font, this.graphics, this.player1);
            //levelBoss = new Level_Boss("Level 1", this.screen_width, this.screen_height, this.All_images, this.game1, this.platform,this.Font, this.graphics, this.player1);


            //public Level_Boss(string name, double screen_width, double screen_height, List<Texture2D> All_images,game game1, platform platform, SpriteFont font, GraphicsDeviceManager graphics)

            EndGame = new EndGame();
        }



        public List<button> buttons
        {
            get
            {
                return Buttons;
            }
        }

        public List<textbox> textboxes
        {
            get
            {
                return Textboxes;
            }
        }

        public void update(game game1)
        {
            if(level1.LevelCleared()==false)
            {
                level1.update(game1);
            }
            else if(level2.LevelCleared()==false)
            {
                level2.update(game1);
            }
            else if(level3.LevelCleared()==false)
            {
                level3.update(game1);
            }
        }

        public void draw(SpriteBatch spritebatch)
        {
            if (level1.LevelCleared() == false)
            {
                level1.draw(spritebatch);
            }
            else if (level2.LevelCleared() == false)
            {
                level2.draw(spritebatch);
            }
            else if (level3.LevelCleared() == false)
            {
                level3.draw(spritebatch);
            }

        }

        

    }
}
