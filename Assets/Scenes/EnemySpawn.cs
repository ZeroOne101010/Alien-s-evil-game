using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawn : MonoBehaviour
{
    public static int CountTypesOfMonsters;
    public GameObject[] PrefabOfMonster = new GameObject[CountTypesOfMonsters];
    public int CountOfMonster;
    public int time;


    // Start is called before the first frame update
    void Start()
    {
        int i = 0;
        while (i < CountOfMonster)
        {
            InvokeRepeating("Spawn", 0, time);
        }
            
        
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void Spawn()
    {
        Instantiate(PrefabOfMonster[0]);
    }
}
