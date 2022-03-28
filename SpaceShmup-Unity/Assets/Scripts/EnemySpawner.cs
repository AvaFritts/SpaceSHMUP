/**** 
 * Created by: Ava Fritts
 * Date Created: March 28, 2022
 * 
 * Last Edited by: NA
 * Last Edited: March 28, 2022
 * 
 * Description: Spawns the enemies.
****/

/** Using Namespaces **/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    /*** VARIABLES ***/

    [Header("Enemy Settings")]
    public GameObject[] prefabEnemies; //prefabs for the enemies
    public float enemySpawnPerSecond; //number of enemies to spawn per second.
    public float enemyDefaultPadding; //padding so they don't spawn on top of each other

    private BoundsCheck bndCheck; 

    // Start is called before the first frame update
    void Start()
    {
        bndCheck = GetComponent<BoundsCheck>(); //reference to Bounds Check component
        Invoke("SpawnEnemy", 1f / enemySpawnPerSecond);

    }

    public void SpawnEnemy()
    {
        //pick a random enemy to instantiate
        int ndx = Random.Range(0, prefabEnemies.Length); //picks a number from 0 to Length-1
        GameObject go = Instantiate<GameObject>(prefabEnemies[ndx]);

        //Position the enemy above the screen with a random x pos
        float enemyPadding = enemyDefaultPadding;
        if(go.GetComponent<BoundsCheck>() != null)
        {
            enemyPadding = Mathf.Abs(go.GetComponent<BoundsCheck>().radius);
        }

        //set initial position
        Vector3 pos = Vector3.zero;
        float xMin = -bndCheck.camWidth + enemyPadding;
        float xMax = bndCheck.camWidth - enemyPadding;

        pos.x = Random.Range(xMin, xMax);
        pos.y = bndCheck.camHeight + enemyPadding;

        //transform the enemy
        go.transform.position = pos;

        Invoke("SpawnEnemy", 1f / enemySpawnPerSecond); //invoke again

    }// end spawnEnemy()
}
