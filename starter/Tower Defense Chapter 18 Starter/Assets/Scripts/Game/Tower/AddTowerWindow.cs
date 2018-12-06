using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class AddTowerWindow : MonoBehaviour
{
    //1
    public GameObject towerSlotToAddTowerTo;
    //2
    public void AddTower(string towerTypeAsString)
    {
        //3
        TowerType type = (TowerType)Enum.Parse(typeof(TowerType),
        towerTypeAsString, true);
        //4 check for player's gold
        if (TowerManager.Instance.GetTowerPrice(type) <=
        GameManager.Instance.gold)
        {
            //5 subtract towers price from player's gold
            GameManager.Instance.gold -= TowerManager.Instance
            .GetTowerPrice(type);
            //6
            TowerManager.Instance.CreateNewTower(towerSlotToAddTowerTo, type);
            gameObject.SetActive(false);
        }
    }



}
