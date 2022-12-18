using UnityEngine;
using STRlantian.GamePlay.KeyBinds;
using Krivodeling.UI.Effects;
using STRlantian.Factory;
using System.Collections;
using Unity.VisualScripting;
using System.Text;
using System.Data;

public class CursorOpt : MonoBehaviour
{
    [SerializeField]
    private Rigidbody2D cursor;
    [SerializeField] 
    private GameObject option;
    [SerializeField] 
    private GameObject start;
    [SerializeField] 
    private GameObject check;
    [SerializeField]
    private Animator sAnim, oAnim;
    [SerializeField] 
    private Animator[] shakers;
    [SerializeField] 
    private SpriteRenderer bindA, bindB;

    private static readonly float[] _yList = {11f, 6.5f, 1f, -4f, -10f};
    private static byte[] _tempList = new byte[4];

    void Start()
    {
        option.GetComponent<RectTransform>().position = new Vector2(0, 28);
        ASettingFactory.LoadSettings();
        _tempList = (byte[])ASettingFactory.GetSettings().Clone();
        byte i = 0;
        foreach (var ele in _tempList)
        {
            StringBuilder b = new StringBuilder("Settings param ");
            b.Append(i);
            b.Append(": ");
            b.Append(ele);
            Debug.Log(b);
            i++;
        }

        AKey.UpdateKey(0);
        if((byte) _tempList.GetValue(ASettingFactory.BIND) == 1)
        {
            AKey.UpdateKey(1);
            bindA.color = new Color(255, 255, 255, 0);
            bindB.color = new Color(255, 255, 255, 255);
        }
        if((byte) _tempList.GetValue(ASettingFactory.SHAKE) == 1)
        {
            AShakerFactory.EnableShakers(shakers);
            check.GetComponent<SpriteRenderer>().color = new Color(255, 255, 255, 255);
        }
    }
    void Update()
    {
        if(CursorStart.isOptPage)
        {
            ACursorFactory.CursorMove(_yList, cursor, ACursorFactory.CHOICE_Y);
            CursorCheck();
            CursorClick();
        }
    }

    private void CursorCheck()
    {
        if (cursor.position.y == _yList[4])
        {
            cursor.position = new Vector2(-6.5f, cursor.position.y);
        }
        else
        {
            cursor.position = new Vector2(-13f, cursor.position.y);
        }
    }
    private void CursorClick()
    {
        if (Input.GetKeyDown(AKey.a)
        || Input.GetKeyDown(AKey.b))
        {
            float curY = cursor.position.y;
            if (curY == _yList[ASettingFactory.SHAKE])
            {
                /*
                byte shake = (byte)(_tempList[ASettingFactory.SHAKE] == 0 ? 1 : 0);
                _tempList.SetValue(shake, ASettingFactory.SHAKE);
                AShakerFactory.EnableShakers(shakers, shake == 1);
                check.GetComponent<SpriteRenderer>().color = new Color(255, 255, 255, shake == 1 ? 255 : 0);
                //check.SetBool("keyDown", !check.GetBool("keyDown"));
                */
            }
            else if (curY == _yList[ASettingFactory.BIND])
            {
                byte res = (byte)(_tempList[ASettingFactory.BIND] == 0 ? 1 : 0);
                _tempList.SetValue(res, ASettingFactory.BIND);
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
            else if (curY == _yList[4])
            {
                _tempList.SetValue(SliderAudio.musVol, ASettingFactory.MUSIC);
                _tempList.SetValue(SliderAudio.effVol, ASettingFactory.EFFECT);
                ASettingFactory.UpdateSettings(_tempList);
                LoadStart();
            }
        }
    }

    private void LoadStart()
    {
        if(CursorStart.isOptPage)
        {
            StartCoroutine(SetBoolean());
            GameObject.Find("Blur").GetComponent<UIBlur>().EndBlur(2);
            CursorStart.isOptPage = false;
        }
    }

    private IEnumerator SetBoolean()
    {
        cursor.position = new Vector2(-14.3f, -20f);
        sAnim.SetBool("ShowOptionPage", false);
        oAnim.SetBool("ShowOptionPage", false);
        oAnim.SetBool("ShowStartPage", true);
        sAnim.SetBool("ShowStartPage", true);
        yield return null;
    }
}
