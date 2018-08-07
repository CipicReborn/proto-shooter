using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class AudioFeedback : MonoBehaviour
{
    protected AudioSource source;

    private void Awake()
    {
        source = GetComponent<AudioSource>();
        source.loop = false;
    }
}
