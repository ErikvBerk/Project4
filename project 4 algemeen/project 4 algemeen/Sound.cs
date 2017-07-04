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

        public void GunSound() //works
        {
            this.list[0].Play();
        }

        public void ZombieDeadSound()
        {
            this.list[1].Play();
        }

        public void PlayerDeadSound()
        {
            this.list[2].Play();
        }

        public void UnicornSound()
        {
            this.list[3].Play();
        }

        public void UnicornDeadSound()
        {
            this.list[4].Play();
        }

        public void VictorySound() //implemented but not tested
        {
            this.list[5].Play();
        }

        public void GameOverSound()
        {
            this.list[6].Play();
        }
    }
}
