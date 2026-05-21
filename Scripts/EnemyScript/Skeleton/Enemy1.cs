using UnityEngine;

public class Enemy1 : Entity
{
    public int ID { get; set;} = 0;
    public E1_RunState runState {  get; private set; }
    public E1_MeleeAttackState attackState { get; private set; }
    public E1_IdleState idleState { get; private set; }
    public E1_StunState stunState { get; private set; }
    public E1_ChargeAttackState chargeAtkState { get; private set; }
    public E1_PatrolState patrolState { get; private set; }
    public E1_WalkState walkState { get; private set; }
    [SerializeField]
    public static int armorEnemy = 10; //should get from D_entity for enemy stats

    public override void Awake()
    {
        base.Awake();

        patrolState = new E1_PatrolState(this, stateMachine, "patrol", stateData, this);
        walkState = new E1_WalkState(this, stateMachine, "walk", stateData, this);
        runState = new E1_RunState(this, stateMachine, "run", stateData, this);
        attackState = new E1_MeleeAttackState(this, stateMachine , "attack", stateData, attackPos, this);
        chargeAtkState = new E1_ChargeAttackState(this, stateMachine, "charge", stateData, chargeAtkPos, this);
        idleState = new E1_IdleState(this, stateMachine, "idle", stateData, this);
        stunState = new E1_StunState(this, stateMachine, "stun", stateData , this);
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
    public override void TriggerCharge()
    {
        base.TriggerCharge();
        chargeAtkState.TriggerCharge();
    }
    public override void FinishCharge()
    {
        base.FinishCharge();
        chargeAtkState.FinishAttack();
    }
}


