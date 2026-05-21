using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MageRunState : EnemyMoveState
{
    private EnemyMage enemy;
    public MageRunState(Entity entity, EnemyStateMachine stateMachine, string animBoolName, D_Entity stateData, EnemyMage enemy) : base(entity, stateMachine, animBoolName, stateData)
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
    }

    public override void PhysicsUpdate()
    {
        base.PhysicsUpdate();

        if (isPlayerInMaxAggroRange)
        {
            enemy.agent.SetDestination(enemy.transform.position);

            if (isDelayTimeOver)
            {
                stateMachine.ChangeState(enemy.attackState);
            }
        }
        else
        {
            if (isDelayTimeOver)
            {
                enemy.agent.SetDestination(player.transform.position);//have to change
            }
        }
    }
}
