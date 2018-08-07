using UnityEngine;

public class ExplosionAudio : AudioFeedback, IDestructionFeedback {

    public void Trigger()
    {
        transform.SetParent(null);
        source.Play();
        Invoke("AutoDestroy", 1.0f);
    }

    private void AutoDestroy()
    {
        Destroy(gameObject);
    }
}
