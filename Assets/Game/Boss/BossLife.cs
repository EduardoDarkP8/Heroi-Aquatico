using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BossLife : MonoBehaviour
{
    [SerializeField] int maxLife;
    int currentLife;
    [SerializeField] Sprite[] sprite;
	[SerializeField] SpriteRenderer spriteR;
	private void Start()
	{
        currentLife = maxLife;
		spriteR.sprite = sprite[0];
	}
	public void DealDamage(int Delta) 
    {
        
        currentLife -= Delta;
        if (currentLife <= maxLife * 0.66) 
        {
            spriteR.sprite = sprite[1];
        }
		if (currentLife <= maxLife * 0.33)
		{
			spriteR.sprite = sprite[2];
		}
		if (currentLife < 0) 
        {
			SceneManager.LoadScene("EndScene");
        }
    }
}
