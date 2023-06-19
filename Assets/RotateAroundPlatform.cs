using System.Collections;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Unity.VisualScripting;
using UnityEngine;

public class RotateAroundPlatform : MonoBehaviour
{
    Rigidbody2D body2D;
    private float lerpTime = 0;

    void Awake()
    {
        body2D = GetComponent<Rigidbody2D>();
    }
    void Update()
    {
        RotatePlatform();

    }
    void RotatePlatform()
    {
        lerpTime += Time.deltaTime;
        body2D.angularVelocity = Mathf.Lerp(0, -80, lerpTime);
    }

}
