using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrashSpawner : MonoBehaviour
{
    [SerializeField] Trash prefab;
    void Start()
    {
        SpwanTrash();
    }
    public void SpwanTrash() 
    {
        var trash = Instantiate(prefab, transform.position, Quaternion.identity);
        trash.spawner = this;
    }
    public void DelaySpwan() 
    {
        StartCoroutine(IDelaySpwan());
    }

	IEnumerator IDelaySpwan() 
    {
        yield return new WaitForSeconds(5f);
        SpwanTrash();
    }
}
