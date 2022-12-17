using UnityEngine;

public class NPCFacing : StateMachineBehaviour
{
    [SerializeField]
    private Sprite up, down, left, right;
    
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        SpriteRenderer rd = GameObject.Find("Player").GetComponent<SpriteRenderer>();
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
