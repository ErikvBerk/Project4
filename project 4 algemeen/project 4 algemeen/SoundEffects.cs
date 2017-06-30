using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework.Audio;

namespace project_4_algemeen
{
    public class SoundEffects
    {
        public float volume;
        public float pan;

        public SoundEffects()
        {
            
        }

        public void Play(float volume, float pan)
        {
            this.volume = volume;
            this.pan = pan;
        }
    }
}
