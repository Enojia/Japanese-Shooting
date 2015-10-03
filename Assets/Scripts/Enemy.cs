using UnityEngine;
using System.Collections;

public class Enemy : Spaceship
{
    public bool CanShoot;

	// Use this for initialization
	protected override void Start ()
    {
        speed = 0.5f;
        shotDelay = 2.5f;
        base.Start();
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
}
