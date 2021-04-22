using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public List<GameObject> platforms = new List<GameObject>();

    private float countTime;
    private Vector3 spawnPosition;
    Vector3 movement;

    private List<int> list_count = new List<int>();
    public GameObject slab;
    public int barrier = 3;

    void Start() {
        movement.y = TransferData._instance.speed;
    }
    void Update()
    {
        SpawnPlatform();
    }

    public void SpawnPlatform()
    {
        countTime += Time.deltaTime;
        spawnPosition = transform.position;
        spawnPosition.x = Random.Range(-3.5f, 3.5f);

        if(countTime >= TransferData._instance.spawnTime)
        {
            CreatePlatform();
            countTime = 0;
        }
    }

    public void CreatePlatform()
    {
        int index = Random.Range(0, platforms.Count);
        list_count.Add(index);
        int spikeNum = 0;

        if(index == 3)
        {
            spikeNum++;
        }
        if(spikeNum > 1)
        {
            spikeNum = 0;
            countTime = TransferData._instance.spawnTime;
            return;
        }
        if(list_count.Count < barrier)
        {
            GameObject newPlatform = Instantiate(platforms[index], spawnPosition, Quaternion.identity);
            newPlatform.transform.SetParent(this.gameObject.transform);
        }
        else
        {
            GameObject newPlatformslab = Instantiate(slab, spawnPosition, Quaternion.identity);
            newPlatformslab.transform.SetParent(this.gameObject.transform);
            for (int i = 0; i < list_count.Count; i++)
            {
                list_count.RemoveAt(i);
            }
        }
    }
}
