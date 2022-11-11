using STRlantian.Factory;
using STRlantian.KeyController;
using STRlantian.VisualEffect;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CursorStart : MonoBehaviour
{
    //在开始界面的指针
    public Rigidbody2D body;
    public Animator[] startShaker;
    public GameObject[] objects;
    private bool isContinuable = false;
    private readonly float[] startXList = {
    -14.7f,
    -2.7f,
    7.7f};
       

    void Update()
    {
        ACursorFactory.CursorMove(startXList, body, ACursorFactory.CHOICE_X);
        CursorCheck();
    }
    
    void Start()
    {
        VisualEffect.SetAllVisible(true, objects);
        if(!ASettingFactory.CheckSettings())
        {
            ASettingFactory.CreateSettings();
        }
        ASettingFactory.LoadSettings();
        byte[] settings = ASettingFactory.GetSettings();
        AKey.UpdateKey((byte) settings.GetValue(ASettingFactory.BIND));
        AShakerFactory.EnableShakers(startShaker);
    }

    private void CursorCheck()
    {
        if (Input.GetKeyDown(AKey.a)
        || Input.GetKeyDown(AKey.b))
        {
            float curX = body.position.x;
            if (curX == startXList[0])
            {
                SceneManager.LoadScene("StartScene");
            }
            else if (curX == startXList[1])
            {
                if (isContinuable)
                {
                    //...
                }
            }
            else if (curX == startXList[2])
            {
                SceneManager.LoadScene("OptionScene");
            }
        }
    }
}
