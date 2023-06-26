using System.Collections;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Unity.VisualScripting;
using UnityEngine;

public class RotateAroundPlatform : MonoBehaviour
{
    Rigidbody2D body2D;

    void Awake()
    {
        body2D = GetComponent<Rigidbody2D>();
        EventManager.OnPlayerActivateEasterEgg += RotateBackwardsPlatform;
    }
    void Start()
    {
        RotatePlatform();
    }
    void RotatePlatform()
    {
        body2D.angularVelocity = -80;
    }
    void RotateBackwardsPlatform()
    {
        body2D.angularVelocity = 80;
    }

}
