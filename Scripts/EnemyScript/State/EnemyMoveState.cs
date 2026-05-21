using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyMoveState : EnemyState
{
    protected bool isPlayerInMaxAggroRange;
    protected bool isPlayerInMinAggroRange;
    protected bool isEnemyInCloseRange;
    protected bool isPlayerInCloseRange;

    protected bool readyToAttack;
    protected bool readyToCharge;
    protected bool isDelayTimeOver;

    protected Vector3 directionToPlayer;

    public EnemyMoveState(Entity entity, EnemyStateMachine stateMachine, string animBoolName, D_Entity stateData) : base(entity, stateMachine, animBoolName, stateData)
    {
        this.stateData = stateData;
    }

    public override void DoChecks()
    {
        base.DoChecks();

        isPlayerInMaxAggroRange = entity.CheckPlayerInMaxAggroRange();
        isPlayerInMinAggroRange = entity.CheckPlayerInMinAggroRange();
        isPlayerInCloseRange = entity.CheckPlayerInCloseRange();
    }

    public override void Enter()
    {
        base.Enter();

        readyToAttack = false;
        readyToCharge = false;
        isDelayTimeOver = false;

        agent.isStopped = false;
    }

    public override void Exit()
    {
        base.Exit();

        agent.isStopped = true;
    }

    public override void HandleInput()
    {
        base.HandleInput();
    }

    public override void LogicUpdate()
    {
        base.LogicUpdate();

        if (Time.time >= startStateTime + stateData.canAttackTime)// attack cooldown
        {
            readyToAttack = true;
        }
        if(Time.time >= startStateTime + stateData.canChargeTime)
        {
            readyToCharge = true;
        }
        if (Time.time >= startStateTime + Random.value)
        {
            isDelayTimeOver = true;
        }
    }

    public override void PhysicsUpdate()
    {
        base.PhysicsUpdate();

    }
}
