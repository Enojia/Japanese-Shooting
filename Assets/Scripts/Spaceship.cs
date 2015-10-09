using UnityEngine;
using System.Collections;
using System.Collections.Generic;

[RequireComponent(typeof(Rigidbody2D))]

public abstract class Spaceship : MonoBehaviour
{
    public float speed;
    public float shotDelay;
    //public GameObject bullet; no longer needed
    public GameObject Explosion;
    public int hp;
    public GameObject PooledObject;
    public int PooledAmount;
    public bool WillGrow;

    protected Rigidbody2D rb2D;
    protected List<GameObject> pooledObjects;

    protected virtual void Start()
    {
        rb2D = GetComponent<Rigidbody2D>();
        pooledObjects = new List<GameObject>();
        {
            for (int i = 0; i<PooledAmount; i++)  //fill the pool
            {
                GameObject obj = Instantiate(PooledObject) as GameObject;
                obj.SetActive(false);
                pooledObjects.Add(obj);
            }
        }
    }

    public void Shot(Transform origin)
    {
        GameObject obj = GetPooledObject();

        if (obj == null)
            return;

        obj.transform.position = origin.transform.position;
        obj.transform.rotation = origin.transform.rotation;
        obj.SetActive(true);
    }

    protected abstract void Move(Vector3 direction);
    
    public void Explode()
    {
        Instantiate(Explosion, transform.position, Quaternion.identity);
    }

    protected abstract void OnTriggerEnter2D(Collider2D other);
    
    public GameObject GetPooledObject()
    {
        for (int i = 0; i<pooledObjects.Count; i++)
        {
            if (!pooledObjects[i].activeInHierarchy)
            {
                return pooledObjects[i];
            }
        }

        if(WillGrow)
        {
            GameObject obj = (GameObject)Instantiate(PooledObject);
            pooledObjects.Add(obj);
            return obj;
        }

        return null;
    }
}
