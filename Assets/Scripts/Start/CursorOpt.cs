using UnityEngine;
using STRlantian.Factory;
using STRlantian.KeyController;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using Unity.VisualScripting;
using System;

public class CursorOpt : MonoBehaviour
{
    //在设置界面的指针
    public Rigidbody2D body;
    public Animator[] optShaker;
    private static readonly float[] yList = {11f, 6f, 1f, -4f, -9f};
    private static byte[] tempList = new byte[4];

    void Start()
    {
        tempList = (byte[]) ASettingFactory.GetSettings().Clone();
        AShakerFactory.EnableShakers(optShaker);
    }
    void Update()
    {
        ACursorFactory.CursorMove(yList, body, ACursorFactory.CHOICE_Y);
        CursorCheck();
        CursorClick(body);
    }

    private void CursorCheck()
    {
        if (body.position.y == yList[4])
        {
            body.position = new Vector2(-6.5f, body.position.y);
        }
        else
        {
            body.position = new Vector2(-13f, body.position.y);
        }
    }
    private void CursorClick(Rigidbody2D body)
    {
        if (Input.GetKeyDown(AKey.a)
        || Input.GetKeyDown(AKey.b))
        {
            float curY = body.position.y;
            if (curY == yList[ASettingFactory.SHAKE])
            {
                byte shake = (byte)(tempList[ASettingFactory.SHAKE] == 0 ? 1 : 0);
                tempList.SetValue(shake, ASettingFactory.SHAKE);
                AShakerFactory.EnableShakers(optShaker, shake == 1 ? true : false);
            }
            else if (curY == yList[ASettingFactory.BIND])
            {
                tempList.SetValue((byte) (tempList[ASettingFactory.BIND] == 0 ? 1 : 0), ASettingFactory.BIND);
                AKey.UpdateKey(tempList[ASettingFactory.BIND]);
            }
            else if (curY == yList[4])
            {
                tempList.SetValue(SliderAudio.musVol, ASettingFactory.MUSIC);
                tempList.SetValue(SliderAudio.effVol, ASettingFactory.EFFECT);
                ASettingFactory.UpdateSettings(tempList);
                SceneManager.LoadScene("StartScene");
            }
        }
    }
}
