using UnityEngine;
using Game.Behaviour;
using Game.Behaviour.Health;

[RequireComponent(typeof(AudioSource))]
public class UnbreakableAudio : MonoBehaviour, IFeedbackEffect<HealthAfterDamage> {

    AudioSource source;

    public void Tick(HealthAfterDamage gameOutput)
    {
        if (gameOutput.damageTaken > 0)
            source.Play();
    }

    private void Awake()
    {
        source = GetComponent<AudioSource>();
    }
}
