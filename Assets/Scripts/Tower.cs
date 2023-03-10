using System;
using System.Collections.Generic;
using SimVik;
using UnityEngine;
using UnityEngine.Serialization;


public class Tower : MonoBehaviour
{
    [Range(0,20f)]public float range = 10;
    public Transform target;
    public TowerTargetMode targetMode;
    
    [Header("References")]
    [SerializeField] private SphereCollider collider;
    [SerializeField] private OptiRingMesh rangeMesh;
    [SerializeField] private Transform shootPoint;
    [SerializeField] private AudioClip shootSound;
    
    [Header("Shooting")]
    public Bullet bulletPrefab;
    public float shootInterval = 10f;
    private float nextShootTime;
    public int damage = 30;
    
    
    
    private void Start()
    {
        OnValidate();
    }

    void FindClosest()
    {
        float closestDistance = float.MaxValue;

        List<Transform> invalidTargets = new();
        foreach (var availableTarget in availableTargets)
        {
            if (availableTarget)
            {
                invalidTargets.Add(availableTarget);
                continue;
            }
            
            float distance = Vector3.Distance(transform.position, availableTarget.position);
            if (distance < closestDistance)
            {
                closestDistance = distance;
                target = availableTarget;
            }
        }

        foreach (var t in invalidTargets)
        {
            availableTargets.Remove(t);
        }
    }

    private void Update()
    {
        if (target == null)
        {
            SelectTarget();
        }

        if (Time.time > nextShootTime) Shoot();
    }

    void SelectTarget()
    {
        if (availableTargets.Count <= 0) return;
        
        if (targetMode == TowerTargetMode.Closest) FindClosest();
        if (targetMode == TowerTargetMode.First) target = availableTargets[0];
        if (targetMode == TowerTargetMode.Last) target = availableTargets[^1];
        
        
        if (!target)
        {
            availableTargets.Remove(target);
            SelectTarget();
        }
    }
    

    void Shoot()
    {
        nextShootTime = Time.time + shootInterval;

        var bullet = Instantiate(bulletPrefab, shootPoint.position, shootPoint.rotation);
        bullet.target = target;
        bullet.damage = damage;
        bullet.owner = this;
        
       // Audio.Play(shootSoundhat );
    }

    public void BulletKilled(Bullet bullet)
    {
        availableTargets.Remove(bullet.target);
        // xp+= bullet.target.xp
    }
    

    private void OnValidate()
    {
        collider.radius = range;
        //rangeMesh.radius = range;
        //rangeMesh.ResizeMesh();
    }

    [FormerlySerializedAs("targets")] public List<Transform> availableTargets;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Enemy"))
        {
            availableTargets.Add(other.transform);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Enemy"))
        {
            availableTargets.Remove(other.transform);
        }
    }
}
