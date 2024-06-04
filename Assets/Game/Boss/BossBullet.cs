using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossBullet : MonoBehaviour
{
    [SerializeField] Rigidbody2D rb;
    
    private void OnTriggerEnter(Collider other)
    {
        Destroy(gameObject);
    }
    public void SetTarget(Vector3 directio) 
    {
        rb.velocity = directio * 3;
    }

}
