using UnityEngine;
using STRlantian.Factory;
using STRlantian.KeyController;
using Krivodeling.UI.Effects;

public class CursorOpt : MonoBehaviour
{
    //在设置界面的指针
    public Rigidbody2D cursor;
    public GameObject option;
    public GameObject start;
    public GameObject check;
    public Animator[] shakers;
    public SpriteRenderer bindA, bindB;
    private static readonly float[] _yList = {11f, 6.5f, 1f, -4f, -10f};
    private static byte[] _tempList = new byte[4];

    void Start()
    {
        foreach(SpriteRenderer rd in option.GetComponentsInChildren<SpriteRenderer>())
        {
            rd.color = new Color(255, 255, 255, 0);
        }
        AShakerFactory.EnableShakers(shakers);
        option.GetComponent<RectTransform>().position = new Vector2(0, 30);
        _tempList = (byte[])ASettingFactory.GetSettings().Clone();

        if((byte) _tempList.GetValue(ASettingFactory.BIND) == 1)
        {
            bindA.color = new Color(255, 255, 255, 0);
            bindB.color = new Color(255, 255, 255, 255);
        }
        if((byte) _tempList.GetValue(ASettingFactory.SHAKE) == 1)
        {
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
                byte shake = (byte)(_tempList[ASettingFactory.SHAKE] == 0 ? 1 : 0);
                _tempList.SetValue(shake, ASettingFactory.SHAKE);
                AShakerFactory.EnableShakers(shakers, shake == 1);
                check.GetComponent<SpriteRenderer>().color = new Color(255, 255, 255, shake == 1 ? 255 : 0);
                //check.SetBool("keyDown", !check.GetBool("keyDown"));
            }
            else if (curY == _yList[ASettingFactory.BIND])
            {
                byte res = (byte)(_tempList[ASettingFactory.BIND] == 0 ? 1 : 0);
                _tempList.SetValue(res, ASettingFactory.BIND);
                AKey.UpdateKey(_tempList[ASettingFactory.BIND]);
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
            GameObject.Find("Blur").GetComponent<UIBlur>().EndBlur(2);
            /*
            Rigidbody2D[] optList = this.option.GetComponentsInChildren<Rigidbody2D>();
            foreach(Rigidbody2D option in optList)
            {
                for (float mul = 1f; option.position.y < 30; mul++)
                {
                    option.position = new Vector2(0, mul * mul);
                }
                option.position = new Vector2(0, 30);
            }

            Rigidbody2D[] startList = this.start.GetComponentsInChildren<Rigidbody2D>();
            foreach(Rigidbody2D start in startList)
            {
                start.position = new Vector2(start.position.x, -20);
                for (float i = 2f; start.position.y < 0; i--)
                {
                    start.position = new Vector2(0, -20f + i * i);
                }
                start.position = new Vector2(0, 0);
            }

            */
            option.transform.position = new Vector2(0, 30);
            start.transform.position = new Vector2(0, 0);
            CursorStart.isOptPage = false;
        }
    }
}
