using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trash : MonoBehaviour
{
	[SerializeField] Rigidbody2D _rigidbody2D;
	Vector2 velocity;
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
			playerManager.ChangeLife(1);
			spawner.SpwanTrash();
			Destroy(gameObject);
		}

		velocity = -velocity;
		
		_rigidbody2D.velocity = velocity;
	}
}