using UnityEngine;
using System.Collections;
using System;
using UnityEngine.UI;



public class Player : Spaceship
{
    public AudioSource FiringSound;
    public int ScoreNum;
    public Text Score;

	// Use this for initialization
	protected override void Start ()
    {
        base.Start();
        Score =  GameObject.Find("Score").GetComponent<Text>();
        speed = 5;
        shotDelay = 3.0f;
        hp = 10;
        FiringSound = GetComponent<AudioSource>();
        ScoreNum = 0;
        Enemy.ScoreEvent += updateScore;
    }
	
	// Update is called once per frame
	void Update ()
    {
        float x = Input.GetAxisRaw("Horizontal");
        float y = Input.GetAxisRaw("Vertical");

        Vector3 direction = new Vector3(x, y, 0).normalized; //unit direction of the mouvment;

        Move(direction);
        if(Input.GetMouseButton(0))
        {
            Shot(transform);
            FiringSound.Play();
        }
        
    }

    /*public IEnumerator Firing()
    {
        while(true)
        {
            Shot(transform);
            FiringSound.Play();

            yield return new WaitForSeconds(shotDelay);
        }
    }*/

    protected override void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "EnemyBullet")
        {
            Bullet shot = other.gameObject.GetComponent<Bullet>();
            hp -= shot.power;
            Destroy(other.gameObject);
        }

        if (hp <= 0)
        {
            Explode();
            
            Destroy(gameObject);
        }
    }

    protected override void Move(Vector3 direction)
    {
        Vector3 min = Camera.main.ViewportToWorldPoint(new Vector3(0, 0, 0)); //get the lower corner
        Vector3 max = Camera.main.ViewportToWorldPoint(new Vector3(1, 1, 0)); // upperRight Corner

        Vector3 pos = transform.position;

        pos += direction * speed * Time.deltaTime;

        pos.x = Mathf.Clamp(pos.x, min.x, max.x);
        pos.y = Mathf.Clamp(pos.y, min.y, max.y);

        transform.position = pos;
    }
    
    void OnDisable()
    {
        if(ScoreNum > GameManager.instance.HighestScoreNum)
        {
            GameManager.instance.HighestScoreNum = ScoreNum;
        }
        GameManager.instance.GameOver();
    }

    public void updateScore(object sender, ScoreEventArgs e)
    {
        ScoreNum += e.ValuePoint;
        Score.text = ScoreNum.ToString();
    }
}
