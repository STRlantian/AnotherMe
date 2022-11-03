using STRlantian.KeyController;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using UnityEngine;

namespace STRlantian.Factory
{
    public abstract class ASaveFactory
    {
        private static String DIR = "C:\\zzzzzz\\AnotherMe\\" + Environment.UserName;
        private static String FILENAME = "save.txt";
        private static String PATH = DIR + "\\" + FILENAME;
        private static List<int> SAVELIST = new();

        private static String[] MODELCONTENT =
        {
            "#Do NOT edit unless you know what are these",
            "Scene:",
            "Item:",
            "RhyGame:",
        };

        public static void CreateSave()
        {
            Directory.CreateDirectory(DIR);
            File.Create(PATH);

        }

        public static void WriteInSave()
        {

        }

        private static void WriteInFile()
        {

        }
    }
    public abstract class ASettingFactory
    {
        private static int[] SETTINGLIST = new int[4];

        public const int MUSIC = 0, EFFECT = 1, SHAKE = 2, BIND = 3;

        private static String DIR = Application.dataPath;
        private static String FILENAME = "GameSettings.txt";
        private static String PATH = DIR + "\\" + FILENAME;

        private static String[] BASECONTENT = 
            {
                "#Do NOT edit unless you know what are these",
                "Music_Volumn:",   //Music Vol     de 100-100
                "Effect_Volumn:",   //Effect Vol    de 100-100
                "Shaking:",   //Shaking   true false
                "Bind:"            //Bind 0xz 1jkwasd
            };

        public static bool CheckSettings()
        {
            if(File.Exists(PATH))
            {
                String[] content = File.ReadAllLines(PATH);
                try
                {
                    bool[] tmp = new bool[4];
                    for(int i = 1; i <= 4; i++)
                    {
                        tmp.SetValue((content.GetValue(i).ToString()).Contains(BASECONTENT.GetValue(i).ToString()), i - 1);
                    }
                    return tmp[0] && tmp[1] && tmp[2] && tmp[3];
                }catch(IndexOutOfRangeException exc)
                {
                    Console.Write(exc);
                    return false;
                }
            }
            else
            {
                return false;
            }
        }
        public static int[] GetSettings()
        {
            if(CheckSettings())
            {
                return (int[]) SETTINGLIST.Clone();
            }
            else
            {
                CreateSettings();
                return GetSettings();
            }
        }
        public static int GetSettings(int which)
        {
            if (CheckSettings())
            {
                return (int) SETTINGLIST.GetValue(which);
            }
            else
            {
                CreateSettings();
                return GetSettings(which);
            }
        }

        public static void UpdateSettings(int[] v)
        {
            if (!CheckSettings())
            {
                CreateSettings();
                return;
            }
            else
            {
                String[] file = (String[]) BASECONTENT.Clone();
                for(int i = 1; i <= BASECONTENT.Length - 1; i++)
                {
                    file[i] += v[i - 1].ToString();
                }
                File.WriteAllLines(PATH, file);
                LoadSettings();
            }
        }

        public static void CreateSettings()
        {
            String[] dft = (String[]) BASECONTENT.Clone();
            dft[1] = dft[1] + "100";
            dft[2] = dft[2] + "100";
            dft[3] = dft[3] + "0";
            dft[4] = dft[4] + "0";

            Directory.CreateDirectory(DIR);
            File.Create(PATH).Close();
            File.WriteAllLines(PATH, dft);
        }

        public static void LoadSettings()
        {
            if (!CheckSettings())
            {
                CreateSettings();
            }
            String[] list = File.ReadAllLines(PATH);
            for (int i = 1; i <= 4; i++)
            {
                try
                {
                    String sub = list[i].Substring(list[i].IndexOf(':') + 1);
                    int v = Int32.Parse(sub);
                    SETTINGLIST.SetValue(v, i - 1);
                }catch (IndexOutOfRangeException exc)
                {
                    Console.WriteLine(exc);
                    Console.WriteLine("Settings went wrong, trying to fix");
                    CreateSettings();
                }
            }
        }
    }
    public abstract class ACursorFactory
    {
        public const int CHOICE_X = 0;
        public const int CHOICE_Y = 1;


        public static void CursorMove(float[] list, Rigidbody2D body, int which)
        {
            if (which != CHOICE_X
                && which != CHOICE_Y)
            {
                throw new Exception("Please choose 0(X) or 1(Y) in parametres");
            }
            int index = 0;
            try
            {
                if (which == 0)
                {
                    index = Array.IndexOf(list, body.position.x);
                }
                else if (which == 1)
                {
                    index = Array.IndexOf(list, body.position.y);
                }
            }
            catch (Exception exc)
            {
                Console.WriteLine(exc);
                throw new Exception("Cursor is not at the right position");
            }

            KeyCode add = which == CHOICE_X ? AKey.right : AKey.up;
            KeyCode minus = which == CHOICE_X ? AKey.left : AKey.down;

            if (Input.GetKeyDown(minus))
            {
                if (index >= 0
                && index <= list.Length - 2)
                {
                    index++;
                }
                else
                {
                    index = 0;
                }
            }
            else if (Input.GetKeyDown(add))
            {
                if (index >= 1
                    && index <= list.Length - 1)
                {
                    index--;
                }
                else
                {
                    index = 3;
                }
            }
            if (which == CHOICE_X)
            {
                body.position = new Vector2(list[index], body.position.y);
            }
            else if (which == CHOICE_Y)
            {
                body.position = new Vector2(body.position.x, list[index]);
            }
            else
            {
                throw new Exception("Congratulations, you made a bug");
            }
        }
    }
    public abstract class ASliderFactory
    {
        public static int ApplyKeySlider(float max, float min, Rigidbody2D slider, int which)
        {
            KeyCode add = which == ACursorFactory.CHOICE_X ? AKey.right : AKey.up;
            KeyCode minus = which == ACursorFactory.CHOICE_X ? AKey.left : AKey.down;
            if (Input.GetKey(add)
             || Input.GetKey(minus))
            {
                int dire = Input.GetKey(minus) ? -1 : 1;
                float curX = slider.position.x;
                if (min <= curX
                && curX <= max)
                {
                    float tmp = (dire * (max - min) / 100);
                    float nowX = (curX + tmp > max) ? max : ((curX + tmp < min) ? min : curX + tmp);
                    slider.position = new Vector2(nowX, slider.position.y);
                }
            }
            return (int)(100 * ((slider.position.x - min) / (max - min)));
        }
    }
}
