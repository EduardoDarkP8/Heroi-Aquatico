using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pilar : MonoBehaviour
{
    int life = 5;
	[SerializeField] AudioSource source;
	[SerializeField] Collider2D _collider;
	[SerializeField] SpriteRenderer _renderer;
	private void OnTriggerEnter2D(Collider2D collision)
	{
		if (collision.gameObject.TryGetComponent(out Bullet bullet))
		{
			life -= 1;
			if(life <= 0) Destroy(gameObject);
		}
	}
	private void OnCollisionEnter2D(Collision2D collision)
	{
		if (collision.gameObject.TryGetComponent(out PlayerManager playerManager))
		{
			playerManager.ChangeLife(1);
			source.Play();
			_collider.enabled = false;
			_renderer.enabled = false;
			Destroy(gameObject, 2f);

		}
		source.Play();
		_collider.enabled = false;
		_renderer.enabled = false;
		Destroy(gameObject, 2f);

	}

}
