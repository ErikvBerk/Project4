using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Project_game4
{
    interface IGUIelement
    {
        void Draw(SpriteBatch spritebatch);
        void Update();
    }
}
