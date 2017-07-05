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
            this.list[0].Play(0.1f, 0.0f, 0.0f);
        }

        public void ZombieDeadSound() //works
        {
            this.list[1].Play();
        }

        public void PlayerDeadSound() //works
        {
            this.list[2].Play();
        }

        public void UnicornSound() //works
        {
            this.list[3].Play();
        }

        public void UnicornDeadSound() //works
        {
            this.list[4].Play();
        }

        public void VictorySound() //works
        {
            
            this.list[5].Play(1.0f, 0.0f, 0.0f);
        }

        public void GameOverSound() //works
        {
            this.list[6].Play();
        }

        public void background_music()
        {
            this.list[7].Play();
        }
        public void background_quit()
        {
            this.list[7].Dispose();
        }
    }
}
