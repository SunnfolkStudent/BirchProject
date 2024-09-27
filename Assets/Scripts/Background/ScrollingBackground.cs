using System;
using UnityEngine;


public class ScrollingBackground : MonoBehaviour
{
    public float scrollSpeed = 0.02f;
    private void FixedUpdate()
    {
        transform.Translate(Vector3.up * scrollSpeed);
    }
}
