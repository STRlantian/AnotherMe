using Krivodeling.UI.Effects;
using STRlantian.Util.Factory;
using STRlantian.GamePlay.KeyBinds;
using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CursorStart : MonoBehaviour
{
    public const bool SAFE = true; 
    public static bool inAddonMode = false;

    [SerializeField] 
    private GameObject start; 
    [SerializeField] 
    private GameObject option;
    [SerializeField] 
    private Animator sAnim, oAnim; 

    private bool isContinuable = false;
    private static readonly float[] startXList = {-14.3f, -3.5f, 7.5f};

    void Update() 
    {
        if(!inAddonMode)
        {
            ACursorFactory.CursorMove(startXList, transform, ACursorFactory.CHOICE_X);
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
            float curX = transform.position.x;
            if (curX == startXList[0])
            {
                GameObject.Find("Blur").GetComponent<UIBlur>().BeginBlur(2);
                SceneManager.LoadScene("IntroScene");
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
                LoadAddons();
            }
        }
    }

    private void LoadAddons()
    {
        if(!inAddonMode)
        {
            StartCoroutine(SetBoolean());
            GameObject.Find("Blur").GetComponent<UIBlur>().BeginBlur(2);
            inAddonMode = true;
            gameObject.SetActive(false);
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
