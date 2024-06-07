using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwapPlace : MonoBehaviour
{
	[SerializeField]Transform targetCameraPos;
	[SerializeField]Transform targetPlayerPos;
	[SerializeField] ControlerType controlerType;
	private void OnTriggerEnter2D(Collider2D collision)
	{
		if (collision.TryGetComponent(out PlayerManager playerManager)) 
		{
			Camera.main.transform.position = new Vector3(targetCameraPos.position.x, targetCameraPos.position.y, Camera.main.transform.position.z);
			playerManager.transform.position = targetPlayerPos.position;
			playerManager.SwitchWaterControl(controlerType);
		}
	}
}
