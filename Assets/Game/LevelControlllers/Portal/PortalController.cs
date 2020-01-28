using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PortalController : MonoBehaviour
{

    public WaveSpawner[] waveSpawner;

    [HideInInspector]
    public int countWaves;

    void Start()
    {
        waveSpawner = GetComponents<WaveSpawner>();
        countWaves = waveSpawner.Length;
    }

    void Update()
    {

    }

    public void startWave(int idWave)
    {
        waveSpawner[idWave].startPortal();
    }

    public bool waveIsDone(int idWave)
    {
        return waveSpawner[idWave].getWaveIsDone();
    }

    public void stopWave(int idWave)
    {
        waveSpawner[idWave].stopPortal();
    }
}
