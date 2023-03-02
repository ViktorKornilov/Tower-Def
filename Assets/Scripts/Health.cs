using UnityEngine;

public class Health : MonoBehaviour
{
    public int maxHP = 100;
    [SerializeField]private int hp;

    public int Hp => hp;

    public bool autoDestroy = true;

    public GameObject damageEffect;
    public GameObject deathEffect;

    private void Start()
    {
        if (hp == 0) hp = maxHP;
    }

    public void Damage(int value)
    {
        
        hp -= value;
        
        if(damageEffect != null)Instantiate(damageEffect, transform.position, Quaternion.identity);
        if (hp <= 0) Die();
    }

    public void Die()
    {
        if(deathEffect != null)Instantiate(deathEffect, transform.position, Quaternion.identity);
        if(autoDestroy)Destroy(gameObject);
    }
}
