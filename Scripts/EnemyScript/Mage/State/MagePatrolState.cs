using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MagePatrolState : EnemyPatrolState
{
    private EnemyMage enemy;
    public MagePatrolState(Entity entity, EnemyStateMachine stateMachine, string animBoolName, D_Entity stateData , EnemyMage enemy) : base(entity, stateMachine, animBoolName, stateData)
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

        //PREPARE FOR BATTLE
        if(isPlayerInMaxAggroRange)
        {
            stateMachine.ChangeState(enemy.idleState);
        }
    }

    public override void PhysicsUpdate()
    {
        base.PhysicsUpdate();
    }
}
