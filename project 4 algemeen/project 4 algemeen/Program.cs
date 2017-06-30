using Microsoft.Xna.Framework.Graphics;
using System;

namespace project_4_algemeen
{
    /// <summary>
    /// The main class.
    /// </summary>
    public static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            //using (var game = new Game1())
            //    game.Run();
            androidTextBoxAdapter t = new androidTextBoxAdapter(new textbox());
            t.textbox.pressed = true;
            Microsoft.Xna.Framework.Input.Touch.TouchLocation[] tl = new Microsoft.Xna.Framework.Input.Touch.TouchLocation[1];
            tl[0] = new Microsoft.Xna.Framework.Input.Touch.TouchLocation(1, Microsoft.Xna.Framework.Input.Touch.TouchLocationState.Pressed, new Microsoft.Xna.Framework.Vector2());
            t.update(new Microsoft.Xna.Framework.Input.Touch.TouchCollection(tl));
        }
    }
}
