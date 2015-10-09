using UnityEngine;
using System.Collections;

public class DestroyArea : MonoBehaviour
{

	void OnTriggerExit2D(Collider2D other)
    {
        if(other.tag == "PlayerBullet" || other.tag == "EnemyBullet")
        {
            other.gameObject.SetActive(false);
        }
        else
            Destroy(other.gameObject);

    }
}
