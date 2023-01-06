using UnityEngine;
using STRlantian.GamePlay.KeyBinds;
using Krivodeling.UI.Effects;
using STRlantian.Util.Factory;
using System.Collections;
using Unity.VisualScripting;
using System.Text;
using System.Data;

public class CursorOpt : MonoBehaviour
{
    [SerializeField] 
    private GameObject option;
    [SerializeField] 
    private GameObject start;
    [SerializeField] 
    private GameObject check;
    [SerializeField]
    private Animator sAnim, oAnim;
    [SerializeField] 
    private SpriteRenderer bindA, bindB;

    private static readonly float[] yList = {11f, 6.5f, 1f, -4f, -10f};
    private static byte[] tempList = new byte[4];

    void Start()
    {
        option.GetComponent<RectTransform>().position = new Vector2(0, 28);
        ASettingFactory.LoadSettings();
        tempList = (byte[])ASettingFactory.GetSettings().Clone();
        byte i = 0;
        foreach (var ele in tempList)
        {
            StringBuilder b = new StringBuilder("Settings param ");
            b.Append(i);
            b.Append(": ");
            b.Append(ele);
            Debug.Log(b);
            i++;
        }

        AKey.UpdateKey(0);
        if((byte) tempList.GetValue(ASettingFactory.BIND) == 1)
        {
            AKey.UpdateKey(1);
            bindA.color = new Color(255, 255, 255, 0);
            bindB.color = new Color(255, 255, 255, 255);
        }
        if((byte) tempList.GetValue(ASettingFactory.FPS) == 1)
        {
        }
    }
    void Update()
    {
        if(CursorStart.inAddonMode)
        {
            ACursorFactory.CursorMove(yList, transform, ACursorFactory.CHOICE_Y);
            CursorCheck();
            CursorClick();
        }
    }

    private void CursorCheck()
    {
        if (transform.position.y == yList[4])
        {
            transform.position = new Vector2(-6.5f, transform.position.y);
        }
        else
        {
            transform.position = new Vector2(-13f, transform.position.y);
        }
    }
    private void CursorClick()
    {
        if (Input.GetKeyDown(AKey.a)
        || Input.GetKeyDown(AKey.b))
        {
            float curY = transform.position.y;
            if(curY == yList[ASettingFactory.FPS])
            {

            }
            else if (curY == yList[ASettingFactory.BIND])
            {
                byte res = (byte)(tempList[ASettingFactory.BIND] == 0 ? 1 : 0);
                tempList.SetValue(res, ASettingFactory.BIND);
                AKey.UpdateKey(res);
                if (res == 1)
                {
                    bindA.color = new Color(255, 255, 255, 0);
                    bindB.color = new Color(255, 255, 255, 255);
                }
                else
                {
                    bindA.color = new Color(255, 255, 255, 255);
                    bindB.color = new Color(255, 255, 255, 0);
                }
            }
            else if (curY == yList[4])
            {
                tempList.SetValue(SliderAudio.musVol, ASettingFactory.MUSIC);
                tempList.SetValue(SliderAudio.effVol, ASettingFactory.EFFECT);
                ASettingFactory.UpdateSettings(tempList);
                LoadStart();
            }
        }
    }

    private void LoadStart()
    {
        if(CursorStart.inAddonMode)
        {
            StartCoroutine(SetBoolean());
            GameObject.Find("Blur").GetComponent<UIBlur>().EndBlur(2);
            CursorStart.inAddonMode = false;
        }
    }

    private IEnumerator SetBoolean()
    {
        transform.position = new Vector2(-14.3f, -20f);
        sAnim.SetBool("ShowOptionPage", false);
        oAnim.SetBool("ShowOptionPage", false);
        oAnim.SetBool("ShowStartPage", true);
        sAnim.SetBool("ShowStartPage", true);
        yield return null;
    }
}
