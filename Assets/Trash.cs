using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trash : MonoBehaviour
{
	[SerializeField] Rigidbody2D _rigidbody2D;
	Vector2 velocity;
	[SerializeField] AudioSource source;
	[SerializeField] Collider2D _collider;
	[SerializeField] SpriteRenderer _renderer;
	public TrashSpawner spawner { get; set; }
	private void Start()
	{
		_rigidbody2D.velocity = new Vector2(Random.Range((int)-1, (int)2), Random.Range((int)-1, (int)2))*2;
		if (_rigidbody2D.velocity == Vector2.zero) _rigidbody2D.velocity = new Vector2(1,1);
		velocity = _rigidbody2D.velocity;
	}
	private void OnCollisionEnter2D(Collision2D collision)
	{
		if (collision.gameObject.TryGetComponent(out PlayerManager playerManager))
		{
			source.Play();
			_collider.enabled = false;
			_renderer.enabled = false;

			playerManager.ChangeLife(1);
			spawner.DelaySpwan();
			Destroy(gameObject, 2);
		}

		velocity = -velocity;
		source.Play();
		_rigidbody2D.velocity = velocity;
	}
}