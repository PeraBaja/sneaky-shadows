using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerRunController : MonoBehaviour
{
    [SerializeField] float topSpeed = 5f;
    [SerializeField] float acceleration = 2f;
    [SerializeField] float deceleration = 4f;
    private Vector2 movementInput;
    private bool isMoving = false;
    private Rigidbody2D body2D;
    private float LerpTime = 0;
    public event Action<float> OnPlayerMoves;

    private void Awake()
    {
        body2D = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        float horizontalInput = Input.GetAxisRaw("Horizontal"); ;
        movementInput = new Vector3(horizontalInput, 0f).normalized;
        OnPlayerMoves?.Invoke(movementInput.x);
        isMoving = (movementInput != Vector2.zero) ? true : false;
    }
    private void FixedUpdate()
    {
        LerpTime = Mathf.Clamp01(LerpTime);
        if (isMoving)
        {
            Accelerate();
            return;
        }
        if (body2D.velocity.x != 0) Decelerate();

    }
    private void Accelerate()
    {
        LerpTime += Time.deltaTime;
        body2D.velocity = new Vector2(movementInput.x * Mathf.Lerp(0, topSpeed, LerpTime * acceleration), body2D.velocity.y);
    }
    private void Decelerate()
    {
        LerpTime -= Time.deltaTime;
        body2D.velocity = new Vector2(Mathf.Lerp(0, body2D.velocity.x, LerpTime * deceleration), body2D.velocity.y);
    }
}
