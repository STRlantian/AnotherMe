using STRlantian.Util.Factory;
using System.Collections;
using System.Threading;
using UnityEngine;
using UnityEngine.UI;

namespace STRlantian.GameEffects.Audio
{
    public class MusicPlayer : MonoBehaviour
    {
        [SerializeField]
        private AudioSource au;
        [SerializeField]
        private int wait = 3;
        [SerializeField]
        private Text alarm;
        [SerializeField]
        private string song;
        
        private float vol;

        private void Start()
        {
            alarm.text = "<b>" + song + "      </b>";
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
            while (au.volume < to)
            {
                au.volume += 0.0025f;
                Thread.Sleep(wait);
                yield return null;
            }
        }

        private IEnumerator SlideVolumeDown(float to)
        {
            while (au.volume > to)
            {
                au.volume -= 0.0025f;
                Thread.Sleep(wait);
                yield return null;
            }
        }
    }
}