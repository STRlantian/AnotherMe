using STRlantian.GamePlay.Characters;
using System;
using System.Collections;
using System.Threading;
using TMPro;
using UnityEngine;

namespace STRlantian.Effects.Roller.Dialogue
{
    public class DialogueRoller : MonoBehaviour
    {
        public TextMeshPro mesh;
        public int wait;
        public string[][] texts;
        public DialogueBasic dia;
        private int _num = 0;
        private string[] _current;

        public void StartRoll(int which)
        {
            _num = 0;
            _current = texts[which];
            StartCoroutine(Roll(_current[_num]));
        }

        public void RegisterTexts(int code, string[] content)
        {
            texts[code] = content;
        }
        public void NextRoll()
        {
            _num++;
            try
            {
                StartCoroutine(Roll(_current[_num]));
            }catch(IndexOutOfRangeException)
            {
                _num = 0;
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