using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyHealthBar : HealthBar 
{
    public GameObject cam;

    public override void Awake()
    {
        cam = GameObject.FindGameObjectWithTag("MainCamera");
    }
    public void Update()
    {
        transform.rotation = Quaternion.LookRotation(transform.position - cam.transform.position);
    }

    public override void SetHealth(float health)
    {
        base.SetHealth(health);
    }

    public override void SetMaxHealth(float health)
    {
        base.SetMaxHealth(health);
    }
}
