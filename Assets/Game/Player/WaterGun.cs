using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaterGun : MonoBehaviour
{
    [SerializeField]Transform shotPoint;
    [SerializeField]float coolDown;
    bool canShot = true;
    [SerializeField] Bullet bullet;
    [SerializeField] AudioSource bulletSource;
    
    public void Shot(float velocity) 
    {
        if (canShot) 
        {
            if (!bulletSource.isPlaying) 
            { 
                bulletSource.Play();
            }
            canShot = false;
            var b = Instantiate(bullet,shotPoint.position, shotPoint.rotation);
            b.Impulse(velocity);
            StartCoroutine(ShotWait());
        }
    }
    public void GunRotate(Vector2 dir, bool right)
    {
        dir.x =  right ? Mathf.Clamp(dir.x, 0, 1) : Mathf.Clamp(dir.x, -1, 0);
        var angle = (Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg) - 90;

        transform.eulerAngles = new Vector3(0, 0, angle);
    }
    IEnumerator ShotWait() 
    {
        yield return new WaitForSeconds(coolDown);
        canShot = true;
    }
}
