using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class BossAtack : MonoBehaviour
{
    public PlayerManager playerManager { get; set; }
    public BossManager bossManager { get; set; }
    public virtual IEnumerator AtackRoutine()
    {
        yield return null;
    }
}
