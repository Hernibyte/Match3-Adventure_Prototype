using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseTracker : MonoBehaviour
{
    private void FixedUpdate()
    {
        transform.position = Input.mousePosition;
    }
}
