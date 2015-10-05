using UnityEngine;
using System.Collections;

public class Bullet : MonoBehaviour
{
    public float speed = 10;
    public float lifeTime;

    private Rigidbody2D rb2D;
	// Use this for initialization
	void Start ()
    {
        rb2D = GetComponent<Rigidbody2D>();
        rb2D.velocity = transform.up * speed;
        Destroy(gameObject, lifeTime);
    }
	
	// Update is called once per frame
	void Update ()
    {
        
	}
}
