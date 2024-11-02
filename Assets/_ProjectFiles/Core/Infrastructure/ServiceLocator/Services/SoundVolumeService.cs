using System;
using UnityEngine;

namespace _ProjectFiles.Core.Infrastructure.ServiceLocator.Services
{
    public class SoundService : IService
    {
        private const float MinVolume = 0f;
        private const float MaxVolume = 100f;
        private const string VolumeKey = "Volume";

        public event Action<float> OnValueUpdated;
        
        public float Volume
        {
            get
            {
                if(!PlayerPrefs.HasKey(VolumeKey))
                    PlayerPrefs.SetFloat(VolumeKey, MaxVolume);

                return PlayerPrefs.GetFloat(VolumeKey);
            }

            private set
            {
                float val = Mathf.Clamp(value, MinVolume, MaxVolume);
                PlayerPrefs.SetFloat(VolumeKey, val);
            }
        }   

        public void UpdateVolumeValue(float newValue)
        {
            Volume = newValue;
            OnValueUpdated?.Invoke(Volume);
        }
    }
}