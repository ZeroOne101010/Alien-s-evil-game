using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaveController : MonoBehaviour
{
    public float timeToStart;
    public float[] timeBetweenWave;
    public bool pauseWave;

    [HideInInspector]
    public int idWave;

    public float timerToStart;
    public float timerBetweenWave;
    private GameObject[] gameObjectPortal;
    private PortalController[] portalController;
    private bool isStart;

    void Start()
    {
        timerToStart = timeToStart;
        gameObjectPortal = GameObject.FindGameObjectsWithTag("Portal");
        portalController = new PortalController[gameObjectPortal.Length];
        for(int x = 0; x < gameObjectPortal.Length; x++)
        {
            portalController[x] = gameObjectPortal[x].GetComponent<PortalController>();
        }
        timerBetweenWave = timeBetweenWave[idWave];
    }

    void Update()
    {
        if (isStart)
        {
            if (!pauseWave)
            {
                if (waveIsDone())
                {
                    timerBetweenWave -= Time.deltaTime;
                    if (timerBetweenWave < 0) timerBetweenWave = 0;
                    if (timerBetweenWave == 0)
                    {
                        if (idWave < timeBetweenWave.Length)
                        {
                            startWave(idWave);
                        }
                        idWave++;
                        if (idWave > timeBetweenWave.Length)
                        {
                            endWaves();
                        }
                        else if(idWave < timeBetweenWave.Length)
                        {
                            timerBetweenWave = timeBetweenWave[idWave];
                        }
                    }
                }
            }
        }
        else
        {
            updateStartTimer();
        }
    }

    private void updateStartTimer()
    {
        timerToStart -= Time.deltaTime;
        if (timerToStart < 0) timerToStart = 0;
        if(timerToStart == 0)
        {
            isStart = true;
            startWave(idWave);
            timerBetweenWave = timeBetweenWave[idWave];
            idWave++;
            Debug.Log("Start wave manager!");
        }
    }

    public void startWave(int idWave)
    {
        for(int x = 0; x < portalController.Length; x++)
        {
            portalController[x].startWave(idWave);
        }
        Debug.Log("Start wave " + idWave + "!");
    }

    public void stopWave(int idWave)
    {
        for (int x = 0; x < portalController.Length; x++)
        {
            portalController[x].stopWave(idWave);
        }
    }

    public void endWaves()
    {
        isStart = false;
        pauseWave = true;
        timerToStart = timeToStart;
        timerBetweenWave = 0;
        idWave = 0;

        for (int x = 0; x < portalController.Length; x++)
        {
            stopWave(x);
        }

        Debug.Log("End waves!");
    }

    public bool waveIsDone()
    {
        if (idWave > 0)
        {
            bool waveIsDone = false;
            for (int x = 0; x < portalController.Length; x++)
            {
                waveIsDone = portalController[x].waveIsDone(idWave - 1);
                if (waveIsDone) break;
            }
            return waveIsDone;
        }
        else
        {
            return true;
        }
    }

}
