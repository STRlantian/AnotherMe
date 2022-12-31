using UnityEngine;

namespace STRlantian.Util.Factory
{
    public abstract class AShakerFactory
    {
        public static void EnableShakers(Animator[] shakers)
        {
            if (ASettingFactory.GetSettings(ASettingFactory.SHAKE) == 1)
            {
                foreach (Animator i in shakers)
                {
                    i.SetBool("isShakeEnabled", true);
                }
            }
            else
            {
                foreach (Animator i in shakers)
                {
                    i.SetBool("isShakeEnabled", false);
                }
            }
        }

        public static void EnableShakers(Animator[] shakers, bool v)
        {
            foreach (Animator i in shakers)
            {
                i.SetBool("isShakeEnabled", v);
            }
        }
    }
}
