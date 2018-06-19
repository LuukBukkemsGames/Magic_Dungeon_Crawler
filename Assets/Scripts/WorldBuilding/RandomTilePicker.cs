using UnityEngine;
using System.Collections;

public class RandomTilePicker : MonoBehaviour {

    public Texture[] Textures;

    private Renderer myRenderer;

	void Start () {

        myRenderer = this.GetComponent < Renderer >();
        //Debug.Log( "pre" + myRenderer.material.mainTexture.ToString());
        myRenderer.material.mainTexture = Textures[Random.Range(0, 4)];

        if (Random.Range(0, 2) == 1)
            this.transform.eulerAngles = new Vector3(0, 135, 0);

        else
            this.transform.eulerAngles = new Vector3(0, -45, 0);
	}
}
