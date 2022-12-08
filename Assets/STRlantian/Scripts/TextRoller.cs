﻿using System.Collections;
using System.Threading;
using TMPro;
using UnityEngine;

namespace STRlantian.TextRoller
{
    public class TextRoller : MonoBehaviour
    {
        public TextMeshPro mesh;
        public int speed;
        private int _num;
        private string[] _stringList;
        private void Start()
        {
            _num = 0;
        }
        public void SetList(string[] list)
        {
            _stringList = list;
        }
        public void NextRoll()
        {
            _num++;
            StartCoroutine(Roll(_stringList[_num]));
        }

        public void SetNull()
        {
            _num = 0;
            mesh.text = null;
        }
        public void RollText(int num)
        {
            _num = num;
            StartCoroutine(Roll(_stringList[num]));
        }
        private IEnumerator Roll(string text)
        {
            mesh.text = null;
            for (int i = 0; i < text.Length; i++) 
            {
                mesh.text += text.ToCharArray()[i];
                Thread.Sleep(speed);
                yield return null;
            }
        }
    }
}