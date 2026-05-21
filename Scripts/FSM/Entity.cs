using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.ProBuilder.MeshOperations;
using static UnityEngine.EventSystems.EventTrigger;

public class Entity : MonoBehaviour, IDamageable, IKnockbackable
{
    [SerializeField]
    protected D_Entity stateData;

    public string enemyQuestName;
    private QuestManager theQM;
    public EnemyHealthBar healthBar;

    public EnemyStateMachine stateMachine;
    public Animator anim { get; private set; }
    public NavMeshAgent agent { get; private set; }
    public CharacterController controller { get; private set; }
    public GameObject player { get; private set; }
    public SkinnedMeshRenderer skinnedMeshRenderer { get; private set; }

    protected bool isDead;
    public bool isAttacking { get; set; } = false;

    protected float currentHealth;

    [Header("Reward Drop")]
    public List<SlotItems> slotItems;
    public int CoinDrop;
    public float ExpDrop;

    [Header("Slash")]
    public List<SlashVFX> slashesVfx;
    public GameObject slashParent;

    [Header("Attack Position")]
    public Transform attackPos;
    public Transform chargeAtkPos;
    
    //public Transform soulSpawn;
    //public GameObject soulPrefab;

    [Header("DMG PopUP")]
    public GameObject NewDmgPopup;

    [Header("Hit")]
    public GameObject hitParentPrefab;
    public GameObject hitVFX;
    public Transform enemyHitSpawn;

    [Header("Alert")]
    public GameObject alertParentPrefab;
    public GameObject alertVFX;
    private GameObject alertClone;

    [Header("Blood")]
    public GameObject bloodVFX;
    public GameObject bloodSplashVFX;
    public Transform enemyBloodSpawn;

    [Header("Wood?")]
    public GameObject woodBreakVFX;

    [Header("Mouse!!")]
    [SerializeField]
    public Texture2D cursortex;
    [SerializeField]
    public Material outline;
    [SerializeField]
    public Material defaultTex;

    public virtual void Awake()
    {
        currentHealth = stateData.maxHealth;
        healthBar.SetMaxHealth(stateData.maxHealth);

        anim = GetComponentInChildren<Animator>();
        anim.applyRootMotion = false; // very important, make sure you make it false so don't get any bug with it

        agent = GetComponent<NavMeshAgent>();

        controller = GetComponent<CharacterController>();

        if(player == null)
        {
            player = GameObject.FindGameObjectWithTag("Player");
        }

        skinnedMeshRenderer = transform.GetChild(0).GetComponentInChildren<SkinnedMeshRenderer>();
        stateMachine = new EnemyStateMachine();

        agent.speed = stateData.walkSpeed;
        agent.acceleration = stateData.acceleration;
    }
    public virtual void Update()
    {
        stateMachine.currentState.HandleInput();

        stateMachine.currentState.LogicUpdate();

        if (currentHealth <= 0)//if enemy health = 0, die
        {
            Die();
            agent.enabled = false;
            PlayerController.killCounter++;
            theQM.enemyKilled = enemyQuestName;

        }

        healthBar.SetHealth(currentHealth);
    }
    public virtual void FixedUpdate()
    {
        stateMachine.currentState.PhysicsUpdate();
    }
    public virtual void OnDestroy()
    {
        if (hitVFX != null)
        {
            var hit = Instantiate(hitVFX, enemyHitSpawn.position, Quaternion.identity, hitParentPrefab.transform);
            Destroy(hit, 1f);
        }

        if(bloodSplashVFX != null)
        {
            var bloodSplash = Instantiate(bloodSplashVFX, enemyBloodSpawn.position, Quaternion.identity);
            Destroy(bloodSplash, 1f);
        }

        if (woodBreakVFX != null)
        {
            var woodBreak = Instantiate(woodBreakVFX, enemyBloodSpawn.position, Quaternion.identity);
            Destroy(woodBreak, 1f);
        }
        //Instantiate(soulPrefab, soulSpawn.position, Quaternion.identity);//create soul prefab

        Reward.OnDropRewardCoin(CoinDrop, transform.position);
        Reward.OnDropRewardExp(ExpDrop , transform.position);
        Reward.OnDropRewardItem(slotItems, transform.position);
    }

    public virtual void DealDamage(float amount) //reduce enemy HP
    {
        Mathf.FloorToInt(amount);
        currentHealth -= amount;

        var blood = Instantiate(bloodVFX, enemyBloodSpawn.position, player.transform.rotation);
        blood.transform.LookAt(player.transform);
        Destroy(blood, Random.value);

        hitParentPrefab.transform.LookAt(player.transform);//make it look at at the player
        var hit = Instantiate(hitVFX, enemyHitSpawn.position, Quaternion.identity, hitParentPrefab.transform);
        Destroy(hit , Random.value);

        if (NewDmgPopup)
        {
            ShowDamagePopUp();
        }

        void ShowDamagePopUp()
        {
            DamagePopUp.current.CreatePopUp(transform.position, Mathf.Round(amount).ToString(), Color.white);
        }
    }
    public virtual void Knockback(Vector3 direction ,float knockbackForce)
    {
        agent.ResetPath();
        controller.Move(direction * knockbackForce);
        //agent.velocity = direction * knockbackForce;
    }
    public virtual void Die() //enemy die
    {
        Destroy(gameObject);
    }
    public virtual void LookAtPlayer() //enemy looking at player
    {
        //Look at player
        transform.LookAt(player.transform.position);
    }

