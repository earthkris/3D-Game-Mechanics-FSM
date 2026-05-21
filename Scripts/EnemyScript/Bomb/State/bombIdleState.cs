using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bombIdleState : EnemyIdleState
{
    private Enemy2 enemy;
    public bombIdleState(Entity entity, EnemyStateMachine stateMachine, string animBoolName, D_Entity stateData, Enemy2 enemy) : base(entity, stateMachine, animBoolName, stateData)
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
        if (isPlayerInCloseRange)
        {
            if (readyToCharge)
            {
                stateMachine.ChangeState(enemy.explodeState);
            }
        }

        else if (!isPlayerInCloseRange)
        {
            stateMachine.ChangeState(enemy.runState);
        }
    }

    public override void PhysicsUpdate()
    {
        base.PhysicsUpdate();
    }
}
