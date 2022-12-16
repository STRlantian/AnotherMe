using STRlantian.Effects.Roller;
using STRlantian.GamePlay.KeyBinds;
using TMPro;
using UnityEngine;

namespace STRlantian.GamePlay.Characters
{
    public class DialogueBasic : MonoBehaviour
    {
        [SerializeField]
        private Animator anim;
        [SerializeField]
        private DialogueRoller roller;
        [SerializeField]
        private bool isDialogueMode = false;

        void Start()
        {
            anim.SetBool("ShowDialogue", false);
            anim.SetBool("CloseDialogue", true);
        }

        void Update()
        {

        }

        public void ShowDialogue(int code)
        {
            anim.SetBool("ShowDialogue", true);
            anim.SetBool("CloseDialogue", false);
            if(!isDialogueMode)
            {
                roller.StartRoll(code);
            }
        }

        public void CloseDialogue()
        {
            anim.SetBool("ShowDialogue", false);
            anim.SetBool("CloseDialogue", true);
            isDialogueMode = false;
        }

        public void CheckNext()
        {
            if(isDialogueMode)
            {
                if(Input.GetKeyDown(AKey.a)
                    || Input.GetKeyDown(AKey.b))
                {
                    roller.NextRoll();
                }
            }
        }
    }
}