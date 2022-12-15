using System;
using System.Threading;
using TMPro;
using UnityEngine;

namespace STRlantian.GamePlay.FPS
{
    public class FPSBoard : MonoBehaviour
    {
        public TextMeshPro mesh;

        private void Update()
        {
            Invoke("UpdFPS", 1f);
        }

        private void UpdFPS()
        {
            mesh.color = new Color(255, 255, 255, 255);
            string fps = ((int)(1 / Time.deltaTime)).ToString();
            if (Int32.Parse(fps) > 120)
            {
                mesh.color = new Color(0, 255, 0, 255);
                fps = "120+";
            }
            else if (Int32.Parse(fps) < 60)
            {
                mesh.color = new Color(255, 0, 0, 255);
                fps = "60-";
            }
            mesh.text = fps;
        }
    }
}
