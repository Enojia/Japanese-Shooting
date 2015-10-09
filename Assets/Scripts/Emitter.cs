using UnityEngine;
using System.Collections;


public class Emitter : MonoBehaviour
{
    public GameObject[] Waves;
    public GameObject Wave;

    //private int currentWaves;

    private int randomIndex;

    IEnumerator Start()
    {
        while(GameManager.instance.IsPlaying() == false)
        {
            yield return new WaitForEndOfFrame();
        }

        while(true)
        {
            randomIndex = Random.Range(0, Waves.Length);

            Wave = (GameObject)Instantiate(Waves[randomIndex], transform.position, Quaternion.identity);

            Wave.transform.parent = transform;

            while(Wave.transform.childCount != 0)
            {
                yield return new WaitForEndOfFrame();
            }

            
            Destroy(Wave);
            /*
            if(Waves.Length <= ++currentWaves)
            {
                currentWaves = 0;
            }
            */
        }
    }
}
