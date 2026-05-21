using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyIdleState : EnemyState
{
    protected bool isIdleTimeOver;

    protected bool isPlayerInCloseRange;
    protected bool isPlayerInMinAggroRange;
    protected bool isPlayerInMaxAggroRange;

    protected bool readyToAttack;
    protected bool readyToCharge;
    protected bool readyToBeamAtk;

    protected float idleTime;
    public EnemyIdleState(Entity entity, EnemyStateMachine stateMachine, string animBoolName, D_Entity stateData) : base(entity, stateMachine, animBoolName, stateData)
    {
        this.stateData = stateData;
    }

    public override void DoChecks()
    {
        base.DoChecks();

        isPlayerInCloseRange = entity.CheckPlayerInCloseRange();
        isPlayerInMinAggroRange = entity.CheckPlayerInMinAggroRange();
        isPlayerInMaxAggroRange = entity.CheckPlayerInMaxAggroRange();
    }

    public override void Enter()
    {
        base.Enter();
        isIdleTimeOver = false;
        readyToAttack = false;
        readyToCharge = false;

        agent.isStopped = true;

        SetRandomIdleTime();
    }

    public override void Exit()
    {
        base.Exit();
        agent.isStopped = false;
    }

    public override void HandleInput()
    {
        base.HandleInput();
    }

    public override void LogicUpdate()
    {
        base.LogicUpdate();

        if(Time.time >= startStateTime + idleTime)
        {
            isIdleTimeOver = true;
        }
        if(Time.time >= startStateTime + stateData.canChargeTime)
        {
            readyToCharge = true;
        }
        if (Time.time >= startStateTime + stateData.canAttackTime)
        {
            readyToAttack = true;
        }
    }

    public override void PhysicsUpdate()
    {
        base.PhysicsUpdate();
        entity.LookAtPlayer();
    }

    private void SetRandomIdleTime()//random time for idle
    {
        idleTime = Random.Range(stateData.minIdleTime, stateData.maxIdleTime);
    }
}
