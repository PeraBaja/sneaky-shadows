using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerRunController : MonoBehaviour
{
    [SerializeField] float topSpeed = 5f;
    [SerializeField] float deceleration = 4f;
    [SerializeField] float acceleration = 2f;
    
    Vector2 movementInput;
    bool isMoving = false;
    Rigidbody2D body2D;

    public event Action<float> OnPlayerMoves;

    void Awake()
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
    void FixedUpdate()
    {

        Accelerate();
    }
    void Accelerate()
    {
        float targetSpeed = movementInput.x * topSpeed;
        float accelerationRate = (Mathf.Abs(targetSpeed) > 0.01f) ? acceleration : deceleration;

        float speedDif = targetSpeed - body2D.velocity.x;

        float movement = speedDif * accelerationRate;

        body2D.AddForce(movement * Vector2.right, ForceMode2D.Force);

    }
}
