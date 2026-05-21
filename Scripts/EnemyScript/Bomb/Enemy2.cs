using System;
using UnityEngine;
using static UnityEngine.EventSystems.EventTrigger;

public class Enemy2 : Entity
{
    public bombIdleState idleState { get; private set; }
    public bombRunState runState { get; private set; }
    public bombExplodeState explodeState { get; private set; }

    [Header("explode")]
    public GameObject explodeIndicator;

    public override void Awake()
    {
        base.Awake();

        idleState = new bombIdleState(this, stateMachine, "idle", stateData, this);
        runState = new bombRunState(this, stateMachine, "run", stateData, this);
        explodeState = new bombExplodeState(this, stateMachine, "explode" ,stateData , transform , this);
    }
    private void Start()
    {
        stateMachine.Initialize(idleState);

        explodeIndicator.SetActive(false);
    }


    public override void FinishAttack()
    {
        base.FinishAttack();
        explodeState.FinishAttack();

    }
}


