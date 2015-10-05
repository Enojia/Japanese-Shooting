using UnityEngine;
using System.Collections;

public class BackGround : MonoBehaviour
{
    public float Speed = 0.01f;

    private Renderer render;

	// Use this for initialization
	void Start ()
    {
        render = GetComponent<Renderer>();
	}
	
	// Update is called once per frame
	void Update ()
    {
        float y = Mathf.Repeat(Time.time * Speed, 1);

        Vector2 offset = new Vector2(0, y);

        render.sharedMaterial.SetTextureOffset("_MainTex", offset);
	}
}
