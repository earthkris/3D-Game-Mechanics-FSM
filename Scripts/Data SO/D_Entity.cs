using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "newEntityData", menuName = "Data/Entity/Entity data")]
public class D_Entity : ScriptableObject
{
    [Header("Stats")]
    public float maxHealth = 160;
    public float armorEnemy = 5;
    public float baseAtkDmg = 10;//base attack damage
    public float force = 10;
    public float chargeAtkDmg = 50;

    [Header("Range")]
    public float aggroMaxRange = 20;
    public float aggroMinRange = 10;
    public float closeRange = 5;

    public float attackRange = 5;
    public float chargeAtkRange = 2;

    [Header("Times")]
    public float minIdleTime = 1f;
    public float maxIdleTime = 3f;

    public float stunTime = 0.3f;

    public float canChargeTime = 2f;

    public float canAttackTime = 6;

    [Header("Movement")]
    public float walkSpeed = 2.5f;

    public float runSpeed = 10;

    public float chargeSpeed = 50f;

    public float dieForce = 5;

    public float stoppingDistance = 3;

    public float acceleration = 700f;


    [Header("LayerMask")]
    public LayerMask whatIsPlayer;
    public LayerMask whatIsEnemy;



