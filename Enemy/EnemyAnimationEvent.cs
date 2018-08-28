using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAnimationEvent : MonoBehaviour
{
    public EnemyProperties enemyProperties;
    public EnemyBehaviour enemyBehaviour;

    public void AttackStart()
    {
        enemyBehaviour.isAttack = true;
    }

    public void AttackOver()
    {
        enemyBehaviour.isAttack = false;
    }

    public void MeleeAttack()
    {
        if (enemyBehaviour != null)
        {
            enemyBehaviour.MeleeAttack();
        }
    }

    public void RangeAttack()
    {
        if (enemyBehaviour != null)
        {
            enemyBehaviour.RangeAttack();
        }
    }

    public void AmmoOrCastStart()
    {
        if (enemyBehaviour.ammoORcast.Length > 0)
        {
            foreach (var item in enemyBehaviour.ammoORcast)
            {
                item.SetActive(true);
            }
        }
    }

    public void AmmoOrCastOver()
    {
        if (enemyBehaviour.ammoORcast.Length > 0)
        {
            foreach (var item in enemyBehaviour.ammoORcast)
            {
                item.SetActive(false);
            }
        }
    }

    public void TrailStart()
    {
        if (enemyBehaviour.trail.Length > 0)
        {
            foreach (var item in enemyBehaviour.trail)
            {
                item.SetActive(true);
            }
        }
    }

    public void TrailOver()
    {
        if (enemyBehaviour.trail.Length > 0)
        {
            foreach (var item in enemyBehaviour.trail)
            {
                item.SetActive(false);
            }
        }
    }

    public void SlowMotionStart(float speed)
    {
        enemyBehaviour.anim.speed = speed;
    }

    public void SlowMotionOver()
    {
        enemyBehaviour.anim.speed = 1.0f;
    }

    public void Die()
    {
        AmmoOrCastOver();
        TrailOver();
        SlowMotionOver();
    }
}
