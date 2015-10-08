using UnityEngine;
using System.Collections;

[RequireComponent(typeof(Rigidbody2D))]

public abstract class Spaceship : MonoBehaviour
{
    public float speed;
    public float shotDelay;
    public GameObject bullet;
    public GameObject Explosion;
    public int hp;

    protected Rigidbody2D rb2D;

    protected virtual void Start()
    {
        rb2D = GetComponent<Rigidbody2D>();
    }

    public void Shot(Transform origin)
    {
        Instantiate(bullet, origin.position, origin.rotation);
    }

    protected abstract void Move(Vector3 direction);
    
    public void Explode()
    {
        Instantiate(Explosion, transform.position, Quaternion.identity);
    }

    protected abstract void OnTriggerEnter2D(Collider2D other);
    
}
