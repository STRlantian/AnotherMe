using STRlantian.Effects.Roller.Dialogue;
using STRlantian.Play.KeyBinds;
using TMPro;
using UnityEngine;

namespace STRlantian.Play.Dialogue
{
    public class DialogueBasic : MonoBehaviour
    {
        public Animator anim;
        public DialogueRoller roller;
        public bool isDialogueMode = false;
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