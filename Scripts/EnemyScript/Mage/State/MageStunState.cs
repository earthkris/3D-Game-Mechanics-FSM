using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MageStunState : EnemyStunState
{
    private EnemyMage enemy;
    public MageStunState(Entity entity, EnemyStateMachine stateMachine, string animBoolName, D_Entity stateData, EnemyMage enemy) : base(entity, stateMachine, animBoolName, stateData)
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

        if (isStunTimeOver)
        {
            stateMachine.ChangeState(enemy.idleState);
        }
    }

    public override void PhysicsUpdate()
    {
        base.PhysicsUpdate();
    }
}
