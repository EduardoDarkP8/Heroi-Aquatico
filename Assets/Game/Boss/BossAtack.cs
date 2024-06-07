using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class BossAtack : MonoBehaviour
{
    [SerializeField]protected PlayerManager playerManager;
	[SerializeField] protected BossManager bossManager;
    public virtual IEnumerator AtackRoutine()
    {
        yield return null;
    }
}
