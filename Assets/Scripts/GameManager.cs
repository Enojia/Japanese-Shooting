using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System;

public class GameManager : MonoBehaviour
{
    public GameObject Player;
    public static GameManager instance;
    public int HighestScoreNum;
    public Text HighestScore;

    public Text TitleText;
	// Use this for initialization
	void Start ()
    {
        if (instance == null)
            instance = this;
        else if (instance != null)
            Destroy(gameObject);
        DontDestroyOnLoad(gameObject);
        HighestScore = GameObject.Find("HighScore").GetComponent<Text>();
	}
	
	// Update is called once per frame
	void Update ()
    {
	    if(IsPlaying() == false && Input.GetKeyDown(KeyCode.X))
        {
            gameStart();
        }
	}

    void gameStart()
    {
        TitleText.enabled = false;
        Instantiate(Player, Player.transform.position, Player.transform.rotation);
        HighestScore.text = HighestScoreNum.ToString();
    }

    public void GameOver()
    {
        TitleText.enabled = true;
    }

    public bool IsPlaying()
    {
        if (TitleText.enabled == false)
        {
            return true;
        }

        else
            return false;
    }
}
