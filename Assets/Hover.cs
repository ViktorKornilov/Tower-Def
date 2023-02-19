using System;
using UnityEngine;

public class Hover : MonoBehaviour
{
    public float height = 0.5f;
    public float speed = 5;
    private Vector3 startPos;

    private void Start()
    {
        startPos = transform.localPosition;
    }

    private void Update()
    {
        transform.localPosition = startPos + Vector3.up * Mathf.Sin(Time.time * speed) * height;
    }
}
