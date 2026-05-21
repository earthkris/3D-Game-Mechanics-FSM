using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RangeAttackState : EnemyAttackState
{
    public RangeAttackState(Entity entity, EnemyStateMachine stateMachine, string animBoolName, Transform attackPos, D_Entity stateData) : base(entity, stateMachine, animBoolName, attackPos, stateData)
    {
    }

    public override void DoChecks()
    {
        base.DoChecks();
    }

    public override void Enter()
    {
        base.Enter();
        isAttackingState = true;
    }

    public override void Exit()
    {
        base.Exit();
    }

    public override void FinishAttack()
    {
        base.FinishAttack();
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
    }

    public override void TriggerAttack()
    {
        base.TriggerAttack();
    }
}
