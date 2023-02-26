using System;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public Transform target;
    public float speed = 5;
    public int damage = 10;
    public Health health;
    
    private void Start()
    {
        if (target == null) target = GameObject.FindGameObjectWithTag("Crystal").transform;
    }

    private void Update()
    {
        if (target == null) return;
        
        transform.LookAt(target);
        
        transform.position = Vector3.MoveTowards(
            transform.position,
            target.position,
            speed * Time.deltaTime
            );
    }


    private void OnCollisionEnter(Collision collision)
    {
        print("xD");
        if (collision.gameObject.CompareTag("Crystal"))
        {
            collision.gameObject.GetComponent<Health>().Damage(damage);
            health.Die();
        }
    }
}
