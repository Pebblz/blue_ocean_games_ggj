using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyManager : MonoBehaviour
{
    [SerializeField, Tooltip("what enemies should spawn")] List<Enemies> enemiesToSpawn;
    [SerializeField, Tooltip("How fast enemies should spawn")] float spawnFrequency = 15f;
    [SerializeField, Tooltip("How many enemies spawn in a wave")] int spawnCount = 5;
    [SerializeField, Tooltip("The object with thr navMesh on it")] GameObject spawnBox;
    private float spawnTimer;
    private void Start()
    {
        //this is just to test
        SpawnEnemies();
        spawnTimer = spawnFrequency;
    }
    //I'll turn this on when we have a way to kill enemies
    //private void Update()
    //{
    //    //I'll be using Invoke when i figure out scaling difficulty
    //    //if (spawnTimer > 0)
    //    //{
    //    //    spawnTimer -= Time.deltaTime;
    //    //}
    //    //else
    //    //{
    //    //    SpawnEnemies();
    //    //}
    //}
    public void SpawnEnemies()
    {
        //populates the list with random enemies 
        List<Enemies> enemies = GetRandomEnemies();
        foreach (Enemies e in enemies)
        {
            GameObject g = Instantiate(e.enemyOBJ,GetRandomPositionOnNavMesh(),Quaternion.identity);
        }
        //makes sure we keep spawning enemies over time
        spawnTimer = spawnFrequency;
    }
    private List<Enemies> GetRandomEnemies()
    {
        //the list being returned
        List<Enemies> listToReturn = new List<Enemies>();

        for(int i = 0;i < spawnCount;)
        {
            //gets a random enemy in the list
            int spawnNum = Random.Range(0, enemiesToSpawn.Count);
            //this makes sure the enemy cost doesn't exceed the count
            if (enemiesToSpawn[spawnNum].spawnCost + i <= spawnCount)
            {
                listToReturn.Add(enemiesToSpawn[spawnNum]);
                i += enemiesToSpawn[spawnNum].spawnCost;
            }
        }
        return listToReturn;
    }
    private Vector3 GetRandomPositionOnNavMesh()
    {
        //the position being returned
        Vector3 finalPosition;
        NavMeshHit hit;
        // this gets a random point of the navmesh 
        //----------------------------------------
        Bounds bounds = spawnBox.GetComponent<Collider>().bounds;
        float offsetX = Random.Range(-bounds.extents.x, bounds.extents.x);
        float offestZ = Random.Range(-bounds.extents.z, bounds.extents.z);
        finalPosition = bounds.center + new Vector3(offsetX,0,offestZ);
        //----------------------------------------
        //this makes sure the point we get is on the navmesh
        if (NavMesh.SamplePosition(finalPosition, out hit, 5, 1))
        {
            finalPosition = hit.position;
        }
        return finalPosition;
    }
}
[System.Serializable]
public class Enemies
{
    [Tooltip("how many points this will count for for the mananger spawn count. Higher number = more difficult")] 
    public int spawnCost = 1; // how many enemy spot this enemy should count for
    [Tooltip("This will effect at what point the enemy should be spawned")]
    public EnemyDifficulty difficulty; // how hard this enemy is to beat
    [Tooltip("Enemy object")]
    public GameObject enemyOBJ; // the gameObject for the enemy
}
public enum EnemyDifficulty
{
    easy,
    medium,
    hard
}