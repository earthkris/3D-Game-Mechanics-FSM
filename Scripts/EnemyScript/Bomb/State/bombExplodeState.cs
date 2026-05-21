using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bombExplodeState : EnemyAttackState
{
    private Enemy2 enemy;
    protected bool performExplode;
    public bombExplodeState(Entity entity, EnemyStateMachine stateMachine, string animBoolName, D_Entity stateData, Transform attackPos , Enemy2 enemy) : base(entity, stateMachine, animBoolName, attackPos, stateData)
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
        performExplode = false;
        agent.isStopped = true;

        enemy.explodeIndicator.SetActive(true);
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

        if(Time.time >= startStateTime + stateData.canAttackTime) 
        {
            performExplode = true;
        }

        if(isAnimationFinished)
        {
            Explode();
            entity.Die();
        }

        if (performExplode)
        {
            enemy.anim.SetTrigger("exploded");
        }

    }

    public override void PhysicsUpdate()
    {
        base.PhysicsUpdate();
    }

    public virtual void Explode()
    {
        Collider[] hit = Physics.OverlapSphere(enemy.transform.position, stateData.aggroMinRange);
        foreach (Collider target in hit)
        {

            IKnockbackable knockbackable = target.GetComponent<IKnockbackable>();

            if (knockbackable != null)
            {
                knockbackable.Knockback(-target.transform.forward, stateData.force);
            }

            IDamageable damageable = target.GetComponent<IDamageable>();

            if (damageable != null)
            {
                damageable.DealDamage(stateData.baseAtkDmg);
            }
        }

        enemy.explodeIndicator.SetActive(false);
    }
}
