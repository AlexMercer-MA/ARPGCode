using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBoss_SkeletonKing : MonoBehaviour
{
    public EnemyBehaviour enemyBehaviour;
    public EnemyProperties enemyProperties;
    public GameObject fireballprepare;
    public GameObject fireball;

    // Use this for initialization
    void Start()
    {
        InvokeRepeating("CastFireBallPrepare", 2f, 10f);
    }

    void CastFireBallPrepare()
    {
        Instantiate(fireballprepare, enemyBehaviour.hitPoint.transform.position, Quaternion.identity);
        Invoke("CastFireBall", 1.0f);
    }

    void CastFireBall()
    {
        for (int i = 0; i < 8; i++)
        {
            GameObject Projection = Instantiate(fireball, enemyBehaviour.hitPoint.transform.position, Quaternion.Euler(10.0f, 45.0f * i, 0));
            EnemyProjectionBullet tempEnemyProjection = Projection.GetComponent<EnemyProjectionBullet>();
            tempEnemyProjection.magicDamage = enemyProperties.atk;
            tempEnemyProjection.ignoreBlock = false;
            tempEnemyProjection.lastTime = 4.0f;
            tempEnemyProjection.moveSpeed = 6.0f;
        }
    }
}
