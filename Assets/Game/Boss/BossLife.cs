using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossLife : MonoBehaviour
{
    [SerializeField] int life;
    public void DealDamage(int Delta) 
    {
        life -= Delta;
        if (life < 0) 
        {
            Destroy(gameObject);
        }
    }
}
