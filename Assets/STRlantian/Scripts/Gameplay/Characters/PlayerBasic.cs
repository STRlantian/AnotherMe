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

        private Vector2 moveDire;

        private void Start()
        {
            AKey.UpdateKey();
            moveDire = Vector2.zero;
            interactable = false;
        }

        private void Update()
        {
            transform.rotation = new Quaternion(0, 0, 0, transform.rotation.w);
            PlayerMove();
        }

        private void PlayerMove()
        {
            moveDire = Vector2.zero;

            if (Input.GetKey(AKey.up))
            {
                moveDire += Vector2.up;
            }
            if (Input.GetKey(AKey.down))
            {
                moveDire += Vector2.down;
            }
            if (Input.GetKey(AKey.left))
            {
                moveDire += Vector2.left;
            }
            if (Input.GetKey(AKey.right))
            {
                moveDire += Vector2.right;
            }

            sprAnim.SetFloat("moveX", moveDire.x);
            sprAnim.SetFloat("moveY", moveDire.y);
            transform.Translate(moveDire * speed * Time.deltaTime);
            UpdateMoveAnim();
        }
        private void UpdateMoveAnim()
        {
            if (Input.GetKeyUp(AKey.up))
            {
                rd.sprite = up;
            }
            if (Input.GetKeyUp(AKey.down))
            {
                rd.sprite = down;
            }
            if (Input.GetKeyUp(AKey.left))
            {
                rd.sprite = left;
            }
            if (Input.GetKeyUp(AKey.right))
            {
                rd.sprite = right;
            }
        }
    }
}
