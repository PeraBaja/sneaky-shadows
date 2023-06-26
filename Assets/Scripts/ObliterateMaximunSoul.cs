using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ObliterateMaximunSoul : MonoBehaviour
{
    Animation obliterateAnimation;
    AudioSource obliterateAudioSource;
    Rigidbody2D body2D;
    private void Awake()
    {
        obliterateAnimation = GetComponent<Animation>();
        obliterateAudioSource = GetComponent<AudioSource>();
        body2D = GetComponent<Rigidbody2D>();
    }
    private async void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.TryGetComponent(out DetectWhenPlayerDies player))
        {
            obliterateAnimation.Play();
            EventManager.OnObliterateMaxSoul.Invoke();
            await Task.Delay(10 * 1000);
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }
    }
}
