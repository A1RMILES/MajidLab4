using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class EnemyManager : MonoBehaviour
{
    //1
    public static EnemyManager Instance;
    //2The list with registered enemies
    public List<Enemy> Enemies = new List<Enemy>();

    //3Sets the Instance to this script
    void Awake()
    {
        Instance = this;
    }

    //4 Register an enemy by adding it to the Enemies list
    public void RegisterEnemy(Enemy enemy)
    {
        Enemies.Add(enemy);
        UIManager.Instance.CreateHealthBarForEnemy(enemy);
    }

    //5 Unregister an enemy by removing it from the Enemies list
    public void UnRegister(Enemy enemy)
    {
        Enemies.Remove(enemy);
    }

    //6 This is a helper method. It returns a list of all enemies withing a certain range from
    //the position given.
    public List<Enemy> GetEnemiesInRange(Vector3 position, float range)
    {
        return Enemies.Where(enemy => Vector3.Distance(position,
        enemy.transform.position) <= range).ToList();
    }

    //7
    public void DestroyAllEnemies()
    {
        foreach (Enemy enemy in Enemies)
        {
            Destroy(enemy.gameObject);
        }
        Enemies.Clear();
    }


}
