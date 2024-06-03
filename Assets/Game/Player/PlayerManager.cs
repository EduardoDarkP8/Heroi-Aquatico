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
	private void Start()
	{
		SwitchWaterControl(ControlerType.run);
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
				_rigidbody2D.gravityScale = 1;
				_rigidbody2D.constraints = RigidbodyConstraints2D.FreezeRotation;
				
				break;
			case ControlerType.swim: currentControler = 
				underWaterControler;
				underWaterControler.enabled = true;
				overWaterControler.enabled = false;
				_rigidbody2D.gravityScale = 0;
				_rigidbody2D.constraints = RigidbodyConstraints2D.None;
				break;

		}
	}

	private void FixedUpdate()
	{
		currentControler.Move();
	}
}
public enum ControlerType
{
	run,
	swim
}