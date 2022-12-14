using System.Collections;
using System.Threading;
using UnityEngine;

namespace STRlantian.Effects.Roller
{
    public class TextRoller : ARoller
    {
        [SerializeField]
        private string[] _stringList;

        private void Start()
        {
            num = 0;
        }
        public void SetList(string[] list)
        {
            _stringList = list;
        }
        public void NextRoll()
        {
            num++;
            StartCoroutine(Roll(_stringList[num]));
        }

        public void SetNull()
        {
            num = 0;
            text.text = null;
        }
        public void RollText(int num)
        {
            this.num = num;
            StartCoroutine(Roll(_stringList[num]));
        }
        private IEnumerator Roll(string text)
        {
            base.text.text = null;
            for (int i = 0; i < text.Length; i++) 
            {
                base.text.text += text.ToCharArray()[i];
                Thread.Sleep(wait);
                yield return null;
            }
        }
    }
}