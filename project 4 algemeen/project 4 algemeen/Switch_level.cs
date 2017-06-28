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
            levelBoss = new Level_Boss("Level 1", this.screen_width, this.screen_height, this.All_images, this.game1, this.platform,this.Font, this.graphics, this.player1);


            //public Level_Boss(string name, double screen_width, double screen_height, List<Texture2D> All_images,game game1, platform platform, SpriteFont font, GraphicsDeviceManager graphics)


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

        public void update(game game1)
        {
            
        }

        public void draw(SpriteBatch spritebatch)
        {
            
        }

        

    }
}
