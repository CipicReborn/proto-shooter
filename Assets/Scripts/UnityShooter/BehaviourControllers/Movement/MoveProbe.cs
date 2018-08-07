using UnityEngine;

namespace UnityShooter {

    public class MoveProbe : CollisionBox {

        public Color Color;

        public bool IsBlocked ()
        {
            return isBlocked;
        }

        private BoxCollider bc;
        private bool isBlocked;

        private void Awake()
        {
            GetBox();
        }

        private void OnValidate()
        {
            GetBox();
        }

        private void GetBox()
        {
            bc = GetComponent<BoxCollider>();
            bc.isTrigger = true;
        }

        private void OnTriggerEnter(Collider other)
        {
            isBlocked = true;

        }

        private void OnTriggerStay (Collider other)
        {
            isBlocked = true;
        }

        private void OnTriggerExit(Collider other)
        {
            isBlocked = false;
        }

        private void OnDrawGizmos()
        {
            Gizmos.color = isBlocked ? Color.red : Color;
            Gizmos.DrawCube(transform.position + bc.center, new Vector3(bc.size.z, bc.size.y, bc.size.x));
        }
    }

}