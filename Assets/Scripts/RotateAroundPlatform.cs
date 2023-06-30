using System.Collections;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Unity.VisualScripting;
using UnityEngine;

public class RotateAroundPlatform : MonoBehaviour
{
    [SerializeField] float rotatationForce = 90;
    Rigidbody2D body2D;

    void Awake()
    {
        EventManager.OnPlayerActivateEasterEgg += RotateBackwards;
        body2D = GetComponent<Rigidbody2D>();
    }
    private void Start()
    {
        body2D.angularVelocity = rotatationForce;
    }
    void RotateBackwards()
    {
        body2D.angularVelocity = -rotatationForce;
    }

}
