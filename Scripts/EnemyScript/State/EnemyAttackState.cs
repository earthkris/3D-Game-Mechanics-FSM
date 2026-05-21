using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttackState : EnemyState
{
    protected Transform attackPos;

    protected bool isAnimationFinished;
    protected bool isChargeTimeOver;
    protected bool isTriggerCharge;

    protected bool isPlayerInCloseRange;

    protected Vector3 direction;
    protected Vector3 targetPoint;

    public EnemyAttackState(Entity entity, EnemyStateMachine stateMachine, string animBoolName , Transform attackPos, D_Entity stateData) : base(entity, stateMachine, animBoolName, stateData)
    {
        this.attackPos = attackPos;
    }
    public override void DoChecks()
    {
        base.DoChecks();
        isPlayerInCloseRange = entity.CheckPlayerInCloseRange();
    }

    public override void Enter()
    {
        base.Enter();

        isChargeTimeOver = false;
        isTriggerCharge = false;

        isAnimationFinished = false;

        direction = (player.transform.position - entity.transform.position).normalized;
    }

    public override void Exit()
    {
        base.Exit();
        isAttackingState = true;
    }

    public override void HandleInput()
    {
        base.HandleInput();
    }

    public override void LogicUpdate()
    {
        base.LogicUpdate();

        if (Time.time >= startStateTime + stateData.canChargeTime)
        {
            isChargeTimeOver = true;
        }
    }

    public override void PhysicsUpdate()
    {
        base.PhysicsUpdate();
    }

    public virtual void TriggerAttack()
    {
        agent.speed = stateData.runSpeed;
    }
    public virtual void FinishAttack()
    {
        isAnimationFinished = true;
    }
}
