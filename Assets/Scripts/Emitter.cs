using UnityEngine;
using System.Collections;

public class Emitter : MonoBehaviour
{
    public GameObject[] Waves;

    private int currentWaves;

    IEnumerator Start()
    {
        while(GameManager.instance.IsPlaying() == false)
        {
            yield return new WaitForEndOfFrame();
        }

        while(true)
        {
            GameObject wave = (GameObject)Instantiate(Waves[currentWaves], transform.position, Quaternion.identity);

            wave.transform.parent = transform;

            while(wave.transform.childCount != 0)
            {
                yield return new WaitForEndOfFrame();
            }

            Destroy(wave);

            if(Waves.Length <= ++currentWaves)
            {
                currentWaves = 0;
            }
        }
    }
}
