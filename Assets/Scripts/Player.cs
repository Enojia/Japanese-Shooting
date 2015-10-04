using UnityEngine;
using System.Collections;

public class Player : Spaceship
{
    
	// Use this for initialization
	protected override void Start ()
    {
        base.Start();
        speed = 5;
        shotDelay = 1.0f;

	}
	
	// Update is called once per frame
	void Update ()
    {
        float x = Input.GetAxisRaw("Horizontal");
        float y = Input.GetAxisRaw("Vertical");

        Vector3 direction = new Vector3(x, y, 0).normalized; //unit direction of the mouvment;

        Move(direction);

        StartCoroutine(Firing());
    }

    public IEnumerator Firing()
    {
        while(Input.GetMouseButton(0))
        {
            Shot(transform);
            yield return new WaitForSeconds(shotDelay);
        }
    }

    protected override void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "EnemyBullet")
        {
            base.OnTriggerEnter2D(other);
        }
    }
}
