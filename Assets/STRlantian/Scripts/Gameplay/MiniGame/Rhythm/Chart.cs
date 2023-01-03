using UnityEngine;
using System;
using System.IO;

namespace STRlantian.Gameplay.MiniGame.Rhythm
{
    public class Chart : MonoBehaviour
    {
        [SerializeField]
        private int bpm;
        [SerializeField]
        private int length; //Seconds
        [SerializeField]
        private const string songName;

        private File chartFile;

        //use a Map as chart

        void Start()
        {
            LoadChart(Application.dataPath + "\\" + songName);
        }

        public PlayChart()
        {

        }

        private void LoadChart(string path)
        {
            
        }
    }
}