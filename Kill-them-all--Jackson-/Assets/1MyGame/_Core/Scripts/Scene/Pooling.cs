using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pooling : MonoBehaviour {

    public GameObject pooledObject;
    List<GameObject> pooledList;
    public int startCount = 20;
    public bool canGrow;


	// Use this for initialization
	void Start () {
        pooledList = new List<GameObject>();


        for (int i = 0; i < startCount; i++)
        {
            pooledList.Add((GameObject)Instantiate(pooledObject));
            pooledList[pooledList.Count - 1].SetActive(false);

        }
	}
	
public GameObject GetPooledObject()
    {
        for (int i = 0; i < pooledList.Count; i++)
        {
            if (!pooledList[i].activeInHierarchy)
            {
                return pooledList[i];
            }
        }

        if (canGrow)
        {
            pooledList.Add((GameObject)Instantiate(pooledObject));
            return pooledList[pooledList.Count - 1];

        }
        return null;
    }
}
