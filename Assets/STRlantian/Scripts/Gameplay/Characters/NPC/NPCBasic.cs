using UnityEngine;

namespace STRlantian.GamePlay.Characters.NPC
{
    public class NPCBasic : MonoBehaviour
    {
        [SerializeField] 
        protected BoxCollider2D box;
        [SerializeField]
        protected Rigidbody2D body;
        [SerializeField] 
        protected bool interactable;
        [SerializeField] 
        protected Sprite up, down, left, right;
        [SerializeField] 
        protected SpriteRenderer rd;
        [SerializeField] 
        protected Animator sprAnim;

        [SerializeField]
        private PlayerBasic pl;
        [SerializeField]
        string[] words;

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