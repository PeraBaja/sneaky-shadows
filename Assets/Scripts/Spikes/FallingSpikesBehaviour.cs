using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallingSpikesBehaviour : MonoBehaviour
{
    [SerializeField] float detectionMaxLenght;
    [SerializeField] LayerMask playerLayer;
    Rigidbody2D body2D;
    [SerializeField] GameObject particleObject;
    private void Awake()
    {
        body2D = GetComponent<Rigidbody2D>();
        body2D.gravityScale = 0;
    }
    private void Update()
    {
        Collider2D playerHit = Physics2D.OverlapArea(transform.position, transform.position + Vector3.down * detectionMaxLenght, playerLayer);

        if (playerHit == null) return;
        particleObject.SetActive(false);

        body2D.gravityScale = 2f;
        Destroy(gameObject, 5f);
    }
}
