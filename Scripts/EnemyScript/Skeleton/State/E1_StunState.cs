using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class E1_StunState : EnemyStunState
{
    private Enemy1 enemy;
    public E1_StunState(Entity entity, EnemyStateMachine stateMachine, string animBoolName, D_Entity stateData, Enemy1 enemy) : base(entity, stateMachine, animBoolName, stateData)
    {
        this.enemy = enemy;
    }

    public override void Enter()
    {
        base.Enter();

    }

    public override void Exit()
    {
        base.Exit();
        //entity.DestroyClone(enemy.hitVFX, 0.1f);
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
