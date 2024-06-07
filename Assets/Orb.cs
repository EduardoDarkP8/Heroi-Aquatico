using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Orb : MonoBehaviour
{
	[SerializeField] Door targetDoor;
	private void OnTriggerEnter2D(Collider2D collision)
	{
		if (collision.TryGetComponent(out PlayerManager playerManager)) 
		{ 
			targetDoor.openDoor = true;
			Destroy(gameObject);
		}
	}
}
