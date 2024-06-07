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
}
