using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    public float dmg;
    public GameObject hitEffect;
    void Start()
    {
        Destroy(gameObject , 10f);
    }
    void OnTriggerEnter(Collider other)
    {
        GameObject hit;
        if (other.gameObject.CompareTag("Player"))
        {
            hit = Instantiate(hitEffect ,transform.position , transform.rotation);
            Destroy(hit , 1.5f);
            IDamageable damageable = other.GetComponent<IDamageable>();

            if (damageable != null)
            {
                damageable.DealDamage(dmg);
            }

        }
        if (!other.isTrigger)
        {
            hit = Instantiate(hitEffect, transform.position, transform.rotation);
            Destroy(hit, 1.5f);
            Destroy(gameObject);
        }
    }
}
