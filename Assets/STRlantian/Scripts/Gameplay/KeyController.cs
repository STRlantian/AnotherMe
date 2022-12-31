using UnityEngine;
using STRlantian.Util.Factory;

namespace STRlantian.GamePlay.KeyBinds
{
    public abstract class AKey
    { 
        public static KeyCode a, b, x, y, k1, k2, k3, k4, up, down, left, right;
        
        public static void UpdateKey()
        {
            int plan = ASettingFactory.GetSettings(ASettingFactory.BIND);
            Upd(plan);
        }

        public static void UpdateKey(int plan)
        {
            Upd(plan);
        }

        private static void Upd(int plan)
        {
            if (plan == 0)
            {
                a = KeyCode.Z;
                b = KeyCode.X;
                x = KeyCode.A;
                y = KeyCode.S;
                up = KeyCode.UpArrow;
                down = KeyCode.DownArrow;
                left = KeyCode.LeftArrow;
                right = KeyCode.RightArrow;
                k1 = KeyCode.D;
                k2 = KeyCode.F;
                k3 = KeyCode.J;
                k4 = KeyCode.K;
            }
            else if (plan == 1)
            {
                a = KeyCode.J;
                b = KeyCode.K;
                x = KeyCode.U;
                y = KeyCode.I;
                up = KeyCode.W;
                down = KeyCode.S;
                left = KeyCode.A;
                right = KeyCode.D;
                k1 = KeyCode.Z;
                k2 = KeyCode.X;
                k3 = KeyCode.B;
                k4 = KeyCode.N;
            }
        }
    }
}