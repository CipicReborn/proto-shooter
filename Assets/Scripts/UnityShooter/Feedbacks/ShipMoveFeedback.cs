using Game.Behaviour;
using UnityEngine;

namespace UnityShooter
{
    public class ShipMoveFeedback : MonoBehaviour, IFeedbackEffect<Vector2>
    {

        public Transform ThrustFeedback;
        public AnimationCurve yVelocityUpCurve;
        public float force;
        private ParticleSystem.MinMaxCurve yVelocityUp = new ParticleSystem.MinMaxCurve();
        private ParticleSystem.MinMaxCurve yVelocityCenter = new ParticleSystem.MinMaxCurve();
        private ParticleSystem.MinMaxCurve yVelocityDown = new ParticleSystem.MinMaxCurve();
        private float toto;
        private string currentState = "idle";
        private ParticleSystem.MainModule mainSettings;
        private ParticleSystem.VelocityOverLifetimeModule velocityModule;

        public void Tick(Vector2 move)
        {
            if (move.y == 0)
            {
                if (move.x == 0)
                {
                    Idle();
                    return;
                }
                else if (move.x > 0)
                {
                    MoveRight();
                    return;
                }
                else if (move.x < 0)
                {
                    MoveLeft();
                    return;
                }
            }
            else if (move.y > 0)
            {
                MoveUp();
            }
            else if (move.y < 0)
            {
                MoveDown();
            }
        }

        private void Awake()
        {
            mainSettings = ThrustFeedback.GetComponent<ParticleSystem>().main;
            SetupThrustVelocitySettings();
        }

        private void SetupThrustVelocitySettings()
        {
            velocityModule = ThrustFeedback.GetComponent<ParticleSystem>().velocityOverLifetime;
            velocityModule.enabled = true;

            velocityModule.space = ParticleSystemSimulationSpace.Local;

            yVelocityUp.constant = -1.0f;
            yVelocityCenter.constant = 0.0f;
            yVelocityDown.constant = 1.0f;
        }

        private void Idle()
        {
            if (currentState == "idle")
                return;
            currentState = "idle";
            velocityModule.y = yVelocityCenter;
            mainSettings.startLifetime = 1.5f;

        }

        private void MoveUp()
        {
            if (currentState == "up")
                return;
            currentState = "up";
            velocityModule.y = new ParticleSystem.MinMaxCurve(-force, yVelocityUpCurve);
            mainSettings.startLifetime = 3;
        }

        private void MoveDown()
        {
            if (currentState == "down")
                return;
            currentState = "down";
            velocityModule.y = new ParticleSystem.MinMaxCurve(force, yVelocityUpCurve);
            mainSettings.startLifetime = 3;
        }

        private void MoveRight()
        {
            if (currentState == "right")
                return;
            currentState = "right";
            velocityModule.y = yVelocityCenter;
            mainSettings.startLifetime = 3;
        }

        private void MoveLeft()
        {
            if (currentState == "left")
                return;
            currentState = "left";
            velocityModule.y = yVelocityCenter;
            mainSettings.startLifetime = 0;
        }


    }
}