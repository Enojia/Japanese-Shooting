using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour
{
    public float speed = 5;

    Rigidbody2D rb2D;
	// Use this for initialization
	void Start ()
    {
        rb2D = GetComponent<Rigidbody2D>();
	}
	
	// Update is called once per frame
	void Update ()
    {
        float x = Input.GetAxisRaw("Horizontal");
        float y = Input.GetAxisRaw("Vertical");

        Vector3 direction = new Vector3(x, y, 0).normalized; //unit direction of the mouvment;

        rb2D.velocity = direction * speed; //velocity = speed + direction;
	}
}
