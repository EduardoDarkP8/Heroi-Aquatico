using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    [SerializeField]UnderWaterControler underWaterControler;
	[SerializeField]OverWaterControler overWaterControler;
	Controler currentControler;
	[SerializeField]Rigidbody2D _rigidbody2D;
	[SerializeField]int life;
	[SerializeField] ControlerType initalType;
	public AudioSource audioSource;
	private void Start()
	{
		SwitchWaterControl(initalType);
		underWaterControler._rigidbody2D = _rigidbody2D;
		overWaterControler._rigidbody2D = _rigidbody2D;
	}
	public void SwitchWaterControl(ControlerType controlerType)  
	{
		switch (controlerType) 
		{
			case ControlerType.run: currentControler = overWaterControler;
				underWaterControler.enabled = false;
				overWaterControler.enabled = true;
				transform.eulerAngles = new Vector3(0, 0, 0); 
				_rigidbody2D.gravityScale = 1;
				overWaterControler.waterGun.gameObject.SetActive(true);
				_rigidbody2D.constraints = RigidbodyConstraints2D.FreezeRotation;
				
				break;
			case ControlerType.swim: 
				currentControler = underWaterControler;
				overWaterControler.waterGun.gameObject.SetActive(false);
				underWaterControler.enabled = true;
				overWaterControler.enabled = false;
				_rigidbody2D.gravityScale = 0;
				_rigidbody2D.constraints = RigidbodyConstraints2D.None;
				break;

		}
	}
	public void ChangeLife(int delta) 
	{
		life -= delta;
		if (life <= 0) 
		{
			Destroy(gameObject);
		}
	}
	private void FixedUpdate()
	{
		currentControler.Move();
		
	}
	private void Update()
	{
		if (currentControler.isMoving && !audioSource.isPlaying) 
		{
			audioSource.PlayOneShot(currentControler.moveSound);
		}
	}
}
public enum ControlerType
{
	run,
	swim
}