using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawn : MonoBehaviour
{
    public Wave enemyWave;
    public Pathway enemyPath;
    public bool[] done;

    // Start is called before the first frame update
    IEnumerator Start()
    {
        done = new bool[1];
        StartCoroutine(SpawnEnemies(enemyWave.coolDownBtwnWaves, 0));
        yield break;
    }

    IEnumerator SpawnEnemies(float cooldownBtwnWaves, int type)
    {
        done[type] = new bool();
        for (int i = 0; i < enemyWave.groups.Length; i++)
        {
            if (enemyWave.groups[i].enemies.Length > type) StartCoroutine(SpawnEnemy(enemyWave.groups[i].enemies[type]));


            yield return new WaitForSeconds(cooldownBtwnWaves); 
        }

        done[type] = true;
        Debug.Log("done with wave");
        //GameManager.master.CheckForEnemies();
    }

    IEnumerator SpawnEnemy(Type type)
    {
        for (int j = 0; j < type.number; j++)
        {
            Enemy spawnedEnemy = Instantiate(type.enemy).GetComponent<Enemy>();
            spawnedEnemy.path = enemyPath;
            yield return new WaitForSeconds(type.coolDown);

        }
    }

    [Serializable]
    public struct Type
    {
        public GameObject enemy;
        public int number;
        public float coolDown;
    }
    [Serializable]
    public struct Group
    {
        public Type[] enemies;
    }
    [Serializable]
    public struct Wave
    {
        public Group[] groups;
        public float coolDownBtwnWaves;
    }
}
