using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DungeonTrigger : MonoBehaviour
{

    public void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            GameEventManager.GetInstance.EvtTriggerEnter(this.gameObject, eTriggerType.DungeonEnter);
        }
    }

    public void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            GameEventManager.GetInstance.EvtTriggerStay(this.gameObject, eTriggerType.DungeonEnter);
        }
    }

    public void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            GameEventManager.GetInstance.EvtTriggerExit(this.gameObject, eTriggerType.DungeonEnter);
        }
    }

}
