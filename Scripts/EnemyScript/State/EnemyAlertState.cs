using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class EnemyAlertState : EnemyState
{
    protected bool isAnimationFinished;
    public EnemyAlertState(Entity entity, EnemyStateMachine stateMachine, string animBoolName, D_Entity stateData) : base(entity, stateMachine, animBoolName, stateData)
    {
    }

    public override void DoChecks()
    {
        base.DoChecks();
    }

    public override void Enter()
    {
        base.Enter();

        isAnimationFinished = false;
        isAttackingState = true;
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
        entity.LookAtPlayer();
    }
    public virtual void TriggerAlert()
    {

    }
    public virtual void FinishAlert()
    {
        isAnimationFinished = true;
    }
}
