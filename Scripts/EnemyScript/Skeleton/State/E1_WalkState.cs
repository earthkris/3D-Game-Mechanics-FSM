using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class E1_WalkState : EnemyMoveState
{
    private Enemy1 enemy;
    public E1_WalkState(Entity entity, EnemyStateMachine stateMachine, string animBoolName, D_Entity stateData, Enemy1 enemy) : base(entity, stateMachine, animBoolName, stateData)
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
        enemy.agent.speed = stateData.walkSpeed;
        enemy.anim.SetFloat("vel", 0);
        directionToPlayer = (enemy.transform.position - player.transform.position).normalized;
    }

    public override void Exit()
    {
        base.Exit();
        enemy.anim.SetFloat("vel", 0);
        directionToPlayer = Vector3.zero;
    }

    public override void HandleInput()
    {
        base.HandleInput();
        enemy.anim.SetFloat("vel",enemy.agent.velocity.magnitude);
    }

    public override void LogicUpdate()
    {
        base.LogicUpdate();
    }

    public override void PhysicsUpdate()
    {
        base.PhysicsUpdate();

        if (isDelayTimeOver)
        {
            entity.LookAtPlayer();
            enemy.agent.SetDestination(directionToPlayer * -stateData.walkSpeed);//walking backward
        }

        if (Time.time >= startStateTime + 1)
        {
            stateMachine.ChangeState(enemy.idleState);
        }
    }
}
