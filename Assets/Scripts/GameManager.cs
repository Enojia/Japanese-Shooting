using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public GameObject Player;
    public static GameManager instance;

    public Text TitleText;
	// Use this for initialization
	void Start ()
    {
        if (instance == null)
            instance = this;
        else if (instance != null)
            Destroy(gameObject);
        DontDestroyOnLoad(gameObject);
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
