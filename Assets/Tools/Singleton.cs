using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Singleton<T> : MonoBehaviour where T : MonoBehaviour 
{
    public static T Instance;
    public virtual void Awake() 
    {
        if (Instance == null) 
        {
            Instance = this as T;
            return;
        }
        Destroy(gameObject);
        
    }
}
