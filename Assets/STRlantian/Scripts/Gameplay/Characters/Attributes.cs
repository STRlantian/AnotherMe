using UnityEngine;
using UnityEngine.UIElements;

namespace STRlantian.GamePlay.Characters
{
    public interface IShowOut
    {
        string name { get; set; }
        string description { get;  set; }
        Image img { get; set; }
    }
    public abstract class Attribute : MonoBehaviour 
    {
        private bool isEnabled { get; set; }
    }
    public class Movement : Attribute
    {
        float x1, x2, y1, y2;
        
    }

}
