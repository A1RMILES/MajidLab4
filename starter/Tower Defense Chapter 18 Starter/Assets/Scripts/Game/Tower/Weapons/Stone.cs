using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stone : FollowingProjectile
{
    //1 amopunt of damage enemy takes
    public float damage;
    //2 overide the function
    protected override void OnHitEnemy()
    {
        //3 enemy takes damage and projectile is destroyed
        enemyToFollow.TakeDamage(damage);
        Destroy(gameObject);
    }

}
