using UnityEngine;
using STRlantian.Factory;

public class SliderAudio : MonoBehaviour
{
    public Rigidbody2D bodyMusic;
    public Rigidbody2D bodyEffect;
    public Rigidbody2D cursor;
    public static int musVol, effVol;

    private const float MAXV = 13.5f;
    private const float MINV = -1f;

    void Start()
    {
        int mus = (int) ASettingFactory.GetSettings().GetValue(ASettingFactory.MUSIC);
        int eff = (int) ASettingFactory.GetSettings().GetValue(ASettingFactory.EFFECT);
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
            musVol = ASliderFactory.ApplyKeySlider(MAXV, MINV, bodyMusic, ACursorFactory.CHOICE_X);
        }
        else if (curY == 6f)
        {
            effVol = ASliderFactory.ApplyKeySlider(MAXV, MINV, bodyEffect, ACursorFactory.CHOICE_X);
        }
    }
}
