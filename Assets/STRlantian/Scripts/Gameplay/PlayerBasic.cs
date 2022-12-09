using STRlantian.Play.KeyBinds;
using Unity.VisualScripting;
using UnityEditor;
using UnityEditor.UIElements;
using UnityEngine;

namespace STRlantian.Play.Player
{
    public class PlayerBasic : MonoBehaviour
    {
        public Transform back;
        public Rigidbody2D body;
        public SpriteRenderer ren;
        public float speed;
        public bool interactable = false;
        public Sprite up, down, left, right;
        private void Start()
        {
            AKey.UpdateKey();
        }

        private void Update()
        {
            if(Input.GetKey(AKey.up))
            {
                PlayerMoveVer(1);
            }
            if(Input.GetKey(AKey.down))
            {
                PlayerMoveVer(-1);
            }
            if(Input.GetKey(AKey.left))
            {
                PlayerMoveHor(-1);
            }
            if(Input.GetKey(AKey.right))
            {
                PlayerMoveHor(1);
            }
        }

        private void PlayerMoveVer(int dire) //1 for up, -1 for down
        {
            if(dire == 1)
            {
                ren.sprite = up;
            }
            else
            {
                ren.sprite = down;
            }
            back.position = new Vector2(back.position.x, back.position.y + speed * dire * -1 * Time.deltaTime); //Background turns
        }

        private void PlayerMoveHor(int dire) //1 for right, -1 for left
        {
            if (dire == 1)
            {
                ren.sprite = right;
            }
            else
            {
                ren.sprite = left;
            }
            back.position = new Vector2(back.position.x + speed * dire * -1 * Time.deltaTime, back.position.y);
        }
    }
}
