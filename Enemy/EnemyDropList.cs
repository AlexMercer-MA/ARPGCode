using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDropList : MonoBehaviour
{
    public List<DropList> List;

    public void Drop()
    {
        foreach (var item in List)
        {
            if (item.chance >= Random.Range(0.0f, 1.0f))
            {
                Instantiate(item.dropItem, this.transform.position, Quaternion.identity);
            }
        }
    }
}

[System.Serializable]
public class DropList
{
    public float chance;
    public GameObject dropItem;
}

