using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossBullet : MonoBehaviour
{
    [SerializeField] Rigidbody2D rb;

	private void OnTriggerEnter2D(Collider2D collision)
	{
		if (collision.TryGetComponent(out PlayerManager playerManager)) playerManager.ChangeLife(1);
		Destroy(gameObject);
    }
    public void SetTarget(Vector3 directio) 
    {
        if (rb != null) 
        { 
		rb.velocity = directio * 3;
		Destroy(gameObject, 10f);
        }
    }

}
