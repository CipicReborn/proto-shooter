using UnityEngine;

namespace UnityShooter.Tools
{
    [ExecuteInEditMode]
    public class CircleDisposer : MonoBehaviour
    {

        public Transform Origin;
        public float Radius;
        [Range(0, 180)]
        public int ArcStart = 0;
        [Range(0, 360)]
        public int ArcStop = 180;

        public bool Reposition;
        public bool AutoReposition;
        public int DebugLineSize;

        void Update()
        {
            if (AutoReposition || Reposition)
            {
                Reposition = false;
                UpdatePosition();
            }
        }

        private void UpdatePosition()
        {
            var count = transform.childCount;
            var deltaAngle = (ArcStop - ArcStart) / (float) (count - 1);
            for (int i = 0; i < count; i++)
            {
                var t = transform.GetChild(i);
                var angle = ArcStart + deltaAngle * i;
                var pos = new Vector3(0, Mathf.Sin(Mathf.Deg2Rad * angle), -Mathf.Cos(Mathf.Deg2Rad * angle)) * Radius;

                t.localPosition = pos;
                t.localRotation = Quaternion.Euler(new Vector3(angle-180, 0, 0));
            }
        }

        private void OnDrawGizmos()
        {
            Gizmos.color = Color.red;

            for (int i = 0; i < transform.childCount; i++)
            {
                var t = transform.GetChild(i);
                Gizmos.DrawLine(t.position, t.position + t.forward * DebugLineSize);
            }
        }
    }

}