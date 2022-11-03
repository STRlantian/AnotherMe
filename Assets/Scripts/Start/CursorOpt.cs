using UnityEngine;
using STRlantian.Factory;
using STRlantian.KeyController;
using System.Collections.Generic;
using UnityEngine.SceneManagement;

public class CursorOpt : MonoBehaviour
{
    public Rigidbody2D body;
    private static float[] yList = {11f, 6f, 1f, -4f, -9f};
    private static int[] tempList = new int[4];

    private void Start()
    {
        tempList = ASettingFactory.GetSettings();
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
    private static void CursorClick(Rigidbody2D body)
    {
        if (Input.GetKeyDown(AKey.a)
        || Input.GetKeyDown(AKey.b))
        {
            float curY = body.position.y;
            if (curY == yList[ASettingFactory.SHAKE])
            {
                tempList.SetValue(tempList[ASettingFactory.SHAKE] == 0 ? 1 : 0, ASettingFactory.SHAKE);
            }
            else if (curY == yList[ASettingFactory.BIND])
            {
                tempList.SetValue(tempList[ASettingFactory.BIND] == 0 ? 1 : 0, ASettingFactory.BIND);
                AKey.UpdateKey(tempList[ASettingFactory.BIND]);
            }
            else if (curY == yList[4])
            {
                tempList.SetValue(SliderAudio.musVol, ASettingFactory.MUSIC);
                tempList.SetValue(SliderAudio.effVol, ASettingFactory.EFFECT);
                ASettingFactory.UpdateSettings(tempList);
                tempList = new int[4];
                SceneManager.LoadScene("StartScene");
            }
        }
    }
}
