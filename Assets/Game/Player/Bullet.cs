using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField]Rigidbody2D rb;
    [SerializeField]SpriteRenderer rbSprite;
    [SerializeField]Collider2D _collider;
    [SerializeField]TrailRenderer _trailRenderer;
    public void Impulse(float direction)
    {
        if (direction > 0) 
        { 
            rb.AddForce(transform.right * 1000);
        }
        else rb.AddForce(transform.right * -1000);

		StartCoroutine(DestroyRay(3f));
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.gameObject.TryGetComponent(out BossLife bossLife)) 
        {
            bossLife.DealDamage(10);
        }
        StartCoroutine(DestroyRay(0));
        
    }
    IEnumerator DestroyRay(float waitTime) 
    {
        yield return new WaitForSeconds(waitTime);
        if (rb != null) 
        { 
            rb.velocity = Vector3.zero;
            Destroy(rb);
            Destroy(_collider);
        }
        yield return new WaitUntil(() => {
            return _trailRenderer.positionCount <= 0;
        });
        rbSprite.enabled = false;
        Destroy(gameObject,1f);
    }


}
