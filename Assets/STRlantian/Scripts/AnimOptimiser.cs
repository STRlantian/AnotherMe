using System.Collections;
using UnityEngine;

namespace STRlantian
{
    public class Movement
    {
        /*
        public static void SmoothMove(Rigidbody2D body, float time, float toX, float toY)
        {
            float x = body.position.x - toX;
            float y = body.position.y - toY;
            float num = Mathf.Abs(y / x);
            //0.05 for start and 0.1 for reverse
            for (float i = 0.05f; i > 0; i -= 0.01f)
            {
                body.position = new Vector2(body.position.x - i, body.position.y - num * i);
            }
            x += 0.3f;
            y += 0.3f;
            float velX = x / time;
            float velY = y / time;
            int tmp = 10;
            for (float i = time / 10; i > 0; i -= time / 100)
            {
                body.position = new Vector2(body.position.x + velX / tmp, body.position.y + velY / tmp);
                tmp--;
            }
            x = Mathf.Abs(x);
            y = Mathf.Abs(y);
            for(float i = 0; x > 0 && y > 0; i++)
            {
                body.position = new Vector2(body.position.x + velX, body.position.y + velY);
                x = x - velX;
                y = y - velY;
            }
            tmp = 10;
            for (float i = -time / 10; i > 0; i += time / 100)
            {
                body.position = new Vector2(body.position.x - velX / tmp, body.position.y - velY / tmp);
                tmp--;
            }
        }
        */
    }
}