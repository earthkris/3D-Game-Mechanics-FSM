using System.Collections;
using System.Collections.Generic;
using System.Data.SqlTypes;
using UnityEngine;

public class E1_IdleState : EnemyIdleState
{
    private Enemy1 enemy;
    public E1_IdleState(Entity entity, EnemyStateMachine stateMachine, string animBoolName, D_Entity stateData, Enemy1 enemy) : base(entity, stateMachine, animBoolName, stateData)
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

        if(isIdleTimeOver)
        {
            if(isPlayerInCloseRange)
            {
                if (readyToAttack)
                {
                    stateMachine.ChangeState(enemy.attackState);
                }
            }

            if (isPlayerInMinAggroRange & !isPlayerInCloseRange)
            {
                if (readyToCharge)
                {
                    stateMachine.ChangeState(enemy.chargeAtkState);
                }
            }

            if(!isPlayerInMinAggroRange)
            {
                stateMachine.ChangeState(enemy.runState);
            }
        }
    }

    public override void PhysicsUpdate()
    {
        base.PhysicsUpdate();
    }
}
