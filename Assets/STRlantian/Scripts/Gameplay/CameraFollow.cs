using System.Collections;
using UnityEngine;

namespace Assets.STRlantian.Scripts.Gameplay
{
    public class CameraFollow : MonoBehaviour
    {
        [SerializeField]
        private Transform obj;
        [SerializeField]
        private BoxCollider2D edge;

        private Vector3 des;
        // Update is called once per frame
        void LateUpdate()
        {
            des = obj.position - transform.position;
            transform.position = new Vector3(transform.position.x, transform.position.y, -10);
            transform.position += des / 10;
        }
    }
}