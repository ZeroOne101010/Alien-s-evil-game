using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaveSpawner : MonoBehaviour
{

    public GameObject[] entity;
    public int[] countEnemy;
    public float[] timeSpawn;
    public float[] timeBetweenSpawnGroup;

    public Vector2 offsetSpawn;

    public List<GameObject> spawnedEntity;
    public int idPrifabEntity;
    private int idCountEntity;
    public float timer;
    public float timerBetweenSpawnGroup;
    public float timerToStart;
    private bool canSpawn;
    private bool isStart;
    private bool waveIsDone;
    private bool isEndSpawn;

    void Start()
    {
        spawnedEntity = new List<GameObject>();
        waveIsDone = true;
        isEndSpawn = false;
    }

    void Update()
    {
        if (isStart)
        {
            if (!canSpawn)
            {
                updateTimerToStartWave();
            }
            else
            {
                timer -= Time.deltaTime;
                if (timer < 0) timer = 0;
                if (timer == 0)
                {
                    timerBetweenSpawnGroup -= Time.deltaTime;
                    if (timerBetweenSpawnGroup < 0) timerBetweenSpawnGroup = 0;
                    if (timerBetweenSpawnGroup == 0)
                    {
                        updatePortal();
                    }
                }
            }
        }
        if (isEndSpawn)
        {
            updateListEntity();
        }
    }

    public void startPortal()
    {
        timerToStart = timeBetweenSpawnGroup[0];
        isStart = true;
        waveIsDone = false;
        isEndSpawn = false;
    }

    public void stopPortal()
    {
        isStart = false;
        canSpawn = false;
        idPrifabEntity = 0;
        idCountEntity = 0;
        timerBetweenSpawnGroup = 0;
        isEndSpawn = true;
    }

    public void updateTimerToStartWave()
    {
        timerToStart -= Time.deltaTime;
        if (timerToStart < 0) timerToStart = 0;
        if(timerToStart == 0)
        {
            canSpawn = true;
        }
    }

    public void updatePortal()
    {
        if (idPrifabEntity < entity.Length)
        {
            if (idCountEntity < countEnemy[idPrifabEntity])
            {
                spawnEntity();
                timer = timeSpawn[idPrifabEntity];
                idCountEntity++;
            }
            else
            {
                idCountEntity = 0;
                idPrifabEntity++;
                timerBetweenSpawnGroup = timeBetweenSpawnGroup[idCountEntity];
            }
        }
        else
        {
            stopPortal();
        }
    }

    public void spawnEntity()
    {
        GameObject spawnEntity = entity[idPrifabEntity];
        Vector2 spawnPos = (Vector2)transform.position + offsetSpawn;
        GameObject spawnedEntity = Instantiate(entity[idPrifabEntity], spawnPos, Quaternion.identity);
        this.spawnedEntity.Add(spawnedEntity);
    }

    public void updateListEntity()
    {
        if (spawnedEntity.Count > 0)
        {
            int countNull = 0;
            for (int x = 0; x < spawnedEntity.Count; x++)
            {
                if (spawnedEntity[x] != null)
                {
                    break;
                }
                else
                {
                    countNull++;
                }
            }
            if (countNull != 0)
            {
                for (int x = 0; x < countNull; x++)
                {
                    spawnedEntity.RemoveAt(0);
                }
            }
        }
        else
        {
            waveIsDone = true;
        }
    }

    public bool getWaveIsDone()
    {
        return waveIsDone;
    }
}
