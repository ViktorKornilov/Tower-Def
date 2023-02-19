using System;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public Transform target;
    public float speed = 5;
    
    private void Start()
    {
        if (target == null) target = GameObject.FindGameObjectWithTag("Crystal").transform;
    }

    private void Update()
    {
        if (target == null) return;
        
        transform.position = Vector3.MoveTowards(
            transform.position,
            target.position,
            speed * Time.deltaTime
            );
        
        
    }
}
