using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerJumpController : MonoBehaviour
{
    [SerializeField] float jumpForce = 5f;
    [SerializeField] float defautlGravityScale = 5f; 
    [SerializeField] float fallMultiplier = 2.5f;
    [SerializeField] float lowJumpMultiplier = 2f;
    [SerializeField] float jumpBufferTime = 0.2f;
    [SerializeField] float coyoteTime = 0.2f;
    [SerializeField] LayerMask groundLayer;
    private Rigidbody2D body2D;
    private float coyoteTimer = 0f;
    private float boxOffset = 0.6f;
    private float boxSize = 0.5f;
    private float jumpBufferTimer = 0;
    

    public event Action OnPlayerJump;
    private void Awake()
    {
        body2D = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        GetInput();
        CheckGround();
    }

    private void GetInput()
    {
        
        CheckBuffering();
        if (Input.GetButtonUp("Jump") && body2D.velocity.y > 0)
        {
            body2D.velocity = new Vector2(body2D.velocity.x, body2D.velocity.y / 2);
        }
        if (coyoteTimer > 0 && jumpBufferTimer > 0)
        {
            body2D.velocity = new Vector2(body2D.velocity.x, jumpForce);
            jumpBufferTimer = 0;
            coyoteTimer = 0;
            OnPlayerJump?.Invoke();
        }
    }


    private void CheckBuffering()
    {
        if (Input.GetButtonDown("Jump"))
        {
            jumpBufferTimer = jumpBufferTime;
        }
        else jumpBufferTimer -= Time.deltaTime;
        jumpBufferTimer = Mathf.Clamp(jumpBufferTimer, 0f, jumpBufferTime);
    }

    private void FixedUpdate()
    {
        ApplyVariableGravity();
    }
    private void ApplyVariableGravity()
    {
        if (body2D.velocity.y < 0) body2D.gravityScale = defautlGravityScale * fallMultiplier;

        else if (body2D.velocity.y > 0 && !Input.GetButton("Jump"))
        {
            body2D.gravityScale = defautlGravityScale * lowJumpMultiplier;
        }
        else body2D.gravityScale = defautlGravityScale;
    }
    void CheckGround()
    {
        Collider2D ground = Physics2D.OverlapBox(transform.position + Vector3.down * boxOffset,new Vector2(1, 0.3f) * boxSize, 0f, groundLayer);
        coyoteTimer = (ground != null) ? coyoteTime : coyoteTimer - Time.deltaTime;
    }
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireCube(transform.position + Vector3.down * boxOffset, new Vector2(1, 0.2f) * boxSize);
    }
}
