using System;
using UnityEngine;


public class ScrollingBackground : MonoBehaviour
{
    public float scrollSpeed = 0.02f;
    private void Update()
    {
        transform.Translate(Vector3.up * scrollSpeed * Time.deltaTime);
    }
}
