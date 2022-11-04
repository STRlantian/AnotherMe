using STRlantian.Factory;
using STRlantian.KeyController;
using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CursorStart : MonoBehaviour
{
    public Rigidbody2D body;
    public Animator anim;
    public Animator[] buttonAnim;

    private bool isContinuable = false;
    private float[] startYList = {
    -5.24f,
    -7.72f,
    -9.98f,
    -12.41f};
       

    void Update()
    {
        ACursorFactory.CursorMove(startYList, body, ACursorFactory.CHOICE_Y);
        CursorCheck();
    }

    void Start()
    {
        if(!ASettingFactory.CheckSettings())
        {
            ASettingFactory.CreateSettings();
        }
        else
        {
            ASettingFactory.LoadSettings();
        }
        byte[] settings = ASettingFactory.GetSettings();
        AKey.UpdateKey((byte) settings.GetValue(ASettingFactory.BIND));
        Debug.Log("Setting List" + settings[0]
            + "\n" + settings[1]
            + "\n" + settings[2]
            + "\n" + settings[3]
            + "\n===============\n");
    }
    private void CursorCheck()
    {
        if (Input.GetKeyDown(AKey.a)
        || Input.GetKeyDown(AKey.b))
        {
            float curY = body.position.y;
            if (curY == startYList[0])
            {
                SceneManager.LoadScene("IntroScene");
                
            }
            else if (curY == startYList[1])
            {
                //check if there is a save
                //if not then do not start
                if(isContinuable == true)
                {
                    //...
                }
            }
            else if (curY == startYList[2])
            {
                SceneManager.LoadScene("OptionScene");
            }
            else if (curY == startYList[3])
            {
                Application.Quit();
                UnityEditor.EditorApplication.isPlaying = false;
            }
        }
    }
}
