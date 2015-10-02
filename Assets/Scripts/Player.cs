using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour
{
    public float speed = 5;
    public GameObject PlayerBullet;

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

        StartCoroutine(Firing());
    }

    public IEnumerator Firing()
    {
        while(Input.GetMouseButton(0))
        {
            Instantiate(PlayerBullet, transform.position, transform.rotation);
            yield return new WaitForSeconds(0.5f);
        }
    }
}
