﻿using UnityEngine;
using System.Collections;
using System;

public delegate void ScoreHandler(int Point);

public class Enemy : Spaceship
{
    public bool CanShoot;
    public int ValuePoint;
    private Animator anim;
    public static event ScoreHandler ScoreEvent;

	// Use this for initialization
	protected override void Start ()
    {
        anim = GetComponent<Animator>();
        ValuePoint = 10;
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

    void OnDisable()
    {
        ScoreEvent(ValuePoint);
    }
}
