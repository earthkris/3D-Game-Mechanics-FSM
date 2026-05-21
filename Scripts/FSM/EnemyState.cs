using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyState
{
    protected Entity entity;
    protected EnemyStateMachine stateMachine;

    protected D_Entity stateData;

    protected float newDestinationCD;
    protected float startStateTime;

    protected GameObject player;
    protected NavMeshAgent agent;
    protected Animator anim;

    protected string animBoolName;

    protected bool isAttackingState;

    public EnemyState(Entity entity, EnemyStateMachine stateMachine, string animBoolName , D_Entity stateData)//constructer
    {
        this.entity = entity;
        this.stateMachine = stateMachine;
        this.stateData = stateData;
        this.animBoolName = animBoolName;
    }

    public virtual void Enter()
    {
        //Debug.Log("Enemy Enter : " + this.ToString());
        startStateTime = Time.time;

        player = entity.player;
        agent = entity.agent;
        anim = entity.anim;

        anim.SetBool(animBoolName, true);

        DoChecks();
    }
    public virtual void Exit()
    {
        anim.SetBool(animBoolName, false); 
    }

    public virtual void HandleInput()
    {
    }

    public virtual void LogicUpdate()
    {
    }

    public virtual void PhysicsUpdate()
    {
        DoChecks();
    }

    public virtual void DoChecks()
    {
        entity.isAttacking = isAttackingState;
    }
}
