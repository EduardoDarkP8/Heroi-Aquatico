using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Controler : MonoBehaviour
{
    public AudioClip moveSound;
    public bool isMoving { get; protected set; }
	public virtual void GetInput()
	{

	}
	public virtual void Move() 
    {
        
    }

	public virtual void Action() 
    {
        
    }
}
