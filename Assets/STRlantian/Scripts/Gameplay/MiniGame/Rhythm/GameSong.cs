using UnityEngine;

namespace STRlantian.Gameplay.MiniGame.Rhythm
{
    public class GameSong : MonoBehaviour
    {
        public bool isPlaying = false;

        [SerializeField]
        private AudioSource au;
        [SerializeField]
        private Chart chart;
        [SerializeField]
        private BGA bga;

        public void StartPlay()
        {
            isPlaying = true;
            chart.PlayChart();
            bga.PlayBGA();
        }
    }
}