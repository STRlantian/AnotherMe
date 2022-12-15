using STRlantian.Factory;
using System.Collections;
using System.Threading;
using UnityEngine;

namespace Assets.STRlantian.Scripts.GameEffects.Audio
{
    public class MusicInOut : MonoBehaviour
    {
        public AudioSource au;
        public int wait = 3;
        private float vol;
        private void Start()
        {
            ASettingFactory.LoadSettings();
            float percent = ASettingFactory.GetSettings(ASettingFactory.MUSIC);
            vol = 0.25f * percent / 100;
            au.volume = 0;
            VolumeUp(vol);
        }

        private void OnDisable()
        {
            VolumeDown(0);
        }

        public void VolumeUp(float to)
        {
            StartCoroutine(SlideVolumeUp(to));
        }

        public void VolumeDown(float to)
        {
            StartCoroutine(SlideVolumeDown(to));
        }
        private IEnumerator SlideVolumeUp(float to)
        {
            while(au.volume < to)
            {
                au.volume += 0.0025f;
                Thread.Sleep(wait);
                yield return null;
            }
        }

        private IEnumerator SlideVolumeDown(float to)
        {
            while(au.volume > to)
            {
                au.volume -= 0.0025f;
                Thread.Sleep(wait);
                yield return null;
            }
        }
    }
}