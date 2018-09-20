using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyProjectionArrow : EnemyProjection
{
    public float gravityValue = -4f;
    float initialAddSpeed;
    Vector3 direction;
    float distance;
    float hitTime;
    float gravitySpeed;
    float angle;

    void Start()
    {
        direction = Vector3.Normalize(target.transform.position - origin.transform.position);
        distance = Vector3.Distance(origin.transform.position, target.transform.position);
        hitTime = distance / moveSpeed;
        initialAddSpeed = -0.5f * gravityValue * hitTime;
        gravitySpeed = initialAddSpeed;
    }

    void Update()
    {
        timer += Time.deltaTime;

        Vector3 move = moveSpeed * direction * Time.deltaTime;
        gravitySpeed += gravityValue * Time.deltaTime;
        Vector3 moveGravity = new Vector3(0f, gravitySpeed * Time.deltaTime, 0f);
        transform.Translate(move + moveGravity, Space.World);

        transform.rotation = Quaternion.LookRotation(Vector3.Normalize(move + moveGravity));


        if (timer > lastTime)
        {
            if (destroyParticle != null)
            {
                Instantiate(destroyParticle, this.transform.position, Quaternion.AngleAxis(Random.Range(0, 360f), Vector3.up));
            }
            Destroy(this.gameObject);
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            if (physicalDamage > 0f || magicDamage > 0f)
            {
                isHit = ActorProperty.GetInstance.TakeDamage(physicalDamage, magicDamage, origin);
            }
            if (isHit)
            {
                if (isHit && destroyParticle != null)
                {
                    Instantiate(destroyParticle, this.transform.position, Quaternion.AngleAxis(Random.Range(0, 360f), Vector3.up));
                }
            }
            Destroy(this.gameObject);
        }
        else if (other.CompareTag("Block") || other.CompareTag("Ground"))
        {
            if (!ignoreBlock)
            {
                if (destroyParticle != null)
                {
                    Instantiate(destroyParticle, this.transform.position, Quaternion.AngleAxis(Random.Range(0, 360f), Vector3.up));
                }
                Destroy(this.gameObject);
            }
        }
    }
}
