using UnityEngine;

namespace Sweeper.Core.Data
{
    public class DataManager : MonoBehaviour
    {
        private SaveData _saveData;
        private JsonSaver _jsonSaver;

        public float MusicVolume
        {
            get { return _saveData.MusicVolume; }
            set { _saveData.MusicVolume = value; }
        }

        public float SoundEffectsVolume
        {
            get { return _saveData.SoundEffectsVolume; }
            set { _saveData.SoundEffectsVolume = value; }
        }

        private void Awake()
        {
            _saveData = new SaveData();
            _jsonSaver = new JsonSaver();
        }

        public void Save(){
            _jsonSaver.Save(_saveData);
        }

        public void Load(){
            _jsonSaver.Load(_saveData);
        }
    }
}
