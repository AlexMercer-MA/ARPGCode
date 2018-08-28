using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PortalTrigger : MonoBehaviour
{

    public void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            GameEventManager.GetInstance.EvtTriggerEnter(this.gameObject, eTriggerType.Portal);
        }
    }

    public void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            GameEventManager.GetInstance.EvtTriggerStay(this.gameObject, eTriggerType.Portal);
        }
    }

    public void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            GameEventManager.GetInstance.EvtTriggerExit(this.gameObject, eTriggerType.Portal);
        }
    }





















 //   public bool bIsInTriggerArea;

	//void Start ()
 //   {
 //       InputEventManager.GetInstance.EvtInteractKeyPressed += OnInteractiveKeyPressed;
 //   }

 //   public void OnTriggerEnter(Collider other)
 //   {
 //       if (other.CompareTag("Player"))
 //       {
 //           ScreenSpaceUIManager.GetInstance.EvtInteractiveHint_Open_Interactive();
 //           bIsInTriggerArea = true;
 //       }
 //   }

 //   public void OnTriggerStay(Collider other)
 //   {
 //       if (ScreenSpaceUIManager.GetInstance.bIsInteractiveHintShow)
 //       {
 //           if (PanelUIManager.GetInstance.bInCenterPanelUIMode || PanelUIManager.GetInstance.b_Tab_PanelOpen)
 //           {
 //               ScreenSpaceUIManager.GetInstance.EvtInteractiveHint_Close();
 //           }
 //           return;
 //       }
        
 //       if (other.CompareTag("Player"))
 //       {
 //           ScreenSpaceUIManager.GetInstance.EvtInteractiveHint_Open_Interactive();
 //       }
 //   }

 //   public void OnTriggerExit(Collider other)
 //   {
 //       if (other.CompareTag("Player"))
 //       {
 //           ScreenSpaceUIManager.GetInstance.EvtInteractiveHint_Close();
 //           GameEventManager.GetInstance.EvtPortalTriggerExit();
 //           bIsInTriggerArea = false;
 //       }
 //   }

 //   public void OnInteractiveKeyPressed()
 //   {
 //       if (bIsInTriggerArea)
 //       {
 //           PanelUIEventManager.GetInstance.EvtPortalEnterPanel_Open();
 //       }
 //   }
}
