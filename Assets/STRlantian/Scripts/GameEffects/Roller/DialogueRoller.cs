using STRlantian.GamePlay.Characters;
using System;
using System.Collections;
using System.Threading;
using UnityEngine;

namespace STRlantian.Effects.Roller
{
    public class DialogueRoller : ARoller
    {
        [SerializeField]
        private string[] textsKey;
        [SerializeField]
        private string[] textsValue;
        [SerializeField]
        private DialogueBasic dia;
        private string[][] texts;
        private string[] _current;

        private void Awake()
        {
           
        }
        public void StartRoll(int which)
        {
            num = 0;
            _current = texts[which];
            StartCoroutine(Roll(_current[num]));
        }

        public void RegisterTexts(int code, string[] content)
        {
            texts[code] = content;
        }
        public void NextRoll()
        {
            num++;
            try
            {
                StartCoroutine(Roll(_current[num]));
            }catch(IndexOutOfRangeException)
            {
                num = 0;
                _current = null;
                mesh.text = null;
                dia.CloseDialogue();
            }
        }
        private IEnumerator Roll(string text)
        {
            mesh.text = null;
            for (int i = 0; i < text.Length; i++)
            {
                mesh.text += text.ToCharArray()[i];
                Thread.Sleep(wait);
                yield return null;
            }
        }
    }
}