using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wave : MonoBehaviour
{
    [SerializeField] Rigidbody2D _rigidbody2D;
    public void SetVelocity(float x) 
    {
        _rigidbody2D.velocity = new Vector2(x*5,_rigidbody2D.velocity.y);
    }
	private void OnTriggerEnter2D(Collider2D collision)
	{
        if (collision.TryGetComponent(out PlayerManager playerManager)) playerManager.ChangeLife(1); 
		Destroy(gameObject);
	}
}
