using System.Collections;
using UnityEngine;

namespace STRlantian.VisualEffect
{
    public class VisualEffect
    {
        public static void SetAllVisible(bool v, GameObject[] objects)
        {
            float change = (float)(v ? -0.05f : 0.05f);
            foreach (GameObject o in objects)
            {
                Color c = o.GetComponent<SpriteRenderer>().color;
                while (c.a > 0)
                {
                    o.GetComponent<SpriteRenderer>().color = new Color(c.r, c.g, c.b, c.a + change);
                }
            }
        }
    }
}