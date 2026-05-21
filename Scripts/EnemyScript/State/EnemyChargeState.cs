using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyChargeState : EnemyState
{
    protected bool isChargeTimeOver;
    protected bool isTriggerCharge;

    protected Vector3 lastPlayerPosition;
    protected Vector3 chargeDirection;
    protected Vector3 targetPoint;

    protected float distanceError = 3f;
    public EnemyChargeState(Entity entity, EnemyStateMachine stateMachine, string animBoolName, D_Entity stateData) : base(entity, stateMachine, animBoolName, stateData)
    {
        this.stateData = stateData;
    }

    public override void DoChecks()
    {
        base.DoChecks();
    }

    public override void Enter()
    {
        base.Enter();
        isChargeTimeOver = false;
        isTriggerCharge = false;
        isAttackingState = true;

        entity.LookAtPlayer();

    }

    public override void Exit()
    {
        base.Exit();

        agent.speed = stateData.walkSpeed;
    }

    public override void LogicUpdate()
    {
        base.LogicUpdate();     
    }

    public override void HandleInput()
    {
        base.HandleInput();
        if(Time.time >= startStateTime + stateData.canChargeTime)
        {
            isChargeTimeOver = true;
        }
    }

    public override void PhysicsUpdate()
    {
        base.PhysicsUpdate();

    }
    public virtual void TriggerCharge()
    {
        isTriggerCharge = true;
    }
    public virtual void ChargeToPlayer()
    {
        agent.speed = stateData.chargeSpeed;
    }
}
