using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MageProjectileAttackState : RangeAttackState
{
    private EnemyMage enemy;
    public MageProjectileAttackState(Entity entity, EnemyStateMachine stateMachine, string animBoolName, Transform attackPos, D_Entity stateData, EnemyMage enemy) : base(entity, stateMachine, animBoolName, attackPos, stateData)
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

        if(isAnimationFinished)
        {
            stateMachine.ChangeState(enemy.idleState);
        }
    }

    public override void PhysicsUpdate()
    {
        base.PhysicsUpdate();

        entity.LookAtPlayer();
    }

    public override void TriggerAttack()
    {
        base.TriggerAttack();

        GameObject projectilePrefab = entity.InstantiateSomething(enemy.projectilePrefab, attackPos.position, Quaternion.identity);

        Rigidbody projectileRB = projectilePrefab.GetComponent<Rigidbody>();
        projectileRB.velocity = attackPos.forward * stateData.force;

        Projectile projectile = projectilePrefab.GetComponent<Projectile>();
        projectile.dmg = stateData.baseAtkDmg;

    }
    public override void FinishAttack()
    {
        base.FinishAttack();
    }
}
