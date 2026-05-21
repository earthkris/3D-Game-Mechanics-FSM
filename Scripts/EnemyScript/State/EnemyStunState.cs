using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyStunState : EnemyState
{
    protected bool isStunTimeOver;

    public EnemyStunState(Entity entity, EnemyStateMachine stateMachine, string animBoolName, D_Entity stateData) : base(entity, stateMachine, animBoolName, stateData)
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

        isStunTimeOver = false;
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

        if (Time.time >= startStateTime + stateData.stunTime)// after stunTime finish do something
        {
            isStunTimeOver = true;
        }
    }
    public override void PhysicsUpdate()
    {
        base.PhysicsUpdate();
    }
}
