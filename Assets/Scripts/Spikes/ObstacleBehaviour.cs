using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleBehaviour : MonoBehaviour
{

    AudioSource audioSource;
    private void Awake()
    {
        audioSource = GetComponent<AudioSource>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent(out DetectWhenPlayerDies player))
        {
            player.OnDie();
            Destroy(player.gameObject);
            PlayDieAudio();
        }
    }

   
    void PlayDieAudio()
    {

        Debug.Log("Tocando audio muerte: " + audioSource.isPlaying);
        audioSource.Play();
    }
}
