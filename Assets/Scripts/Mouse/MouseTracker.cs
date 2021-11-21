using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseTracker : MonoBehaviour
{
    Camera mainCam;

    private void Awake()
    {
        mainCam = Camera.main;
    }

    private void FixedUpdate()
    {
        transform.position = mainCam.ScreenToWorldPoint(Input.mousePosition);
    }
}