    public virtual bool CheckPlayerInMaxAggroRange()
    {
        Collider[] playerInMaxAggroRange = Physics.OverlapSphere(transform.position, stateData.aggroMaxRange, stateData.whatIsPlayer);
        foreach (Collider player in playerInMaxAggroRange)
        {
            return true;
        }
        return false;
    }
    public virtual bool CheckPlayerInMinAggroRange()
    {
        Collider[] playerInMinAggroRange = Physics.OverlapSphere(transform.position, stateData.aggroMinRange, stateData.whatIsPlayer);
        foreach (Collider player in playerInMinAggroRange)
        {
            return true;
        }
        return false;
    }
    public virtual bool CheckPlayerInCloseRange()
    {
        Collider[] playerInCloseRange = Physics.OverlapSphere(transform.position, stateData.closeRange, stateData.whatIsPlayer);
        foreach (Collider player in playerInCloseRange)
        {
            return true;
        }
        return false;
    }
    public virtual bool CheckEnemyInCloseRange()
    {
        Collider[] enemyInCloseRange = Physics.OverlapSphere(transform.position, stateData.closeRange, stateData.whatIsEnemy);
        foreach (Collider enemy in enemyInCloseRange)
        {
            if (enemy.gameObject != this.gameObject)
            {
                return true;
            }
        }
        return false;
    }


    #region Animation Event
    public void SlashesActiveOne()
    {
        slashElements = 0;
        StartCoroutine(SlashAttack());
    }
    public virtual void TriggerAttack()
    {
    }
    public virtual void FinishAttack()
    {
    }
    public virtual void TriggerCharge()
    {
    }
    public virtual void FinishCharge()
    {
    }  
    public virtual void TriggerAlert()
    {
        alertClone = Instantiate(alertVFX, alertParentPrefab.transform.position,Quaternion.identity, alertParentPrefab.transform);
    }
    public virtual void FinishAlert()
    {
        Destroy(alertClone , 0);
        slashElements = 0;
    }
    #endregion

    #region create and destroy Method
    public virtual void DestroyClone(GameObject nameVFX ,float time)
    {
        Transform vfxTransform = gameObject.transform.Find(nameVFX.name + "(Clone)");
        if (vfxTransform != null)
        {
            Destroy(vfxTransform.gameObject, time);
        }
        else// vfx is null warning
        {
            Debug.LogWarning("VFX clone not found!");
        }
    }
    //INSTANTIATE AND SET PARENT
    public virtual GameObject InstantiateSomething(GameObject nameVFX, Vector3 position , Quaternion rotation , Transform parent)
    {
        GameObject instantiatedVFX = Instantiate(nameVFX, position, rotation);
        instantiatedVFX.transform.SetParent(parent);
        return instantiatedVFX;
    }
    //INSTANTIATE
    public virtual GameObject InstantiateSomething(GameObject nameVFX, Vector3 position, Quaternion rotation)
    {
        GameObject instantiatedVFX = Instantiate(nameVFX, position, rotation);
        return instantiatedVFX;
    }
    #endregion

    public virtual void OnDrawGizmos()
    {
        if (stateData != null)
        {
            Gizmos.color = Color.yellow;
            Gizmos.DrawWireSphere(transform.position, stateData.aggroMaxRange);
            Gizmos.color = Color.yellow;
            Gizmos.DrawWireSphere(transform.position, stateData.aggroMinRange);
            Gizmos.color = Color.blue;
            Gizmos.DrawWireSphere(transform.position, stateData.closeRange);
        }

        if (chargeAtkPos != null)
        {
            Gizmos.color = Color.red;
            Gizmos.DrawWireSphere(chargeAtkPos.position, stateData.chargeAtkRange);
        }


        if (attackPos != null)
        {
            Gizmos.color = Color.red;
            Gizmos.DrawWireSphere(attackPos.position, stateData.attackRange);
        }
    }

    [System.Serializable]
    public class SlashVFX
    {
        public GameObject slashPrefab;
        public Transform spawnPoint;
        public float activeDelay;
        public float unactiveDelay;
    }
    private int slashElements;
    IEnumerator SlashAttack()
    {
        GameObject slash;
        yield return new WaitForSeconds(slashesVfx[slashElements].activeDelay);
        slash = Instantiate(slashesVfx[slashElements].slashPrefab, slashesVfx[slashElements].spawnPoint.position, slashesVfx[slashElements].spawnPoint.rotation, slashParent.transform);
        yield return new WaitForSeconds(slashesVfx[slashElements].unactiveDelay);
        Destroy(slash);
    }
}
