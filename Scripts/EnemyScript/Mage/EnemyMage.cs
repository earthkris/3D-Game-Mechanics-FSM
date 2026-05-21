using Unity.IO.LowLevel.Unsafe;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.Rendering;

public class EnemyMage : Entity
{
    public int ID { get; set;} = 0;
    public MagePatrolState patrolState {  get; private set; }
    public MageIdleState idleState { get; private set; }
    public MageProjectileAttackState attackState { get; private set; }
    public MageStunState stunState { get; private set; }
    public MageRunState runState { get; private set; }

    [Header("Projectile")]
    public GameObject projectilePrefab;

    [SerializeField]
    public static int armorEnemy = 10; //should get from D_entity for enemy stats

    public override void Awake()
    {
        base.Awake();

        patrolState = new MagePatrolState(this , stateMachine , "patrol" , stateData , this);
        idleState = new MageIdleState(this , stateMachine , "idle" , stateData , this);
        attackState = new MageProjectileAttackState(this , stateMachine , "attack" , attackPos , stateData , this);
        stunState = new MageStunState(this , stateMachine , "stun" , stateData, this);
        runState = new MageRunState(this, stateMachine, "run", stateData, this);
    }
    private void Start()
    {
        stateMachine.Initialize(patrolState);
    }
    public override void Knockback(Vector3 direction, float knockbackForce)
    {
        if (!isAttacking)
        {
            base.Knockback(direction, knockbackForce);
            stateMachine.ChangeState(stunState);
        }
    }

    public override void TriggerAttack()
    {
        base.TriggerAttack();
        attackState.TriggerAttack();
    }
    public override void FinishAttack()
    {
        base.FinishAttack();
        attackState.FinishAttack();
    }
}


