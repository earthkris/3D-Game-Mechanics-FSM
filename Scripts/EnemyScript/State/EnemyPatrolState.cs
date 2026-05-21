using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyPatrolState : EnemyState //JUST CHILLING STATE BEFORE THE CHAOS BEGINS
{
    protected bool isPlayerInMaxAggroRange;

    protected float randomAnimValue;
    public EnemyPatrolState(Entity entity, EnemyStateMachine stateMachine, string animBoolName, D_Entity stateData) : base(entity, stateMachine, animBoolName, stateData)
    {
    }

    public override void DoChecks()
    {
        base.DoChecks();
        isPlayerInMaxAggroRange = entity.CheckPlayerInMaxAggroRange();
    }

    public override void Enter()
    {
        base.Enter();
        RandomAnim();
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
    }

    public void RandomAnim()
    {
        randomAnimValue = Random.Range(0, 2);
        entity.anim.SetFloat("random", randomAnimValue);
    }
}
