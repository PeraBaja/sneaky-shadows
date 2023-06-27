using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerAnimationController : MonoBehaviour
{
    [SerializeField] GameObject playerSoul;
    [SerializeField] int maxSoulsToSpawn;

    Animator animator;
    Rigidbody2D rigidbody2d;
    PlayerJumpController jumpController;
    PlayerRunController runController;
    DetectWhenPlayerDies detectWhenPlayerDies;
    AudioSource audioSourceJump;
    private float lerpTime;
    const string IS_JUMPING = "IsJumping";
    const string DIE = "Die";
    const string IS_FALLING = "IsFalling";
    void Awake()
    {
        animator = GetComponent<Animator>();
        rigidbody2d = GetComponentInParent<Rigidbody2D>();
        jumpController = GetComponentInParent<PlayerJumpController>();
        runController = GetComponentInParent<PlayerRunController>();
        audioSourceJump = GetComponent<AudioSource>();
        detectWhenPlayerDies = GetComponentInParent<DetectWhenPlayerDies>();
        detectWhenPlayerDies.OnDie += TriggerDieAnimation;
        jumpController.OnPlayerJump += TriggerJumpAnimation;
        runController.OnPlayerMoves += InclinatePlayer;
    }
    void Update()
    {

        if (rigidbody2d.velocity.y < 0)
        {
            animator.SetBool(IS_JUMPING, false);
            animator.SetBool(IS_FALLING, true);
            return;
        }
        animator.SetBool(IS_FALLING, false);
        
    }
    void TriggerDieAnimation()
    {
        animator.SetTrigger(DIE);
        SpawnSouls();
    }
    void TriggerJumpAnimation()
    {
        audioSourceJump.Play();
        animator.SetBool(IS_JUMPING, true);
    }
    void InclinatePlayer(float horizontalMovement)
    {
        if (rigidbody2d.velocity.y > 0) return;
        lerpTime = (horizontalMovement != 0) ? lerpTime + Time.deltaTime : 0;
        transform.rotation = Quaternion.Lerp(Quaternion.identity, Quaternion.AngleAxis(horizontalMovement * 45, Vector3.forward), lerpTime);
    }
    private void SpawnSouls()
    {
        Debug.Log("SpawnSoulss");
        for (int i = 0; i < maxSoulsToSpawn; i++)
        {
            GameObject soulInstance = Instantiate(playerSoul, transform.position, Quaternion.identity);
            if (i == 0) soulInstance.GetComponentInChildren<CinemachineVirtualCamera>().Follow = soulInstance.transform;
        }
    }
    private void OnDestroy()
    {
        detectWhenPlayerDies.OnDie -= TriggerDieAnimation;
        jumpController.OnPlayerJump -= TriggerJumpAnimation;
        runController.OnPlayerMoves -= InclinatePlayer;
    }
}
