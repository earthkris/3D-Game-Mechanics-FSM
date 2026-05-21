using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;


public class E1_PatrolState : EnemyPatrolState
{
    private Enemy1 enemy;
    public E1_PatrolState(Entity entity, EnemyStateMachine stateMachine, string animBoolName,D_Entity stateData, Enemy1 enemy) : base(entity, stateMachine, animBoolName, stateData)

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

        // FOUND THE PLAYER AND RUN INTO
        if (isPlayerInMaxAggroRange)
        {
           stateMachine.ChangeState(enemy.runState);
        }
    }

    public override void PhysicsUpdate()
    {
        base.PhysicsUpdate();
    }
}
