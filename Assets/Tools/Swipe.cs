using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Swipe : MonoBehaviour
{
    Touch touch1;
	Touch touch2;
	public Vector2 swipeInitialPos1 { get; private set; }
    public Vector2 swipeCurrentPos1 { get; private set; }
    public Vector2 swipeEndPos1 { get; private set; }
	public Vector2 swipeInitialPos2 { get; private set; }
	public Vector2 swipeCurrentPos2 { get; private set; }
	public Vector2 swipeEndPos2 { get; private set; }
	public UnityEvent<Vector2> OnStartSwipe1 { get; private set; }
	public UnityEvent<Vector2> OnMoveSwipe1 { get; private set; }
	public UnityEvent<Vector2> OnEndSwipe1 { get; private set; }
	public UnityEvent<Vector2> OnStartSwipe2 { get; private set; }
	public UnityEvent<Vector2> OnMoveSwipe2 { get; private set; }
	public UnityEvent<Vector2> OnEndSwipe2 { get; private set; }
	private void Awake()
	{
        OnStartSwipe1 = new UnityEvent<Vector2>();
        OnMoveSwipe1 = new UnityEvent<Vector2>();
        OnEndSwipe1 = new UnityEvent<Vector2>();
		OnStartSwipe2 = new UnityEvent<Vector2>();
		OnMoveSwipe2 = new UnityEvent<Vector2>();
		OnEndSwipe2 = new UnityEvent<Vector2>();
	}

	void Update()
    {
        SwipeUpdate();
    }
    public void SwipeUpdate() 
    {
        if (Input.touchCount > 0)
        {
            touch1 = Input.GetTouch(0);
            if (touch1.phase == TouchPhase.Began) 
            {
                swipeInitialPos1 = touch1.position;
                OnStartSwipe1.Invoke(swipeInitialPos1);
                
            }
            else if (touch1.phase == TouchPhase.Moved || touch1.phase == TouchPhase.Stationary)
            {
                swipeCurrentPos1 = touch1.position;
                OnMoveSwipe1.Invoke(swipeCurrentPos1);
				
			}
            else if (touch1.phase == TouchPhase.Ended)
			{
				swipeEndPos1 = touch1.position;
				OnEndSwipe1.Invoke(swipeCurrentPos1);
			}

			if (touch2.phase == TouchPhase.Began)
			{
				swipeInitialPos2 = touch2.position;
				OnStartSwipe2.Invoke(swipeInitialPos2);
			}
			else if (touch2.phase == TouchPhase.Moved || touch2.phase == TouchPhase.Stationary)
			{
				swipeCurrentPos2 = touch2.position;
				OnMoveSwipe2.Invoke(swipeCurrentPos2);
			}
			else if (touch2.phase == TouchPhase.Ended)
			{
				swipeEndPos2 = touch2.position;
				OnEndSwipe2.Invoke(swipeCurrentPos2);
			}
		}
    }
}
