using System;
using SimVik;
using UnityEngine;

public class Tower : MonoBehaviour
{
    [Range(0,20f)]public float range = 10;
    public Transform target;
    
    [Header("References")]
    [SerializeField] private SphereCollider collider;
    [SerializeField] private OptiRingMesh rangeMesh;
    [SerializeField] private Transform shootPoint;
    
    [Header("Shooting")]
    public Bullet bulletPrefab;
    public float shootInterval = 10f;
    private float nextShootTime;
    
    private void Start()
    {
        OnValidate();
    }

    private void Update()
    {
        if (target != null)
        {
            if (Time.time > nextShootTime)
            {
                Shoot();
            }
        }
    }

    void Shoot()
    {
        if (target == null) return;
        nextShootTime = Time.time + shootInterval;

        var bullet = Instantiate(bulletPrefab, shootPoint.position, shootPoint.rotation);
        bullet.target = target;
    }
    

    private void OnValidate()
    {
        collider.radius = range;
        //rangeMesh.radius = range;
        //rangeMesh.ResizeMesh();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Enemy"))
        {
            if(target == null) target = other.transform;
        }
    }
}
