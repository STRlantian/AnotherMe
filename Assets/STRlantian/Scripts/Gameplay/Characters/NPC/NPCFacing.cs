using UnityEngine;

namespace STRlantian.GamePlay.Characters.NPC
{
    public class NPCFacing : StateMachineBehaviour
    {
        [SerializeField]
        private Sprite up, down, left, right;
        [SerializeField]
        private string objName;

        private SpriteRenderer rd;

        public override void OnStateMachineEnter(Animator animator, int stateMachinePathHash)
        {
            rd = GameObject.Find(objName).GetComponent<SpriteRenderer>();
        }

        override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
        {
            int face = animator.GetInteger("facing");
            switch (face)
            {
                case 0: //down
                    rd.sprite = down;
                    break;
                case 1: //up
                    rd.sprite = up;
                    break;
                case 2: //left
                    rd.sprite = left;
                    break;
                case 3: //right
                    rd.sprite = right;
                    break;
            }
        }
    }
}
