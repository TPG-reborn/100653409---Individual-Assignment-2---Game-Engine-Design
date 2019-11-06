using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Util;

public class BulletController : MonoBehaviour
{
    public float bulletSpeed = 0.1f;
    public Boundary boundary;

    //TODO: create a reference to the BulletPoolManager
    private BulletPoolManager BulletPoolMan;

    void Start()
    {
        boundary.Top = 2.45f;
        BulletPoolMan = GameObject.FindObjectOfType<BulletPoolManager>(); // Looks for an active object that is of the Bullet Pool Manager class
                                                                          // This is done to help the Reset Bullet function to look for the correct object and set it to not active
    }


    // Update is called once per frame
    void Update()
    {
        Move();
        CheckBounds();
    }

    private void Move()
    {
        transform.position += new Vector3(0.0f, bulletSpeed, 0.0f);
    }

    private void CheckBounds()
    {
        if (transform.position.y >= boundary.Top)
        {
            //TODO: This code needs to change to use the BulletPoolManager's
            //TODO: ResetBullet function which will return the bullet to the pool
            BulletPoolMan.ResetBullet(this.gameObject); // Calls the reset function from the Bullet Pool Manager class
        }
    }
}
