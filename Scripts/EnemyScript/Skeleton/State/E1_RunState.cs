using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class E1_RunState : EnemyMoveState
{
    private Enemy1 enemy;
    public E1_RunState(Entity entity, EnemyStateMachine stateMachine, string animBoolName, D_Entity stateData, Enemy1 enemy) : base(entity, stateMachine, animBoolName, stateData)
    {
        this.enemy = enemy;
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

        if (isPlayerInCloseRange)
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
                enemy.agent.SetDestination(player.transform.position);
            }
        }
    }
}
