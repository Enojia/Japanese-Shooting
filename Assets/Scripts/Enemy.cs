using UnityEngine;
using System.Collections;
using System;

public class Enemy : Spaceship
{
    public bool CanShoot;
    
    private Animator anim;

	// Use this for initialization
	protected override void Start ()
    {
        anim = GetComponent<Animator>();
        speed = 0.5f;
        shotDelay = 2.5f;
        base.Start();
        hp = 10;
        Move(transform.up * -1);
        StartCoroutine(Firing());
    }
	
    
    public IEnumerator Firing()
    {
        if (CanShoot)
        {
            while (true)
            {
                for (int i = 0; i < transform.childCount; i++)
                {
                    Transform shotPosition = transform.GetChild(i);

                    Shot(shotPosition);
                }
                yield return new WaitForSeconds(shotDelay);
            }
        }

        else
            yield break;
    }

    protected override void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag == "PlayerBullet")
        {
            Bullet shot = other.GetComponentInParent<Bullet>();
            hp -= shot.power;
            Destroy(other.gameObject);
            anim.SetTrigger("TakingDamage");
        }

        base.OnTriggerEnter2D(other);
    }

    protected override void Move(Vector3 direction)
    {
        rb2D.velocity = direction * speed;
    }
}
