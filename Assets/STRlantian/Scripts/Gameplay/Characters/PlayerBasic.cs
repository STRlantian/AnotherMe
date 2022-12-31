using STRlantian.GamePlay.Characters;
using STRlantian.GamePlay.KeyBinds;
using UnityEngine;

namespace STRlantian.GamePlay.Characters
{
    public class PlayerBasic : NPCBasic
    {
        public float speed = 5;
        public bool isMoving;

        [SerializeField]
        private bool controlable;

        private void Start()
        {
            AKey.UpdateKey();
            interactable = false;
        }

        private void Update()
        {
            transform.rotation = new Quaternion(0, 0, 0, transform.rotation.w);
            if(!Input.GetKey(AKey.up)
                && !Input.GetKey(AKey.down)
                && !Input.GetKey(AKey.left)
                && !Input.GetKey(AKey.right))
            {
                sprAnim.SetBool("moveUp", false);
                sprAnim.SetBool("moveDown", false);
                sprAnim.SetBool("moveLeft", false);
                sprAnim.SetBool("moveRight", false);
                isMoving = false;
                body.velocity = new Vector2(0, 0);
            }
            else
            {
                isMoving = true;
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
                body.velocity = new Vector2(body.velocity.x, 0);
                SetMoveAnim(0, false);
            }
            if (Input.GetKeyUp(AKey.down))
            {
                body.velocity = new Vector2(body.velocity.x, 0);
                SetMoveAnim(1, false);
            }
            if (Input.GetKeyUp(AKey.left))
            {
                body.velocity = new Vector2(0, body.velocity.y);
                SetMoveAnim(2, false);
            }
            if (Input.GetKeyUp(AKey.right))
            {
                body.velocity = new Vector2(0, body.velocity.y);
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
                SetMoveAnim(0, true);
                SetMoveAnim(1, false);
                sprAnim.SetInteger("facing", 1);
            }
            else
            {
                SetMoveAnim(0, false);
                SetMoveAnim(1, true);
                sprAnim.SetInteger("facing", 0);
            }
            body.velocity = new Vector2(body.velocity.x, speed * dire);
        }

        private void PlayerMoveHor(int dire) //1 for right, -1 for left
        {
            if (dire == 1)
            {
                SetMoveAnim(2, false);
                SetMoveAnim(3, true);
                sprAnim.SetInteger("facing", 3);
            }
            else
            {
                SetMoveAnim(2, true);
                SetMoveAnim(3, false);
                sprAnim.SetInteger("facing", 2);
            }
            body.velocity = new Vector2(speed * dire, body.velocity.y);
        }
    }
}
