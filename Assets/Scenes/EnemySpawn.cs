using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawn : MonoBehaviour
{
    public static int CountTypesOfMonsters;
    public GameObject[] PrefabOfMonster = new GameObject[CountTypesOfMonsters];
    public int CountOfMonster;
    public static int Count;
    public int[] SequanceOfMonster = new int[Count];
    public int TimeOfSpawn;

    void Start()
    {
        StartCoroutine(Spawn());
    }

    IEnumerator Spawn()
    {
        for(int i = 0; i < CountOfMonster; i++)
        {
            yield return new WaitForSeconds(TimeOfSpawn);
            Instantiate(PrefabOfMonster[SequanceOfMonster[i]], new Vector2(transform.position.x, transform.position.y), Quaternion.identity);
            
        }
    }
    
    
    // Update is called once per frame
    
}
