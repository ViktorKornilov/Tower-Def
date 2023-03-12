using System;
using UnityEngine;
using UnityEngine.AI;

public class Enemy : MonoBehaviour
{
    public Transform target;
    public float speed = 5;
    public int damage = 10;
    public Health health;
    public NavMeshAgent agent;
    
    private void Start()
    {
        if (target == null) target = GameObject.FindGameObjectWithTag("Crystal").transform;
    }
    

    private void OnEnable()
    {
        Spawner.enemies.Add(this);
    }

    private void OnDisable()
    {
        Spawner.enemies.Remove(this);
    }
    

    private void Update()
    {
        if (target == null) return;

        agent.destination = target.position;
        agent.speed = speed;

        // transform.LookAt(target);
        //
        // transform.position = Vector3.MoveTowards(
        //     transform.position,
        //     target.position,
        //     speed * Time.deltaTime
        //     );
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
