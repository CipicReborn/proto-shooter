using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class Pickup : MonoBehaviour {

    AudioSource source;

    void Awake () {
        source = GetComponent<AudioSource>();
	}

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            source.Play();
            StartCoroutine(ScaleDown());
            Invoke("Destroy", 1.0f);
        }
    }

    private IEnumerator ScaleDown()
    {
        var elapsed = 0f;
        var duration = 1.0f;
        var t = elapsed / duration;
        var initialScale = transform.localScale;
        var targetScale = Vector3.zero;

        while (t < 1)
        {
            transform.localScale = Vector3.Lerp(initialScale, targetScale, t);
            yield return null;
            elapsed += Time.deltaTime;
            t = elapsed / duration;
        }
        transform.localScale = targetScale;
    }

    private void Destroy()
    {
        Destroy(gameObject);
    }
}
