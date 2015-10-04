using UnityEngine;
using System.Collections;

[RequireComponent(typeof(Rigidbody2D))]

public abstract class Spaceship : MonoBehaviour
{
    public float speed;
    public float shotDelay;
    public GameObject bullet;
    public GameObject Explosion;

    protected Rigidbody2D rb2D;

    protected virtual void Start()
    {
        rb2D = GetComponent<Rigidbody2D>();
    }

    public void Shot(Transform origin)
    {
        Instantiate(bullet, origin.position, origin.rotation);
    }

    public void Move(Vector3 direction)
    {
        rb2D.velocity = direction * speed;
    }
	
    public void Explode()
    {
        Instantiate(Explosion, transform.position, Quaternion.identity);
    }

    protected virtual void OnTriggerEnter2D(Collider2D other)
    {
        Destroy(other.gameObject);

        Explode();

        Destroy(gameObject);
    }
}
