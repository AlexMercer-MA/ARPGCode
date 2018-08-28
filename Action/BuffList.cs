using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BuffList : MonoBehaviour
{
    public static BuffList instance;
    public float[] buffTime = new float[2];
    public GameObject[] buffUI = new GameObject[2];

    /*
     * 0 potion
     * 1 warrior_rage
     * 2
     */

    void Awake()
    {
        instance = this;

        for (int i = 0; i < this.transform.childCount; i++)
        {
            buffUI[i] = this.transform.GetChild(i).gameObject;
        }
    }

    void Update()
    {
        for (int i = 0; i < buffTime.Length; i++)
        {
            if (buffTime[i] > 0f)
            {
                buffTime[i] -= Time.deltaTime;

                if (buffTime[i] > 0f)
                {
                    buffUI[i].GetComponentInChildren<Text>().text = Mathf.CeilToInt(buffTime[i]) + "s";
                }
                else
                {
                    buffTime[i] = 0f;
                    buffUI[i].SetActive(false);
                }
            }
        }
    }

    public void StartBuff(int index, float time)
    {
        buffTime[index] = time;
        buffUI[index].SetActive(true);
    }
}
