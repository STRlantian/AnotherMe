using System;
using System.IO;
using UnityEngine;

namespace STRlantian.Util.Factory
{
    public abstract class ASettingFactory
    {
        private static byte[] SETTINGLIST = new byte[4];

        public const int MUSIC = 0, EFFECT = 1, SHAKE = 2, BIND = 3;

        private static readonly String _DIR = Application.dataPath;
        private const String _FILENAME = "GameSettings.txt";
        private static readonly String _PATH = _DIR + "\\" + _FILENAME;

        private static readonly String[] _BASECONTENT =
            {
                "#Do NOT edit unless you know what are these",
                "Music_Volumn:",   //Music Vol     de 100-100
                "Effect_Volumn:",   //Effect Vol    de 100-100
                "Shaking:",   //Shaking   true false
                "Bind:"            //Bind 0xz 1jkwasd
            };

        public static bool CheckSettings()
        {
            if (File.Exists(_PATH))
            {
                String[] content = File.ReadAllLines(_PATH);
                try
                {
                    bool[] tmp = new bool[4];
                    for (int i = 1; i <= 4; i++)
                    {
                        tmp.SetValue(content.GetValue(i).ToString().Contains(_BASECONTENT.GetValue(i).ToString()), i - 1);
                    }
                    return tmp[0] && tmp[1] && tmp[2] && tmp[3];
                }
                catch (IndexOutOfRangeException exc)
                {
                    Debug.Log(exc);
                    return false;
                }
            }
            else
            {
                return false;
            }
        }
        public static byte[] GetSettings()
        {
            if (CheckSettings())
            {
                return (byte[])SETTINGLIST.Clone();
            }
            else
            {
                CreateSettings();
                return GetSettings();
            }
        }
        public static byte GetSettings(int which)
        {
            if (CheckSettings())
            {
                return (byte)SETTINGLIST.GetValue(which);
            }
            else
            {
                CreateSettings();
                return GetSettings(which);
            }
        }

        public static void UpdateSettings(byte[] v)
        {
            if (!CheckSettings())
            {
                CreateSettings();
                return;
            }
            else
            {
                String[] file = (String[])_BASECONTENT.Clone();
                for (int i = 1; i <= _BASECONTENT.Length - 1; i++)
                {
                    file[i] += v[i - 1].ToString();
                    SETTINGLIST.SetValue(v[i - 1], i - 1);
                }
                File.WriteAllLines(_PATH, file);
                LoadSettings();
            }
        }

        public static void CreateSettings()
        {
            String[] dft = (String[])_BASECONTENT.Clone();
            dft[1] = dft[1] + "100";
            dft[2] = dft[2] + "100";
            dft[3] = dft[3] + "0";
            dft[4] = dft[4] + "0";

            Directory.CreateDirectory(_DIR);
            File.Create(_PATH).Close();
            File.WriteAllLines(_PATH, dft);
        }

        public static void LoadSettings()
        {
            if (!CheckSettings())
            {
                CreateSettings();
            }
            String[] list = File.ReadAllLines(_PATH);
            for (int i = 1; i <= 4; i++)
            {
                try
                {
                    String sub = list[i].Substring(list[i].IndexOf(':') + 1);
                    byte v = Byte.Parse(sub);
                    SETTINGLIST.SetValue(v, i - 1);
                }
                catch (IndexOutOfRangeException exc)
                {
                    Debug.Log(exc);
                    Debug.Log("Settings went wrong, trying to fix");
                    CreateSettings();
                }
            }
        }
    }
}
