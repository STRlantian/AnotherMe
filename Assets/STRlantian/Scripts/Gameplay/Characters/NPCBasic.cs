using UnityEngine;

namespace STRlantian.GamePlay.Characters
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
        private string[] words;

        void Start()
        {

        }

        // Update is called once per frame
        void Update()
        {
            ChangeLayer();
        }

        private void ChangeLayer()
        {
            if(pl.transform.position.y > transform.position.y) // 1 for player
            {
                rd.sortingOrder = 2; //2 > 1
            }
            else
            {
                rd.sortingOrder = 0; //0 < 1
            }
        }
    }
}