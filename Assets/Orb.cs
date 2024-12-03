using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static Unity.VisualScripting.Member;

public class Orb : MonoBehaviour
{
	[SerializeField] Door targetDoor;
	[SerializeField] AudioSource source;
	[SerializeField] Collider2D _collider;
	[SerializeField] SpriteRenderer _renderer;
	private void OnTriggerEnter2D(Collider2D collision)
	{

		if (collision.TryGetComponent(out PlayerManager playerManager)) 
		{
			source.Play();
			targetDoor.openDoor = true;
			_collider.enabled = false;
			_renderer.enabled = false;
			Destroy(gameObject, 2f);
		}
	}
}
