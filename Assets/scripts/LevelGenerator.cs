using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelGenerator : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject[] platformPerfabs;
    private float currentYPos = 0f;
    public float cameraHeight = 5.5f;

    public Transform platformPool;
    void Start()
    {
        SpawnPlatformPool();//生成板子
        while (currentYPos < Camera.main.transform.position.y + cameraHeight)
        {
            PickNewPlatform();
        }
    }

    void SpawnPlatformPool()
    {
        int basicPlatformAmount = 30;
        int weakPlatformAmount = 15;

        for (int i = 0; i < basicPlatformAmount; i++)
        {
            GameObject platform = Instantiate(platformPerfabs[0], platformPool);
            platform.SetActive(false);
        }

        for (int i = 0; i < weakPlatformAmount; i++)
        {
            GameObject platform = Instantiate(platformPerfabs[1], platformPool);
            platform.SetActive(false);            
        }
    }

    void PickNewPlatform()
    {
        currentYPos += Random.Range(0.3f, 1f);
        float xPos = Random.Range(-3.8f, 3.8f);

        int r = 0;
        do
        {
            r = Random.Range(0, platformPool.childCount);
        } while (platformPool.GetChild(r).gameObject.activeInHierarchy);

        platformPool.GetChild(r).position = new Vector2(xPos, currentYPos);
        platformPool.GetChild(r).gameObject.SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
        if (currentYPos < Camera.main.transform.position.y + cameraHeight)
        {
            PickNewPlatform();
        }
    }
}
