using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{
    [SerializeField]Transform targetPos;
    public bool openDoor = false;
	private void Update()
	{
		if (openDoor) 
		{
			transform.position = Vector2.Lerp(transform.position,targetPos.position,Time.deltaTime);
		}
	}
}
