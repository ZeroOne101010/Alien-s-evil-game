using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomSpriteFroStart : MonoBehaviour
{

    public Sprite[] sprite;

    void Start()
    {
        SpriteRenderer renderer = GetComponent<SpriteRenderer>();
        int id = Random.Range(0, sprite.Length);
        renderer.sprite = sprite[id];
    }

    void Update()
    {
        
    }
}
