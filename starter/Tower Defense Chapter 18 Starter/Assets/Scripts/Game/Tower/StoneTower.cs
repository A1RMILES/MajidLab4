using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StoneTower : Tower
{
    //1 shoots a projectile
    public GameObject stonePrefab;
    //2 overide attack from enemy
    protected override void AttackEnemy()
    {
        base.AttackEnemy();
        //3 spanws new projectiles
        GameObject stone = (GameObject)Instantiate(stonePrefab,towerPieceToAim.position, Quaternion.identity);
        stone.GetComponent<Stone>().enemyToFollow = targetEnemy;
        stone.GetComponent<Stone>().damage = attackPower;
    }

}
