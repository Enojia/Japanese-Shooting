using UnityEngine;
using System.Collections;

public class Player : Spaceship
{
    public AudioSource FiringSound;
	// Use this for initialization
	protected override void Start ()
    {
        base.Start();
        speed = 5;
        shotDelay = 3.0f;
        FiringSound = GetComponent<AudioSource>();
        StartCoroutine(Firing());
    }
	
	// Update is called once per frame
	void Update ()
    {
        float x = Input.GetAxisRaw("Horizontal");
        float y = Input.GetAxisRaw("Vertical");

        Vector3 direction = new Vector3(x, y, 0).normalized; //unit direction of the mouvment;

        Move(direction);
        
    }

    public IEnumerator Firing()
    {
        while(true)
        {
            Shot(transform);
            FiringSound.Play();

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
