using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartBoss : MonoBehaviour
{
	[SerializeField]BossManager bossManager;
	[SerializeField] Collider2D _collider;
	private void OnTriggerEnter2D(Collider2D collision)
	{
		if (collision.TryGetComponent(out PlayerManager playerManager))
		{
			StartCoroutine(bossManager.atacks[0].AtackRoutine());
			_collider.enabled = false;
			Destroy(gameObject,8f);
		}
	}
}