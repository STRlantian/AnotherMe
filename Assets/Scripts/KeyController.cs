using UnityEngine;

namespace STRlantian.KeyController
{
    public abstract class AKey
    { 
        public static KeyCode a, b, up, down, left, right;
        
        public static void UpdateKey(int plan)
        {
            if (plan == 0)
            {
                a = KeyCode.Z;
                b = KeyCode.X;
                up = KeyCode.UpArrow;
                down = KeyCode.DownArrow;
                left = KeyCode.LeftArrow;
                right = KeyCode.RightArrow;
            }
            else if (plan == 1)
            {
                a = KeyCode.J;
                b = KeyCode.K;
                up = KeyCode.W;
                down = KeyCode.S;
                left = KeyCode.A;
                right = KeyCode.D;
            }
        }
    }
}