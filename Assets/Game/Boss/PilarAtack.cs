using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PilarAtack : BossAtack
{
	[SerializeField] Pilar prefab;
	[SerializeField] Transform[] pilarPoints;
	public override IEnumerator AtackRoutine()
	{
		var nums = new List<int>();
		int i = 0;
		foreach (var p in pilarPoints) 
		{ 
			nums.Add(i);
			i++;
		}
		for (var j = 0; j < pilarPoints.Length; j++) 
		{
			var index = Random.Range(0, nums.Count);
			var value = nums[index];
			Instantiate(prefab, pilarPoints[value].position, Quaternion.identity);
			nums.Remove(value);
			yield return new WaitForSeconds(1f);
		}
		yield return new WaitForSeconds(3f);
		bossManager.BossAtack(Random.Range(0, 3));
	}
}
