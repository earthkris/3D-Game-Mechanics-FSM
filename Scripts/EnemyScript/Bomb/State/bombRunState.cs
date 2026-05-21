using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bombRunState : EnemyMoveState
{
    private Enemy2 enemy;
    public bombRunState(Entity entity, EnemyStateMachine stateMachine, string animBoolName, D_Entity stateData, Enemy2 enemy) : base(entity, stateMachine, animBoolName, stateData)
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
        enemy.agent.speed = stateData.runSpeed;
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
            stateMachine.ChangeState(enemy.idleState);
        }
        else
        {
            if(isDelayTimeOver)
            enemy.agent.SetDestination(player.transform.position);
        }
    }

    public override void PhysicsUpdate()
    {
        base.PhysicsUpdate();
    }
}
