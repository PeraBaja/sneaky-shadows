using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VanishWhenMove : MonoBehaviour
{
    SpriteRenderer spriteRenderer;
    Timer unvanishTimer;
    Rigidbody2D body2D;
    float lerptime = 0;
    void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        body2D = GetComponentInParent<Rigidbody2D>();
        spriteRenderer.color = new Color(256, 256, 256, 0f);
        unvanishTimer = new Timer(6f, true);
    }
    private void Update()
    {
        unvanishTimer.UpdateTimer();
        if (body2D.velocity != Vector2.zero)
        {
            lerptime = 0;
            spriteRenderer.color = new Color(256, 256, 256, 0f);
            unvanishTimer.ResetTimer();
        }
        if (unvanishTimer.TimeIsOut)
        {
            lerptime += Time.deltaTime;
            spriteRenderer.color = new Color(256, 256, 256, Mathf.Lerp(0, 100, lerptime / 10));
        }
    }

}
