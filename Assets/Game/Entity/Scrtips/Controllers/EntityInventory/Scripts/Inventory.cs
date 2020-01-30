using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    public int maxCountItems = 10;
    public Vector2 offsetDropItem;
    public List<GameObject> item;

    public bool canAddItems = true;

    void Awake()
    {
        item = new List<GameObject>();
    }

    void Update()
    {
        
    }

    public void addItem(GameObject item)
    {
        if (!isFull())
        {
            this.item.Add(item);
        }
    }

    public GameObject dropItem(int id)
    {
        GameObject gettingItem = item[id];
        this.item.Remove(gettingItem);
        Vector3 pos = transform.position;
        if(transform.rotation.y == 0)
        {
            pos = transform.position + (Vector3)(offsetDropItem);
        }
        else if(transform.rotation.y == 1)
        {
            pos = transform.position - (Vector3)(offsetDropItem);
        }
        gettingItem.transform.position = pos;
        gettingItem.transform.rotation = Quaternion.identity;
        gettingItem.SetActive(true);
        return gettingItem;
    }

    public GameObject dropItem(GameObject item)
    {
        if (this.item.Contains(item))
        {
            Vector3 pos = transform.position + (Vector3)(offsetDropItem);
            if (transform.rotation.y == 0)
            {
                pos = transform.position + (Vector3)(offsetDropItem);
            }
            else if (transform.rotation.y == -180)
            {
                pos = transform.position - (Vector3)(offsetDropItem);
            }
            item.transform.position = pos;
            item.transform.rotation = Quaternion.identity;
            item.SetActive(true);
            return item;
        }
        else
        {
            return null;
        }
    }

    public void dropLastItem()
    {
        if(item.Count > 0)
        {
            dropItem(item.Count - 1);
        }
    }

    public GameObject getLastItem()
    {
        if(item.Count > 0)
        {
            return item[item.Count - 1];
        }
        else
        {
            return null;
        }
    }

    public void dropFirstItem()
    {
        if(item.Count > 0)
        {
            dropItem(0);
        }
    }

    public bool isFull()
    {
        return this.item.Count >= maxCountItems;
    }
}
