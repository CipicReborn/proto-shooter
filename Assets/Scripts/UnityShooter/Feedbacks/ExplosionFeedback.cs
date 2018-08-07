using System.Collections.Generic;
using UnityEngine;

namespace UnityShooter
{
    public class ExplosionFeedback : MonoBehaviour, IDestructionFeedback
    {
        public List<ParticleSystem> Systems;

        public void Trigger()
        {
            transform.SetParent(null);
            for (int i = 0; i < Systems.Count; i++)
            {
                Systems[i].Play();
            }
            Invoke("AutoDestroy", 5.0f);
        }

        private void AutoDestroy()
        {
            Destroy(gameObject);
        }
    }
}