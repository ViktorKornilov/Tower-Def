using System;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float speed = 10;
    public Transform target;
    public int damage = 30;
    public Tower owner;

    private void Update()
    {
        if (target == null) Die();
        
        transform.LookAt(target);
        transform.position += transform.forward * speed * Time.deltaTime;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            var health = collision.gameObject.GetComponent<Health>();
            health.Damage(damage);
            if (health.Hp <= 0) owner.BulletKilled(this);
            
            Die();
        }
    }

    void Die()
    {
        transform.DetachChildren();
        Destroy(gameObject);
    }
}
