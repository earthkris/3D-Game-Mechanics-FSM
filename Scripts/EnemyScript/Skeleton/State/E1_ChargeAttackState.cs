using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class E1_ChargeAttackState : EnemyAttackState
{
    private Enemy1 enemy;
    public E1_ChargeAttackState(Entity entity, EnemyStateMachine stateMachine, string animBoolName, D_Entity stateData, Transform attackPos, Enemy1 enemy) : base(entity, stateMachine, animBoolName, attackPos, stateData)
    {
        this.enemy = enemy;
    }
    public override void DoChecks()
    {
        base.DoChecks();
    }

    public override void Enter()
    {
        base.Enter();
        isAttackingState = true;

        targetPoint = player.transform.position + direction * stateData.closeRange;
        enemy.transform.LookAt(targetPoint);
    }

    public override void Exit()
    {
        base.Exit();

        targetPoint = Vector3.zero;
    }

    public override void LogicUpdate()
    {
        base.LogicUpdate();

        if (isAnimationFinished)
        {
            stateMachine.ChangeState(enemy.idleState);
        }
        /*
        if (enemy.agent.remainingDistance <= 0.33)
        {
            stateMachine.ChangeState(enemy.idleState);
        }
        */
    }

    public override void HandleInput()
    {
        base.HandleInput();
    }

    public override void PhysicsUpdate()
    {
        base.PhysicsUpdate();

        if (isTriggerCharge)
        {
            ChargeToPlayer();
        }
    }

    public virtual void ChargeToPlayer()
    {

        enemy.agent.isStopped = false;
        enemy.agent.SetDestination(targetPoint);

        Collider[] hitPlayer = Physics.OverlapSphere(attackPos.position, stateData.chargeAtkRange, stateData.whatIsPlayer);
        foreach (Collider player in hitPlayer)
        {
            IDamageable damageable = player.GetComponent<IDamageable>();

            if (damageable != null)
            {
                damageable.DealDamage(stateData.chargeAtkDmg * Time.deltaTime);
            }
        }
    }
    public virtual void TriggerCharge()
    {
        isTriggerCharge = true;
        enemy.agent.speed = stateData.chargeSpeed;
    }
    public override void FinishAttack()
    {
        base.FinishAttack();
    }
}
