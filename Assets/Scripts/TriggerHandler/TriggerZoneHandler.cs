using UnityEngine;
using System.Collections;

public class TriggerZoneHandler : MonoBehaviour {

    public Texture TriggeredTexture;
    public GameObject Tile;

    public GameObject CameraToMove;
    public GameObject MainCam;
    public Vector3 PlaceToGo;

    public bool Triggered;

    private Vector3 VelocityVector;

    public GameObject TilesToSpawn;

    void Start()
    {
        VelocityVector = Vector3.zero;
        Triggered = false;
    }

    void OnTriggerEnter(Collider o)
    {
        Debug.Log(o.tag + " triggered me");
        if (o.tag == "Player" && !Triggered)
        {
            Triggered = true;
            Tile.GetComponent<Renderer>().material.mainTexture = TriggeredTexture;

            CameraToMove.transform.position = MainCam.transform.position;
            CameraToMove.GetComponent<Camera>().enabled = true;
            MainCam.GetComponent<Camera>().enabled = false;

            StartCoroutine(MoveToPosition());

        }
    }

    IEnumerator MoveToPosition()
    {
        for (int i = 0; i < 660; i++)
        {
            CameraToMove.transform.position = Vector3.SmoothDamp(CameraToMove.transform.position, PlaceToGo, ref VelocityVector, 1f);
            if(i < 600)
                TilesToSpawn.transform.position = new Vector3(TilesToSpawn.transform.position.x, TilesToSpawn.transform.position.y +.1f, TilesToSpawn.transform.position.z);
            yield return new WaitForSeconds(1/60);
        }
        CameraToMove.GetComponent<Camera>().enabled = false;
        MainCam.GetComponent<Camera>().enabled = true;
    }
}
