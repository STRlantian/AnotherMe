using Krivodeling.UI.Effects;
using STRlantian;
using STRlantian.Factory;
using STRlantian.KeyController;
using System.Collections;
using System.ComponentModel;
using System.Net;
using System.Threading;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CursorStart : MonoBehaviour
{
    //在开始界面的指针
    public bool SAFE = true;
    public GameObject start;
    public GameObject option;
    public Rigidbody2D cursor;
    public static bool isOptPage = false;
    private Rigidbody2D[] startList, optList;
    private bool _isContinuable = false;
    static readonly float[] _startXList = {
    -14.3f,
    -3.5f,
    7.5f};
       

    void Update()
    {
        if(!isOptPage)
        {
            ACursorFactory.CursorMove(_startXList, cursor, ACursorFactory.CHOICE_X);
            CursorCheck();
        }
    }
    
    void Start()
    {
        startList = start.GetComponentsInChildren<Rigidbody2D>();
        optList = option.GetComponentsInChildren<Rigidbody2D>();

        if (!ASettingFactory.CheckSettings())
        {
            ASettingFactory.CreateSettings();
        }
        ASettingFactory.LoadSettings();
        byte[] settings = ASettingFactory.GetSettings();
        AKey.UpdateKey((byte) settings.GetValue(ASettingFactory.BIND));
    }

    private void CursorCheck()
    {
        if (Input.GetKeyDown(AKey.a)
        || Input.GetKeyDown(AKey.b))
        {
            float curX = cursor.position.x;
            if (curX == _startXList[0])
            {
                GameObject.Find("Blur").GetComponent<UIBlur>().BeginBlur(2);
                SpriteRenderer bg = GameObject.Find("BG").GetComponent<SpriteRenderer>();
                StartCoroutine(SmoothOut(bg));
                SceneManager.LoadScene("StartScene");
            }
            else if (curX == _startXList[1])
            {
                if (_isContinuable)
                {
                    //...
                }
            }
            else if (curX == _startXList[2])
            {
                LoadOption();
            }
        }
    }

    private IEnumerator SmoothOut(SpriteRenderer bg)
    {
        while (bg.color.a > 0)
        {
            bg.color = new Color(255, 255, 255, bg.color.a - 1);
            Thread.Sleep(5);
            yield return null;
        }
    }

    private void LoadOption()
    {
        if(!isOptPage)
        {
            //param start and option: GameObject
            GameObject.Find("Blur").GetComponent<UIBlur>().BeginBlur(2);
            foreach (Rigidbody2D start in startList)
            {
                StartCoroutine(SmoothFall(start, -20f));
            }

            foreach(Rigidbody2D option in optList)
            {
                StartCoroutine(SmoothFall(option, 0f));
                option.position = new Vector2(0, 0);
            }
            
            /*
            //WORK IN PROGRESS AAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAA
            Development.WorkInProgress();
            return;
            start.transform.position = new Vector2(0, -20);
            option.transform.position = new Vector2(0, 0);
            isOptPage = true;
            */
        }
    }

    private IEnumerator SmoothFall(Rigidbody2D body, float des)
    {
        body.gravityScale = 1;
        for (float i = 1; i > 0 && SAFE; i += 0.2F)
        {
            body.AddForce(new Vector2(i, 0), ForceMode2D.Force);
            if(body.position.y < des)
            {
                break;
            }
            Thread.Sleep(5);
            yield return null;
        }
        body.position = new Vector2(body.position.x, des);
        yield return null;
    }
}
