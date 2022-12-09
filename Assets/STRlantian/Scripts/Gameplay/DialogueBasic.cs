using TMPro;
using UnityEngine;

namespace STRlantian.Play.Dialogue
{
    public class DialogueBasic : MonoBehaviour
    {
        public TextMeshPro mesh;
        public Animator anim;
        void Start()
        {
            anim.SetBool("ShowDialogue", false);
            anim.SetBool("CloseDialogue", true);
        }

        void Update()
        {

        }

        public void ShowTextDialogue(string text)
        {
            anim.SetBool("ShowDialogue", true);
            anim.SetBool("CloseDialogue", false);
        }

        public void Close()
        {

        }
    }
}