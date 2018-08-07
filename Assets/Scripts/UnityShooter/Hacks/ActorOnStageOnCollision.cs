using UnityEngine;


namespace UnityShooter
{
    public class ActorOnStageOnCollision : Actor
    {
        BoxCollider bc;
        Rigidbody rb;

        override protected void Awake()
        {
            base.Awake();
            bc = gameObject.GetComponent<BoxCollider>();
            rb = gameObject.GetComponent<Rigidbody>();

            if (bc == null || rb == null || !bc.enabled)
            {
                throw new System.Exception("An ActorOnStageOnCollision must have a Rigidbody and a BoxCollider Active and Enabled to work properly.");
            }
        }

        public void StageTrigger()
        {
            Destroy(bc);
            Destroy(rb);
            Setup();
            GoOnStage();
        }
    }
}