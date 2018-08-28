using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundCheck : MonoBehaviour
{

    public bool groundCheckBool;

    public int triggerNums = 0;

    void Update()
    {
        //Debug.Log (triggerNums);
        if (triggerNums == 0)
        {
            groundCheckBool = false;
        }
        else
        {
            groundCheckBool = true;
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Ground"))
        {
            triggerNums++;
            PlayerAudio.GetInstance.Land();
            //Debug.Log ("Land");
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Ground"))
        {
            triggerNums--;
        }
    }
}
