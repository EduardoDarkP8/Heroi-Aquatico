using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MultiShotAtack : BossAtack
{
    BossBullet prefab;
    Transform[] shotPoints;

    public override IEnumerator AtackRoutine()
    {
        List<BossBullet> list = new List<BossBullet>();
        foreach (var t in shotPoints) 
        {
            list.Add(Instantiate(prefab, t.position, Quaternion.identity));
            yield return new WaitForSeconds(0.3f);
        }
        foreach (var b in list)
        {
            b.SetTarget((playerManager.transform.position - transform.position).normalized);
            yield return new WaitForSeconds(0.3f);
        }
        bossManager.BossAtack(Random.Range(0,3));
    }

}
