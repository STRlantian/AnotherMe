using UnityEngine;
using STRlantian.GamePlay.MiniGame.Rhythm;

namespace STRlantian.Gameplay.MiniGame.Rhythm
{
    public class GameSong : MonoBehaviour
    {
        public isPlaying = false;

        [SerializeField]
        private AudioSource au;
        [SerializeField]
        private Chart chart;
        [SerializeField]
        private BGA bga;

        public StartPlay()
        {
            isPlaying = true;
            chart.PlayChart();
            bga.PlayBGA();
        }
    }
}