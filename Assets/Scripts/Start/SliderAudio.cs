using UnityEngine;
using STRlantian.Factory;
using STRlantian.KeyController;

public class SliderAudio : MonoBehaviour
{
    public Rigidbody2D bodyMusic;
    public Rigidbody2D bodyEffect;
    public Rigidbody2D cursor;
    public static byte musVol, effVol;

    private const float MAXV = 13.5f;
    private const float MINV = -1f;

    void Start()
    {
        byte mus = ASettingFactory.GetSettings(ASettingFactory.MUSIC);
        byte eff = ASettingFactory.GetSettings(ASettingFactory.EFFECT);
        float leng = MAXV - MINV;
        float musLeng = (mus / 100) * leng + MINV;
        float effLeng = (eff / 100) * leng + MINV; 
        bodyMusic.position = new Vector2(musLeng, bodyMusic.position.y);
        bodyEffect.position = new Vector2(effLeng, bodyEffect.position.y);
        musVol = mus;
        effVol = eff;
    }

    void Update()
    {
        SliderCheck();
    }

    private void SliderCheck()
    {
        float curY = cursor.position.y;
        if (curY == 11f)
        {
            musVol = ApplyKeySlider(MAXV, MINV, bodyMusic);
        }
        else if (curY == 6f)
        {
            effVol = ApplyKeySlider(MAXV, MINV, bodyEffect);
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
                float tmp = (dire * (max - min) / 100);
                float nowX = (curX + tmp > max) ? max : ((curX + tmp < min) ? min : curX + tmp);
                slider.position = new Vector2(nowX, slider.position.y);
            }
        }
        return (byte)(100 * ((slider.position.x - min) / (max - min)));
    }
}
