using UnityEngine;
using System.Collections;

public class Bullet : MonoBehaviour
{
    public float speed = 10;

    private Rigidbody2D rb2D;
	// Use this for initialization
	void Start ()
    {
        rb2D = GetComponent<Rigidbody2D>();
	}
	
	// Update is called once per frame
	void Update ()
    {
        rb2D.velocity = Vector3.up * speed;
	}
}
