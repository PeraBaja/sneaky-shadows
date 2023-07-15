using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class InteractButton : MonoBehaviour
{
    Animator animator;
    private void Awake()
    {
        animator = GetComponent<Animator>();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        
        animator.SetBool("IsNearby", true);
        
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (Input.GetAxis("Vertical") > 0)
        {
            animator.SetTrigger("Select");
            Interact();
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        animator.SetBool("IsNearby", false);
    }
    protected virtual void Interact()
    {
        
    }
}
