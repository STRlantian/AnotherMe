using System.Collections;
using System.Threading;
using TMPro;
using UnityEngine;

namespace STRlantian
{
    public class TextRoller : MonoBehaviour
    {
        private string text;
        public TextMeshPro mesh;
        private void Start()
        {
            text = mesh.text;
            StartRoll();
        }
        public void StartRoll()
        {
            StartCoroutine(Roll());
        }
    
        private IEnumerator Roll()
        {
            mesh.text = null;
            for(int i = 0; i < text.Length; i++) 
            {
                mesh.text += text.ToCharArray()[i];
                Thread.Sleep(5);
                yield return null;
            }
        }
    }
}