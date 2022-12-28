using System;
using UnityEngine;
using UnityEngine.UI;

namespace STRlantian.GamePlay.FPS
{
    public class FPSBoard : MonoBehaviour
    {
        [SerializeField]
        private Text text;

        private void Update()
        {
            Invoke("UpdFPS", 1f);
        }

        private void UpdFPS()
        {
            text.color = new Color(255, 255, 255, 255);
            string fps = ((int)(1 / Time.deltaTime)).ToString();
            if (Int32.Parse(fps) > 120)
            {
                text.color = new Color(0, 255, 0, 255);
                fps = "120+";
            }
            else if (Int32.Parse(fps) < 60)
            {
                text.color = new Color(255, 0, 0, 255);
                fps = "60-";
            }
            text.text = fps;
        }
    }
}
