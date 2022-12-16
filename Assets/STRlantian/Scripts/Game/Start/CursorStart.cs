using Krivodeling.UI.Effects;
using STRlantian.Factory;
using STRlantian.GamePlay.KeyBinds;
using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CursorStart : MonoBehaviour
{
    public bool SAFE = true;
    public static bool isOptPage = false;

    [SerializeField]
    private GameObject start;
    [SerializeField] 
    private GameObject option;
    [SerializeField]
    private Rigidbody2D cursor;
    [SerializeField] 
    private Animator sAnim, oAnim;
    private bool _isContinuable = false;

    private static readonly float[] _startXList = {-14.3f, -3.5f, 7.5f};

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
        if (!ASettingFactory.CheckSettings())
        {
            ASettingFactory.CreateSettings();
        }
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
                SceneManager.LoadScene("IntroScene");
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

    private void LoadOption()
    {
        if(!isOptPage)
        {
            StartCoroutine(SetBoolean());
            GameObject.Find("Blur").GetComponent<UIBlur>().BeginBlur(2);
            isOptPage = true;
            cursor.position = new Vector2(_startXList[0], cursor.position.y);
        }
    }

    private IEnumerator SetBoolean()
    {
        sAnim.SetBool("ShowStartPage", false);
        oAnim.SetBool("ShowStartPage", false);
        sAnim.SetBool("ShowOptionPage", true);
        oAnim.SetBool("ShowOptionPage", true);
        yield return null;
    }
}
