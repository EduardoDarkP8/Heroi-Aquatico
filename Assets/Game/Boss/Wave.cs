using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wave : MonoBehaviour
{
    [SerializeField] Rigidbody2D _rigidbody2D;
	[SerializeField] AudioSource source;
	[SerializeField] Collider2D _collider;
	[SerializeField] SpriteRenderer _renderer;
	public void SetVelocity(float x) 
    {
        _rigidbody2D.velocity = new Vector2(x*5,_rigidbody2D.velocity.y);
		transform.localScale = new Vector2(transform.localScale.x*-x, transform.localScale.y);
    }
	private void OnTriggerEnter2D(Collider2D collision)
	{
        if (collision.TryGetComponent(out PlayerManager playerManager)) playerManager.ChangeLife(1);
		source.Play();
		_collider.enabled = false;
		_renderer.enabled = false;
		Destroy(gameObject, 2f);

	}
}
