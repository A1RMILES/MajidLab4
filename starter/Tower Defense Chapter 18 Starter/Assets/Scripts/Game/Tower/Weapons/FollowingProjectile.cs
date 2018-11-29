using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class FollowingProjectile : MonoBehaviour
{
    //1 Projectile will follow enemy
    public Enemy enemyToFollow;
    //2 Projectile speed
    public float moveSpeed = 15;
    private void Update()
    {
        //3 projectile will destroy itself if enemy doesn't exist anymore
        if (enemyToFollow == null)
        {
            Destroy(gameObject);
        }
        else
        { //4 if target is still active, it will follow 
            transform.LookAt(enemyToFollow.transform);
            GetComponent<Rigidbody>().velocity = transform.forward * moveSpeed;
        }
    }
    //5 if projectile hits an object - OnHitEnemy() is called
    public void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<Enemy>() == enemyToFollow)
        {
            OnHitEnemy();
        }
    }
    //6 abstract method that needs to be derived by the class, its protected but can be called from the derived class
    protected abstract void OnHitEnemy();


}
