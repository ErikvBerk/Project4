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

        public void ZombieDeadSound() //being weird because of update in switch_levels
        {
            this.list[1].Play();
        }

        public void PlayerDeadSound() //implemented but not tested
        {
            this.list[2].Play();
        }

        public void UnicornSound() //maybe 
        {
            this.list[3].Play();
        }

        public void UnicornDeadSound() //implemented but not tested
        {
            this.list[4].Play();
        }

        public void VictorySound() //implemented but not tested
        {
            this.list[5].Play();
        }

        public void GameOverSound() //implemented but not tested 
        {
            this.list[6].Play();
        }
    }
}
