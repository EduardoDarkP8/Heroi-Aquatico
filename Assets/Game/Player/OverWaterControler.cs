using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OverWaterControler : Controler
{
	Swipe swipe;
	[SerializeField] Joystick joyStick;
	[SerializeField] float velocity;
	public Rigidbody2D _rigidbody2D { get; set; }
	public Transform feet;
	float currentTime;
	[SerializeField] WaterGun waterGun;

	private void OnEnable()
	{
		swipe = GameManager.Instance.swipe;
		swipe.OnMoveSwipe1.AddListener(FirstShot);
		swipe.OnMoveSwipe2.AddListener(SecondShot);

		swipe.OnEndSwipe1.AddListener(FirstJump);
		swipe.OnEndSwipe2.AddListener(SecondJump);
		waterGun.gameObject.SetActive(true);
	}
	private void OnDisable()
	{
		swipe.OnMoveSwipe1.RemoveListener(FirstShot);
		swipe.OnMoveSwipe2.RemoveListener(SecondShot);

		swipe.OnEndSwipe1.RemoveListener(FirstJump);
		swipe.OnEndSwipe2.RemoveListener(SecondJump);
        waterGun.gameObject.SetActive(false);
    }

	
	public void FirstShot(Vector2 v)
	{
		if (Mathf.Abs(joyStick.Direction.y) + Mathf.Abs(joyStick.Direction.x) <= 0.1)
		{
			currentTime += Time.deltaTime;
			if (currentTime > 0.1f)
			{

				var direction = Camera.main.ScreenToWorldPoint(v);
				waterGun.GunRotate((direction - transform.position).normalized, transform.localScale.x > 0);
				waterGun.Shot();
			}
		}
	}
	public void SecondShot(Vector2 v)
	{
		currentTime += Time.deltaTime;
		if (currentTime > 0.1f) 
		{
            var direction = Camera.main.ScreenToWorldPoint(v);
            waterGun.GunRotate((direction - transform.position).normalized, transform.localScale.x > 0);
            waterGun.Shot();
        }
	}
	public void FirstJump(Vector2 v) 
	{
		if (Mathf.Abs(joyStick.Direction.y) + Mathf.Abs(joyStick.Direction.x) <= 0.1)
		{
			currentTime += Time.deltaTime;
			if (currentTime < 0.1f)
			{
				print("Jump");
			}
		}
		currentTime = 0;
	}
	public void SecondJump(Vector2 v)
	{
		currentTime += Time.deltaTime;
		if (currentTime < 0.1f)
		{
			print("Jump");
		}
		currentTime = 0;
	}
	public override void Move()
	{

		var move = new Vector2(joyStick.Direction.x * velocity, _rigidbody2D.velocity.y);
		_rigidbody2D.velocity = move;
		if (Mathf.Abs(joyStick.Direction.x) > 0.4)
		{
			var dir = joyStick.Direction.x;
			transform.localScale = new Vector3(dir > 0 ? Mathf.Abs(transform.localScale.x) : -Mathf.Abs(transform.localScale.x),
				transform.localScale.y,
				transform.localScale.z);
		}
	}
	public bool CheckGround() 
	{
		return Physics2D.OverlapCircle(feet.position, 0.1f);
	}
}
