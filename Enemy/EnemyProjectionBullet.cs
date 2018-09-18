using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyProjectionBullet : EnemyProjection
{

    void Update()
    {
        timer += Time.deltaTime;
        transform.Translate(transform.forward * moveSpeed * Time.deltaTime, Space.World);
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
                isHit = ActorPropertiesFinal.GetInstance.TakeDamage(physicalDamage, magicDamage, origin);
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
