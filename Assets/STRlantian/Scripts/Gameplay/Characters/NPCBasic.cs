using UnityEngine;

namespace STRlantian.GamePlay.Characters
{
    public class NPCBasic : MonoBehaviour
    {
        public string[] words;
        public BoxCollider2D box;
        public Rigidbody2D body;
        public bool interactable;
        public Sprite up, down, left, right;
        public SpriteRenderer rd;
        public Animator sprAnim;

        void Start()
        {

        }

        // Update is called once per frame
        void Update()
        {

        }

        public void Talk()
        {

        }
        public void AddMovement(float x1, float x2, float y1, float y2)
        {

        }
    }
}