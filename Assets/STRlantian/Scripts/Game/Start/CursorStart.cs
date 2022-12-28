/*
本文件作为一个示例
在上面和下面这两个东西括起来的是注释
*/
using Krivodeling.UI.Effects;
using STRlantian.Tools.Factory;
using STRlantian.GamePlay.KeyBinds;
using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
//引入命名空间部分 -------- 这样用//后面的内容也是注释
public class CursorStart : MonoBehaviour //冒号的作用: 继承
    //MonoBehaviour是一个Unity库的类 继承这个类表示现在这个类可以被附着在Unity种的GameObject上
{
    public const bool SAFE = true; //public的变量 
    public static bool isOptPage = false; //public static的bool变量

    [SerializeField] //SerializeField表示会在Unity中显示的变量 即可以通过Unity Editor进行直接修改赋值 public的变量也可以
    private GameObject start; //GameObject 是Unity中的游戏对象
    [SerializeField] //所以SerializeField只能用于private和protected变量 而且不能用于static const readonly等变量
    private GameObject option;
    [SerializeField]
    private Rigidbody2D cursor; //Rigidbody2D 是Unity中游戏对象的组件(Component)之一
    [SerializeField] 
    private Animator sAnim, oAnim; //Animator同上
    private bool _isContinuable = false;

    private static readonly float[] _startXList = {-14.3f, -3.5f, 7.5f};

    void Update() //Update方法会在每一帧都被调用
    {
        if(!isOptPage)
        {
            ACursorFactory.CursorMove(_startXList, cursor, ACursorFactory.CHOICE_X);
            CursorCheck();
        }
    }

    void Start() //Start方法会在第一帧(游戏开始) 被调用
    {
        if (!ASettingFactory.CheckSettings())
        {
            ASettingFactory.CreateSettings();
        }
    }

    private void CursorCheck() //一个private的 没有返回值的方法
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
