using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    [SerializeField]
    protected Slider healthSlider;
    [SerializeField]
    protected Slider easeHealthSlider;
    [SerializeField]
    protected float easeHealthSpeed;
    public virtual void Awake()
    {

    }
    public virtual void SetMaxHealth(float health)
    {
        healthSlider.maxValue = health;
        healthSlider.value = health;
        easeHealthSlider.maxValue = health;
    }

    public virtual void SetHealth(float health)
    {
        healthSlider.value = health;
        if (healthSlider.value != easeHealthSlider.value)
        {
            easeHealthSlider.value = Mathf.Lerp(easeHealthSlider.value, health, easeHealthSpeed);
        }
    }
}
