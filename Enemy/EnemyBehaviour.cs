using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyBehaviour : MonoBehaviour
{
    public Animator anim;
    CharacterController cc;
    EnemyAudio enemyAudio;
    EnemyProperties enemyProperties;
    EnemyDropList enemyDropList;
    NavMeshAgent nav;

    public EEnemyState state;
    public GameObject target;
    public GameObject targetAttackPoint;
    public GameObject attackPoint;
    public GameObject hitPoint;
    public GameObject[] ammoORcast;     //弹药或释法效果
    public GameObject[] trail;          //拖尾效果

    //判断怪物和目标的距离
    public float distance;
    public float battleRange;       //警戒范围-来自enemyProperties
    public float attackRange;       //攻击范围-来自enemyProperties
    public bool inRange;            //是不是在攻击范围
    public float attackTime;        //攻击计时器
    public bool canAttack;          //能不能进行攻击
    public bool isAttack;           //是不是正在攻击-来自enemyAnimationEvent
    public bool idleStatic;         //是否是原地待机还是巡逻待机
    public float idleChangeTimer;   //切换待机状态计时器

    public bool onTop;              //玩家站在头顶

    void Awake()
    {
        anim = gameObject.GetComponentInChildren<Animator>();
        cc = gameObject.GetComponent<CharacterController>();
        enemyAudio = GetComponent<EnemyAudio>();
        enemyProperties = GetComponent<EnemyProperties>();
        enemyDropList = GetComponent<EnemyDropList>();
        nav = GetComponent<NavMeshAgent>();
    }

    void Start()
    {
        target = GameObject.FindGameObjectWithTag("Player");
        targetAttackPoint = CharacterBehaviour.GetInstace.attackPoint;
        attackRange = enemyProperties.attackRange;
        battleRange = enemyProperties.battleRange;
        nav.speed = enemyProperties.runSpeed;
        nav.angularSpeed = enemyProperties.angularSpeed;
        SceneSetting.GetInstance.AddEnemy();                        //敌人数量 +1
    }

    void Update()
    {
        //玩家死亡 怪物停止行动
        if (ActorPropertiesFinal.GetInstance.IsDead)
        {
            state = EEnemyState.Idle;
            if (!anim.GetBool("PlayerDead"))
            {
                Debug.Log("PlayerDead");
                Destroy(cc);
                anim.SetBool("PlayerDead", true);
            }
            return;
        }

        distance = Vector3.Distance(this.transform.position, target.transform.position);
        attackTime += Time.deltaTime;

        if (state == EEnemyState.Die)
        {
            return;
        }

        if (distance > enemyProperties.battleRange)
        {
            state = EEnemyState.Idle;
            anim.SetBool("BattleState", false);
        }
        else
        {
            if (state == EEnemyState.Idle)
            {
                idleChangeTimer = 0f;           //如果改变了状态，Idle计时器清零
            }
            state = EEnemyState.Battle;
            anim.SetBool("BattleState", true);
        }

        if (state == EEnemyState.Idle)          //闲置状态
        {
            nav.enabled = false;
            idleChangeTimer += Time.deltaTime;

            if (idleChangeTimer > 10f)
            {
                //待机时间到了 随机一个角度
                idleChangeTimer = 0f;
                int newAngle = Random.Range(0, 360);
                gameObject.transform.rotation = Quaternion.Euler(new Vector3(0f, newAngle, 0f));

                idleStatic = (Random.Range(0, 2) == 0);
                if (idleStatic)
                {
                    anim.SetBool("IdleStatic", true);
                }
                else
                {
                    anim.SetBool("IdleStatic", false);
                }
            }

            if (idleStatic)
            {
                //什么都不做
            }
            else
            {
                cc.SimpleMove(gameObject.transform.forward * enemyProperties.walkSpeed);
            }
        }
        else if (state == EEnemyState.Battle)   //战斗状态
        {
            inRange = (distance <= attackRange);
            canAttack = (attackTime > enemyProperties.attackCd);

            if (inRange) //在攻击距离内就要判断是不是要发起攻击
            {
                //远程怪物
                if (enemyProperties.enemyAttackDistanceType == eEnemyAttackDistanceType.Range)
                {
                    //如果玩家在头顶，就会开始移动
                    if (!isAttack && onTop)//***此处修改了
                    {
                        isAttack = false;
                        cc.SimpleMove(gameObject.transform.forward * enemyProperties.runSpeed);
                    }
                    else
                    {
                        RaycastHit hit;
                        Vector3 dir = targetAttackPoint.transform.position - this.attackPoint.transform.position;
                        Physics.Raycast(this.attackPoint.transform.position, dir, out hit, attackRange);
                        //Debug.Log (hit.collider);

                        if (hit.collider != null)
                        {
                            if (hit.collider.CompareTag("Player"))
                            {
                                anim.SetBool("InRange", true);
                                nav.enabled = false;
                                if (canAttack)
                                {
                                    this.transform.LookAt(new Vector3(targetAttackPoint.transform.position.x, this.transform.position.y, targetAttackPoint.transform.position.z));
                                    attackTime = 0f;
                                    anim.SetTrigger("Attack");
                                }
                                if (!isAttack)
                                {
                                    this.transform.LookAt(new Vector3(target.transform.position.x, this.transform.position.y, target.transform.position.z));
                                }
                            }
                            else
                            {
                                nav.enabled = true;
                                anim.SetBool("InRange", false);
                                nav.SetDestination(target.transform.position);
                            }
                        }
                        else
                        {
                            nav.enabled = true;
                            anim.SetBool("InRange", false);
                            nav.SetDestination(target.transform.position);
                        }
                    }
                }
                //近战怪物
                else if (enemyProperties.enemyAttackDistanceType == eEnemyAttackDistanceType.Melee)
                {
                    anim.SetBool("InRange", inRange);
                    //停下脚步开始攻击
                    nav.enabled = false;
                    //如果玩家在头顶，就会开始移动
                    if (!isAttack && onTop)//***此处修改了
                    {
                        isAttack = false;
                        cc.SimpleMove(gameObject.transform.forward * enemyProperties.runSpeed);
                    }
                    else //如果玩家不在头顶，就会开始判断攻击
                    {
                        //不在攻击时就要瞄准玩家
                        if (!isAttack)
                        {
                            this.transform.LookAt(new Vector3(target.transform.position.x, this.transform.position.y, target.transform.position.z));
                        }
                        //攻击时要先瞄准
                        if (canAttack)
                        {
                            this.transform.LookAt(new Vector3(target.transform.position.x, this.transform.position.y, target.transform.position.z));
                            //设置动画
                            attackTime = 0f;
                            anim.SetTrigger("Attack");
                        }
                    }
                }
            }
            else
            {
                nav.enabled = true;
                anim.SetBool("InRange", false);
                nav.SetDestination(target.transform.position);
            }
        }
        else
        {
            anim.SetBool("IdleStatic", true);
            anim.SetBool("BattleState", false);
            anim.SetBool("InRange", false);
        }
    }

    public void BeenHit()
    {
        anim.SetTrigger("Hit");
    }

    public void Die()
    {
        state = EEnemyState.Die;
        enemyAudio.Die();
        anim.SetTrigger("Die");
        GameObject.Instantiate(enemyProperties.hit, gameObject.transform);
        enemyDropList.Drop();                                                                   //物品掉落
        SceneSetting.GetInstance.MinusEnemy();                                                 //敌人数量 -1
        ActorPropertiesBase.GetInstance.ChangeExperience(enemyProperties.exp);                 //让玩家获得经验值

        Destroy(this);
        Destroy(this.cc);
        Destroy(this.gameObject, 2.5f);
    }

    void ProjectBullet(GameObject Projection)
    {
        //开始攻击
        EnemyProjectionBullet tempEnemyProjection = Projection.GetComponent<EnemyProjectionBullet>();
        tempEnemyProjection.origin = this.attackPoint;
        tempEnemyProjection.target = target.GetComponent<CharacterBehaviour>().attackPoint;
        tempEnemyProjection.physicalDamage = enemyProperties.atk;
        tempEnemyProjection.magicDamage = enemyProperties.mgk;
        tempEnemyProjection.ignoreBlock = enemyProperties.projectionIgnoreBlock;
        tempEnemyProjection.lastTime = enemyProperties.projectionLastTime;
        tempEnemyProjection.moveSpeed = enemyProperties.projectionMoveSpeed;
    }

    void ProjectArrow(GameObject Projection)
    {
        //开始攻击
        EnemyProjectionArrow tempEnemyProjection = Projection.GetComponent<EnemyProjectionArrow>();
        tempEnemyProjection.origin = this.attackPoint;
        tempEnemyProjection.target = target.GetComponent<CharacterBehaviour>().attackPoint;
        tempEnemyProjection.physicalDamage = enemyProperties.atk;
        tempEnemyProjection.magicDamage = enemyProperties.mgk;
        tempEnemyProjection.ignoreBlock = enemyProperties.projectionIgnoreBlock;
        tempEnemyProjection.lastTime = enemyProperties.projectionLastTime;
        tempEnemyProjection.moveSpeed = enemyProperties.projectionMoveSpeed;
        tempEnemyProjection.gravityValue = enemyProperties.projectionGravity;
    }

    public void RangeAttack()
    {
        GameObject Projection = Instantiate(enemyProperties.bulletPrefab, this.attackPoint.transform.position, Quaternion.LookRotation(targetAttackPoint.transform.position - this.attackPoint.transform.position));
        enemyAudio.Attack();
        //抛物线还是直线攻击
        switch (Projection.GetComponent<EnemyProjection>().type)
        {
            case EProjectionType.arrow:
                ProjectArrow(Projection);
                break;
            case EProjectionType.bullet:
                ProjectBullet(Projection);
                break;
            default:
                break;
        }
    }

    public void MeleeAttack()
    {
        //获得攻击目标
        Collider[] hitColliders = Physics.OverlapSphere(attackPoint.transform.position, this.enemyProperties.attackDamageRange);

        //音效
        enemyAudio.Attack();

        for (int i = 0; i < hitColliders.Length; i++)
        {
            if (hitColliders[i].CompareTag("Player"))
            {
                Vector3 playerHitPoint = hitColliders[i].GetComponent<CharacterBehaviour>().attackPoint.transform.position;
                if (Vector3.Dot(Vector3.Normalize(this.attackPoint.transform.forward), Vector3.Normalize(playerHitPoint - this.attackPoint.transform.position)) >= Mathf.Cos((enemyProperties.attackAngle / 2) * Mathf.Deg2Rad))
                {
                    //造成伤害
                    if (enemyProperties.atk > 0 || enemyProperties.mgk > 0)
                    {
                        if (ActorPropertiesFinal.GetInstance.TakeDamage(enemyProperties.atk, enemyProperties.mgk, this.gameObject))
                        {
                            //音效
                            enemyAudio.Hit();
                        }
                    }
                }
            }
        }
    }

}

public enum EEnemyState
{
    Idle,
    Battle,
    Die
}