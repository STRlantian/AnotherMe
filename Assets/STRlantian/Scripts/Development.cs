using System.Collections;
using UnityEngine;

namespace STRlantian
{
    public class Development
    {
        public static void WorkInProgress()
        {
            GameObject.Find("WIP").GetComponent<Transform>().position = new Vector2(0, 0);
        }
    }
}