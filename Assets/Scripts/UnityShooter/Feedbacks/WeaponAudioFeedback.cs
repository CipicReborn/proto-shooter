using UnityEngine;
using Game.Behaviour;

namespace UnityShooter
{
    [RequireComponent(typeof(AudioSource))]
    public class WeaponAudioFeedback : MonoBehaviour, IFeedbackEffect<bool>
    {
        public void Fire()
        {
            source.Play();
        }

        private AudioSource source;
        private void Awake()
        {
            source = GetComponent<AudioSource>();
        }

        public void Tick(bool input)
        {
            if (input)
                Fire();
        }
    }
}