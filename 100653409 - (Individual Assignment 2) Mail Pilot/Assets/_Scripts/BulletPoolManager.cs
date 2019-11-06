using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// TODO: Bonus - make this class a Singleton!

[System.Serializable]
public class BulletPoolManager : MonoBehaviour
{
    public GameObject bullet;

    //TODO: create a structure to contain a collection of bullets
    public int bulletAmount = 50;
    public Queue<GameObject> bulletList = new Queue<GameObject>();

    // Start is called before the first frame update
    void Start()
    {
        // TODO: add a series of bullets to the Bullet Pools
        for (int i = 0; i < bulletAmount; i++)
        {
            GameObject bulletToShoot = Instantiate(bullet);
            bulletToShoot.SetActive(false);
            bulletList.Enqueue(bulletToShoot);
        }
    }

    //TODO: modify this function to return a bullet from the Pool
    public GameObject GetBullet(Vector3 pos, Quaternion id)
    {
        GameObject bulletToGet = bulletList.Dequeue(); // Create new game object and make it equal to the bullet that is getting dequeued
        bulletToGet.SetActive(true); // Set the new game object to active
        bulletToGet.transform.position = pos;
        bulletToGet.transform.rotation = id;
        return bulletToGet;
    }

    //TODO: modify this function to reset/return a bullet back to the Pool 
    public void ResetBullet(GameObject bullet) 
    {
        bulletList.Enqueue(bullet); // Add the game object to the queue to make the bullet pool equal to 50
        bullet.SetActive(false); //Sets the current active bullet to not active
    }
}
