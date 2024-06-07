using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossManager : MonoBehaviour
{
    public BossAtack[] atacks;
    public PlayerManager manager;
	public void BossAtack(int i) 
    {
        StartCoroutine(atacks[i].AtackRoutine());
    }
}
