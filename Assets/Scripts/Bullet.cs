using UnityEngine;
using System.Collections;

public class Bullet : MonoBehaviour
{
    public float speed = 10;
    public float lifeTime;
    public  int power = 1;

    private Rigidbody2D rb2D;
	// Use this for initialization
	void Start ()
    {
        rb2D = GetComponent<Rigidbody2D>();
        rb2D.velocity = transform.up * speed;
        Invoke("SetInactive", lifeTime);
    }
	
	// Update is called once per frame
	void Update ()
    {
        for(int i = 0; i < this.transform.childCount; i++)
        {
            this.transform.GetChild(i).gameObject.SetActive(true);
        }
	}

    public void SetInactive()
    {
        gameObject.SetActive(false);
    }
}
