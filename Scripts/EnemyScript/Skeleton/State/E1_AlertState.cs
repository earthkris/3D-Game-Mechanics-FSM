using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class E1_AlertState : EnemyAlertState //NOT USE
{
    private Enemy1 enemy;
    public E1_AlertState(Entity entity, EnemyStateMachine stateMachine, string animBoolName, D_Entity stateData, Enemy1 enemy) : base(entity, stateMachine, animBoolName, stateData)
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
        //var alert = enemy.InstantiateSomething(entity.alertVFX , enemy.transform.position, enemy.transform.rotation , enemy.enemyAlertSpawn.transform);
        //alert.transform.LookAt(player.transform.position);
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
}
