using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemObjTrigger : MonoBehaviour {

    public void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            GameEventManager.GetInstance.EvtTriggerEnter(this.gameObject, eTriggerType.Item);
        }
    }

    public void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            GameEventManager.GetInstance.EvtTriggerStay(this.gameObject, eTriggerType.Item);
        }
    }

    public void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            GameEventManager.GetInstance.EvtTriggerExit(this.gameObject, eTriggerType.Item);
        }
    }
}
