using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework.Audio;

namespace project_4_algemeen
{
    public class Sound
    {
        List<SoundEffect> list = new List<SoundEffect>();

        public Sound(List<SoundEffect> soundeffects)
        {
            this.list = soundeffects;
        }        

        public void GunSound()
        {
            this.list[0].Play();
        }

        public void ZombieDeadSound()
        {
            this.list[1].Play();
        }
    }
}
