//using System;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.AI;

public class EnemyManager : MonoBehaviour
{
    [SerializeField, Tooltip("what enemies should spawn")] List<Enemies> enemiesToSpawn;
    [SerializeField, Tooltip("How fast enemies should spawn")] float spawnFrequency = 15f;
    [SerializeField, Tooltip("How many enemies spawn in a wave")] int spawnCount = 5;
    [SerializeField, Tooltip("The object with thr navMesh on it")] GameObject spawnBox;
    private List<Enemies> avalibleEnemiesForPhase;
    private float spawnTimer;
    SpawnPhase spawnPhase = SpawnPhase.phaseOne;
    private void Start()
    {
        //this is just to test
        GetPhaseEnemies();
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
        List<Enemies> enemies = GetRandomEnemies(spawnPhase);
        foreach (Enemies e in enemies)
        {
            if (!e.spawnInGroups)
            {
                GameObject g = Instantiate(e.enemyOBJ, GetRandomPositionOnNavMesh(), Quaternion.identity);
            }
            else
            {
                Vector3 v = GetRandomPositionOnNavMesh();
                for (int i = 0; i < e.numberToSpawn; i++)
                {
                    GameObject g = Instantiate(e.enemyOBJ, new Vector3(Random.Range(v.x - 2, v.x + 2), v.y, Random.Range(v.z - 2, v.z + 2)), Quaternion.identity);
                }
            }
        }
        //makes sure we keep spawning enemies over time
        spawnTimer = spawnFrequency;
    }
    private List<Enemies> GetRandomEnemies(SpawnPhase currentPhase)
    {
        //the list being returned
        List<Enemies> listToReturn = new List<Enemies>();
        for (int i = 0; i < spawnCount;)
        {
            //gets a random enemy in the list
            int spawnNum = Random.Range(0, avalibleEnemiesForPhase.Count);
            //this makes sure the enemy cost doesn't exceed the count

            listToReturn.Add(avalibleEnemiesForPhase[spawnNum]);
            if (!avalibleEnemiesForPhase[spawnNum].spawnInGroups)
            {
                if (avalibleEnemiesForPhase[spawnNum].spawnCost + i <= spawnCount)
                {
                    i += avalibleEnemiesForPhase[spawnNum].spawnCost;
                }
            }
            else
            {
                int n = Random.Range(avalibleEnemiesForPhase[spawnNum].groupSizeMin, avalibleEnemiesForPhase[spawnNum].groupSizeMax + 1);
                if (avalibleEnemiesForPhase[spawnNum].spawnCost + i <= (spawnCount * n))
                {
                    i += (avalibleEnemiesForPhase[spawnNum].spawnCost * n);
                    avalibleEnemiesForPhase[spawnNum].numberToSpawn = n;
                }
            }

        }
        return listToReturn;
    }
    public void StartNextPhase()
    {
        spawnPhase++;
        GetPhaseEnemies();
    }
    private void GetPhaseEnemies()
    {
        avalibleEnemiesForPhase = GetCurrentPhaseEnemies(spawnPhase);
    }
    private List<Enemies> GetCurrentPhaseEnemies(SpawnPhase currentPhase)
    {
        List<Enemies> avalibleEnemies = new List<Enemies>();

        for (int i = 0; i < enemiesToSpawn.Count; i++)
        {
            for (int j = 0; j < enemiesToSpawn[i].phase.Length; j++)
            {
                if (currentPhase == enemiesToSpawn[i].phase[j])
                {
                    avalibleEnemies.Add(enemiesToSpawn[i]);
                    break;
                }
            }
        }

        return avalibleEnemies;
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
        finalPosition = bounds.center + new Vector3(offsetX, 0, offestZ);
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
    [Tooltip("This is the name of the enemy. This is just to help debug")]
    public string name;
    [Tooltip("how many points this will count for for the mananger spawn count. Higher number = more difficult")]
    public int spawnCost = 1; // how many enemy spot this enemy should count for
    [Tooltip("Adding all phases will spawn the enemies in all the phases. if you do one " +
        "it'll only add during that phase. Only add 1 of each phase to the array")]
    public SpawnPhase[] phase; // this will tell the manager when to spawn the enemy
    [Tooltip("Enemy game object")]
    public GameObject enemyOBJ; // the gameObject for the enemy
    [Tooltip("If this enemy should spawn in a group of the same enemy")]
    public bool spawnInGroups = false;
    [Tooltip("if SpawnInGroups = false; this does nothing. This decides the min amount of this enemy to spawn at once.")]
    public int groupSizeMin = 2;
    [Tooltip("if SpawnInGroups = false; this does nothing. This decides the max amount of this enemy to spawn at once.")]
    public int groupSizeMax = 3;

    [HideInInspector] public int numberToSpawn;
}
public enum SpawnPhase
{
    //I will add more phases if needed
    phaseOne,
    PhaseTwo,
    FinalPhase
}