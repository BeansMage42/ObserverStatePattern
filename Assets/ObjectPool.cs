
using UnityEngine;
using System.Collections.Generic;
public class ObjectPool : MonoBehaviour
{
    public GameObject treeToSpawn;
    public GameObject[] spawnLocations;
    public int maxSpawn;
    public List<GameObject> activePool = new List<GameObject>();
    public List<GameObject> inactivePool = new List<GameObject>();
    public bool treeDespawned = true;
    float maxTreeSpawned;

    public static ObjectPool Instance;
    private void Awake()
    {
        if (Instance != null)
        {
            if (Instance != this)
            {
                Instance = this;
            }
        }
        else
        {
            Instance = this;

        }
    }


    // Update is called once per frame
    void Update()
    {
        
            if (activePool.Count < maxSpawn)
            {
            Debug.Log("less");
                GameObject tree = null;
                if (inactivePool.Count == 0)
                {
                Debug.Log("use new tree");
                    tree = SpawnNewTreeToPool();

                }
                else
                {
                Debug.Log("create new tree");
                    tree = inactivePool[0];
                    inactivePool.Remove(tree);
                }

                if (tree != null) 
                {
                Debug.Log("spawn in update");
                    SetTreeLocation(tree);
                }
            }
            else
            {
                treeDespawned=false;
            }
        
    }

    public void SetTreeLocation(GameObject go)
    {
        activePool.Add(go);
        Debug.Log("spawn");
        int index = Random.Range(0, spawnLocations.Length);
        go.SetActive(true);
        go.transform.position = spawnLocations[index].transform.position;
    }

    public GameObject SpawnNewTreeToPool()
    {
        return Instantiate(treeToSpawn);
    }

    public void ReturnTreeToPool(GameObject tree)
    {
        activePool.Remove(tree);
        inactivePool.Add(tree);
        treeDespawned = true;
    }
}
