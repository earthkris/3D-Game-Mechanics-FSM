using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MageIdleState : EnemyIdleState
{
    private EnemyMage enemy;
    public MageIdleState(Entity entity, EnemyStateMachine stateMachine, string animBoolName, D_Entity stateData, EnemyMage enemy) : base(entity, stateMachine, animBoolName, stateData)
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
        readyToBeamAtk = false;
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
        if (isIdleTimeOver)
        {
            //PERFORM PROJECTILE
            if(isPlayerInMaxAggroRange)
            {
                if (readyToAttack)
                {
                    stateMachine.ChangeState(enemy.attackState);
                }
            }
            else
            {
                stateMachine.ChangeState(enemy.runState);
            }
        }

    }

    public override void PhysicsUpdate()
    {
        base.PhysicsUpdate();

        if(readyToBeamAtk)
        {
            //FLEE
        }
    }
}
