using STRlantian.GamePlay.KeyBinds;
using UnityEngine;

namespace STRlantian.GamePlay.Characters
{
    public class PlayerBasic : NPCBasic
    {
        public Transform bg;
        public float speed = 5;

        private void Start()
        {
            AKey.UpdateKey();
            interactable = false;
        }

        private void Update()
        {
            if(!Input.GetKey(AKey.up)
                && !Input.GetKey(AKey.down)
                && !Input.GetKey(AKey.left)
                && !Input.GetKey(AKey.right))
            {
                sprAnim.SetBool("moveUp", false);
                sprAnim.SetBool("moveDown", false);
                sprAnim.SetBool("moveLeft", false);
                sprAnim.SetBool("moveRight", false);
            }
            else
            {
                if (Input.GetKey(AKey.up))
                {
                    PlayerMoveVer(1);
                }
                if (Input.GetKey(AKey.down))
                {
                    PlayerMoveVer(-1);
                }
                if (Input.GetKey(AKey.left))
                {
                    PlayerMoveHor(-1);
                }
                if (Input.GetKey(AKey.right))
                {
                    PlayerMoveHor(1);
                }
            }
            if(Input.GetKeyUp(AKey.up))
            {
                SetMoveAnim(0, false);
            }
            if (Input.GetKeyUp(AKey.down))
            {
                SetMoveAnim(1, false);
            }
            if (Input.GetKeyUp(AKey.left))
            {
                SetMoveAnim(2, false);
            }
            if (Input.GetKeyUp(AKey.right))
            {
                SetMoveAnim(3, false);
            }
        }

        private void SetMoveAnim(int i, bool b)
        {
            switch(i)
            {
                case 0:
                    sprAnim.SetBool("moveUp", b);
                    break;
                case 1:
                    sprAnim.SetBool("moveDown", b);
                    break;
                case 2:
                    sprAnim.SetBool("moveLeft", b);
                    break;
                case 3:
                    sprAnim.SetBool("moveRight", b);
                    break;
            }
        }
        private void PlayerMoveVer(int dire) //1 for up, -1 for down
        {
            if(dire == 1)
            {
                rd.sprite = up;
                SetMoveAnim(0, true);
                SetMoveAnim(1, false);
            }
            else
            {
                rd.sprite = down;
                SetMoveAnim(0, false);
                SetMoveAnim(1, true);
            }
            bg.position = new Vector2(bg.position.x, bg.position.y + speed * dire * -1 * Time.deltaTime); //Background turns
        }

        private void PlayerMoveHor(int dire) //1 for right, -1 for left
        {
            if (dire == 1)
            {
                rd.sprite = right;
                SetMoveAnim(2, false);
                SetMoveAnim(3, true);
            }
            else
            {
                rd.sprite = left;
                SetMoveAnim(2, true);
                SetMoveAnim(3, false);
            }
            bg.position = new Vector2(bg.position.x + speed * dire * -1 * Time.deltaTime, bg.position.y);
        }
    }
}
