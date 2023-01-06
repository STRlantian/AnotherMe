using STRlantian.GamePlay.KeyBinds;
using System;
using UnityEngine;

namespace STRlantian.Util.Factory
{
    public abstract class ACursorFactory
    {
        public const int CHOICE_X = 0;
        public const int CHOICE_Y = 1;

        public static void CursorMove(float[] list, Transform body, int which)
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
                Debug.Log(exc);
                throw new Exception("Cursor is not at the right position");
            }
            //***
            KeyCode add = which == CHOICE_X ? AKey.left : AKey.up;
            KeyCode minus = which == CHOICE_X ? AKey.right : AKey.down;

            if(Input.GetKeyDown(minus)
                || Input.GetKeyDown(add))
            {
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
                        index = list.Length - 1;
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
    }
}
