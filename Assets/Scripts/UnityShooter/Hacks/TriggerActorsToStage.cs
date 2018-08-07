using UnityEngine;
using UnityShooter;

public class TriggerActorsToStage : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        var actor = other.gameObject.GetComponentInParent<ActorOnStageOnCollision>();

        if (actor != null && !actor.OnStage)
        {
            actor.transform.SetParent(null);
            actor.StageTrigger();
        }
    }
}
