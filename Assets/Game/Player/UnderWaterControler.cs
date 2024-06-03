using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnderWaterControler : Controler
{
	Swipe swipe;
	[SerializeField] Joystick joyStick;
	[SerializeField] float velocity;
	public Rigidbody2D _rigidbody2D {  get; set; }
	private void OnEnable()
	{
		if (swipe == null) swipe = GameManager.Instance.swipe;
	}
	
	public override void GetInput()
	{

	}
	
	public override void Move()
	{
		if (Mathf.Abs(joyStick.Direction.y) + Mathf.Abs(joyStick.Direction.x) >= 0.1)
		{
			var move = Mathf.Clamp(Mathf.Abs(joyStick.Direction.y) + Mathf.Abs(joyStick.Direction.x), 0, 1);
			_rigidbody2D.velocity = _rigidbody2D.transform.up * velocity * move;
			float angle = Mathf.Atan2(joyStick.Direction.y, joyStick.Direction.x) * Mathf.Rad2Deg;
			transform.eulerAngles = new Vector3(0, 0, angle - 90);
			return;
		}
		_rigidbody2D.velocity = Vector2.zero;

	}
	
	public override void Action()
	{
		
	}

}
