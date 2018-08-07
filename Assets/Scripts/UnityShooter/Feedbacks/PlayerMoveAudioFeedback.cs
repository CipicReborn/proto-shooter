using UnityEngine;
using Game.Behaviour;

namespace UnityShooter
{
    public class PlayerMoveAudioFeedback : MonoBehaviour, IFeedbackEffect<Vector2>
    {
        public float volumeOn;
        public float volumeOff;
        public float pitchOn;
        public float pitchOff;

        public void Tick(Vector2 move)
        {
            if (move == Vector2.zero)
            {
                Idle();
            }
            else
            {
                Move();
            }
        }

        private AudioSource source;

        private void Awake()
        {
            source = GetComponent<AudioSource>();
        }

        public void Idle()
        {
            source.volume = volumeOff;
            source.pitch = pitchOff;
        }

        public void Move()
        {
            source.volume = volumeOn;
            source.pitch = pitchOn;
        }
    }
}