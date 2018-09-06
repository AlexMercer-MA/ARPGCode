using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SingletonMonoBase<T> : MonoBehaviour {

    protected T instance;

    public T GetInstance
    {
        get { return instance; }
    }
}
