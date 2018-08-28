using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyProjection : MonoBehaviour
{
    public GameObject destroyParticle;
    public float moveSpeed;
    public float lastTime;
    public int physicalDamage;
    public int magicDamage;
    public GameObject origin;
    public GameObject target;
    public bool ignoreBlock;
    public float timer;
    public bool isHit;
    public EProjectionType type;

}

public enum EProjectionType
{
    arrow,
    bullet
}

