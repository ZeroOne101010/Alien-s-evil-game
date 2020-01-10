using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveToObject : MonoBehaviour
{

    public GameObject obj;
    public float t;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        translateMove();
    }

    public void translateMove()
    {
        transform.position = new Vector3(Mathf.Lerp(transform.position.x, obj.transform.position.x, t), Mathf.Lerp(transform.position.y, obj.transform.position.y, t), transform.position.z);
    }
}
