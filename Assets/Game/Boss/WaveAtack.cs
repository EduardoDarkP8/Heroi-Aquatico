using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaveAtack : BossAtack
{
	[SerializeField] Wave prefab;
	[SerializeField] Transform[] wavePoints;
	public override IEnumerator AtackRoutine()
	{
		var wave = Instantiate(prefab, wavePoints[Random.Range(0, wavePoints.Length)].position, Quaternion.identity);
		wave.SetVelocity(playerManager.transform.position.x > wave.transform.position.x ? 1 : -1);
		yield return new WaitForSeconds(2f);
		bossManager.BossAtack(Random.Range(0, 3));
	}
}
