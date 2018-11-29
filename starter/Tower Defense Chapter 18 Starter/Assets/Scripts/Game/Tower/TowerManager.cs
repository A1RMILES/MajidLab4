using System.Collections;
using System.Collections.Generic;
using System;
using System.Linq;
using UnityEngine;

[Serializable]
public struct TowerCost
{
    public TowerType TowerType;
    public int Cost;
}

public class TowerManager : MonoBehaviour
{
    //1 singleton stored away in Instance
    public static TowerManager Instance;
    //2 References to the tower prefabs, needed to spawn new instances
    public GameObject stoneTowerPrefab;
    public GameObject fireTowerPrefab;
    public GameObject iceTowerPrefab;
    //3 Store the cost of each type of tower in a list
    public List<TowerCost> TowerCosts = new List<TowerCost>();
    //4 Sets the Instance variable to this script
    void Awake()
    {
        Instance = this;
    }
    //5 once a tower is created, disables the slot so another tower can't be placed
    public void CreateNewTower(GameObject slotToFill, TowerType towerType)
    {
        switch (towerType)
        {
            case TowerType.Stone:
                Instantiate(stoneTowerPrefab, slotToFill.transform.position,
                Quaternion.identity);
                slotToFill.gameObject.SetActive(false);
                break;
            case TowerType.Fire:
                Instantiate(fireTowerPrefab, slotToFill.transform.position,
                Quaternion.identity);
                slotToFill.gameObject.SetActive(false);
                break;
            case TowerType.Ice:
                Instantiate(iceTowerPrefab, slotToFill.transform.position,
                Quaternion.identity);
                slotToFill.gameObject.SetActive(false);
                break;
        }
    }
    //6 LINQ utility method to easily get the price of a tower type
    public int GetTowerPrice(TowerType towerType)
    {
        return (from towerCost in TowerCosts
                where towerCost.TowerType
                == towerType
                select towerCost.Cost).FirstOrDefault();
    }

}
