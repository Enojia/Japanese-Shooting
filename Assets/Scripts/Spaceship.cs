using UnityEngine;
using System.Collections;

[RequireComponent(typeof(Rigidbody2D))]

public abstract class Spaceship : MonoBehaviour
{
    public float speed;
    public float shotDelay;
    public GameObject bullet;

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
	
}
