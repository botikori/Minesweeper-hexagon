using System;

namespace Sweeper.Core.Data
{
    [Serializable]
    public class SaveData
    {
        public float MusicVolume;
        public float SoundEffectsVolume;
        

        public SaveData()
        {
            this.MusicVolume = 1;
            this.SoundEffectsVolume = 1;
        }
    }
}
