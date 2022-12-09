using UnityEngine;
using STRlantian.Factory;
using STRlantian.Play.KeyBinds;

public class SliderAudio : MonoBehaviour
{
    //在设置界面的两个滑块
    public Rigidbody2D bodyMusic;
    public Rigidbody2D bodyEffect;
    public Rigidbody2D cursor;
    public static byte musVol, effVol;
    private const float _MAXV = 13.5f;
    private const float _MINV = -1f;

    void Start()
    {
        InitSlider();
    }

    void Update()
    {
        SliderCheck();
    }

    public void InitSlider()
    {
        byte mus = ASettingFactory.GetSettings(ASettingFactory.MUSIC);
        byte eff = ASettingFactory.GetSettings(ASettingFactory.EFFECT);
        float leng = _MAXV - _MINV;
        bodyMusic.position = new Vector2(mus / 100f * leng + _MINV, bodyMusic.position.y);
        bodyEffect.position = new Vector2(eff / 100f * leng + _MINV, bodyEffect.position.y);
        musVol = mus;
        effVol = eff;
    }

    private void SliderCheck()
    {
        float curY = cursor.position.y;
        if (curY == 11f)
        {
            musVol = ApplyKeySlider(_MAXV, _MINV, bodyMusic);
        }
        else if (curY == 6.5f)
        {
            effVol = ApplyKeySlider(_MAXV, _MINV, bodyEffect);
        }
    }

    private byte ApplyKeySlider(float max, float min, Rigidbody2D slider)
    {
        if (Input.GetKey(AKey.right)
         || Input.GetKey(AKey.left))
        {
            int dire = Input.GetKey(AKey.left) ? -1 : 1;
            float curX = slider.position.x;
            if (min <= curX
            && curX <= max)
            {
                float tmp = Time.deltaTime * dire * (max - min) / 100;
                float nowX = (curX + tmp > max) ? max : ((curX + tmp < min) ? min : curX + tmp);
                slider.position = new Vector2(nowX, slider.position.y);
            }
        }
        return (byte)(100 * ((slider.position.x - min) / (max - min)));
    }
}
