using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class SetFullscreen : MonoBehaviour
{
    public void Toggle(bool isMarked)
    {
        Screen.fullScreen = isMarked;
    }
}
