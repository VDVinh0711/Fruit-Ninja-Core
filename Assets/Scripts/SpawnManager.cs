using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices.WindowsRuntime;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    
    public List<Transform> fruiPrefabs;
    public SpawnPoints spawnPoints;
    //public List<Transform> poolObj;
    //public Transform holder;


    private void Awake()
    {
        //LoadHolder();
    }
    public void SpawmFruit()
    {
        if (fruiPrefabs.Count < 1) return;
        StartCoroutine(spawnFruit());
    }
    IEnumerator spawnFruit()
    {
        while (GameManager.Innstance.isActive)
        {
            yield return new WaitForSeconds(2.0f);
            //Spawner(RandomPreFabs());
            Instantiate(RandomPreFabs(), spawnPoints.RandomPoint());
        }
    }
    public Transform RandomPreFabs()
    {
        return fruiPrefabs[Random.Range(0, fruiPrefabs.Count-1)];
    }
    /*public void DeSpawn( Transform Obj)
    {
        poolObj.Add(Obj);
        Obj.gameObject.SetActive(false);
    }
    /*public Transform GetObjFromPoolByName(Transform prefabs)
    {
        foreach (Transform obj in poolObj)
        {
            if (obj == null) continue;
            if(obj.name == prefabs.name)
            {
                poolObj.Remove(obj);
                return obj;
            } 
        }
        Transform newPrefabs = Instantiate(prefabs);
        newPrefabs.name = prefabs.name;
        return newPrefabs;
    }*/
    /*public Transform Spawner(Transform fruit)
    {
        Transform newFruit = GetObjFromPoolByName(fruit);
        newFruit.position = spawnPoints.RandomPoint().position;
        newFruit.parent = holder;
        return newFruit;
    }*/
    /*public void LoadHolder()
    {
        if (holder != null) return;
        holder = transform.Find("Holder");
    }*/
    

}
