using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class E1_MeleeAttackState : EnemyAttackState
{
    private Enemy1 enemy;
    public E1_MeleeAttackState(Entity entity, EnemyStateMachine stateMachine, string animBoolName, D_Entity stateData , Transform attackPos , Enemy1 enemy) : base(entity, stateMachine,animBoolName, attackPos, stateData)
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
    }

    public override void Exit()
    {
        base.Exit();
    }

    public override void HandleInput()
    {
        base.HandleInput();
    }

    public override void LogicUpdate()
    {
        base.LogicUpdate();

        if (isAnimationFinished)
        {
            stateMachine.ChangeState(enemy.walkState);
        }
    }

    public override void PhysicsUpdate()
    {
        base.PhysicsUpdate();
    }

    public override void TriggerAttack()
    {
        base.TriggerAttack();

        Collider[] hitPlayer = Physics.OverlapSphere(attackPos.position, stateData.attackRange, stateData.whatIsPlayer);
        foreach (Collider player in hitPlayer)
        {
            IDamageable damageable = player.GetComponent<IDamageable>();

            if (damageable != null)
            {
                damageable.DealDamage(stateData.baseAtkDmg);
            }
        }
    }

    public override void FinishAttack()
    {
        base.FinishAttack();
    }
}
