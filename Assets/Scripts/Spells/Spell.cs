using UnityEngine;
using System.Collections;

public class Spell : MonoBehaviour {

    public ManaHandler manaHandler;

    public PlayerMovement playerMovement;

    private int ManaCost;
    private int Element;
    private int Strength;
    private int Shape;

    public GameObject[] SpellTiles;

    int NrOfTiles;

    private float Direction;

    public float PlaneSize;
    public float planeHeigth;

    private AudioSource[] SpellTileSounds;

    public AudioSource ClipFire;
    public AudioSource ClipLightning;
    public AudioSource ClipWater;


    void Start () {
        ManaCost = 0;
        Element = 0;
        Strength = 0;
        Shape = 0;

        SpellTiles = new GameObject[10];

        PlaneSize = 7.5f;
        planeHeigth = .4f;

        SpellTileSounds = new AudioSource[3];

        SpellTileSounds[0] = ClipFire;
        SpellTileSounds[2] = ClipLightning;
        SpellTileSounds[1] = ClipWater;

    }
	
    public void UpdateValues(float element, float strength, float shape)
    {
        Element = (int)element;
        Strength = (int)strength;
        Shape = (int)shape;

        ManaCost = (Strength + 1) + (Shape + 1);
    }

    public void CastSpell()
    {
        NrOfTiles = 0;

        if (ManaCost <= manaHandler.getMana())
        {
            Direction = playerMovement.getDirection();
            manaHandler.reduceMana(ManaCost);

            if (Shape == 0)
            {
                NrOfTiles = 1;

                if (Direction == 0)
                {
                    SpellTiles[0] = GameObject.Instantiate(Resources.Load("Prefabs/Spell Tile"), new Vector3((playerMovement.GetComponent<Transform>().position.x), planeHeigth, (playerMovement.GetComponent<Transform>().position.z - PlaneSize)), playerMovement.GetComponent<Transform>().rotation) as GameObject;
                }

                if (Direction == 3)
                {
                    SpellTiles[0] = GameObject.Instantiate(Resources.Load("Prefabs/Spell Tile"), new Vector3((playerMovement.GetComponent<Transform>().position.x - PlaneSize), planeHeigth, (playerMovement.GetComponent<Transform>().position.z)), playerMovement.GetComponent<Transform>().rotation) as GameObject;
                }

                if (Direction == 2)
                {
                    SpellTiles[0] = GameObject.Instantiate(Resources.Load("Prefabs/Spell Tile"), new Vector3((playerMovement.GetComponent<Transform>().position.x), planeHeigth, (playerMovement.GetComponent<Transform>().position.z + PlaneSize)), playerMovement.GetComponent<Transform>().rotation) as GameObject;
                }

                if (Direction == 1)
                {
                    SpellTiles[0] = GameObject.Instantiate(Resources.Load("Prefabs/Spell Tile"), new Vector3((playerMovement.GetComponent<Transform>().position.x + PlaneSize), planeHeigth, (playerMovement.GetComponent<Transform>().position.z)), playerMovement.GetComponent<Transform>().rotation) as GameObject;
                }
            }

            if(Shape == 1)
            {
                NrOfTiles = 3;

                for (int i = 0; i < 3; i++)
                {
                    if (Direction == 0)
                    {
                        SpellTiles[i] = GameObject.Instantiate(Resources.Load("Prefabs/Spell Tile"), new Vector3((playerMovement.GetComponent<Transform>().position.x), planeHeigth, (playerMovement.GetComponent<Transform>().position.z - PlaneSize - (PlaneSize * i ))), playerMovement.GetComponent<Transform>().rotation) as GameObject;
                    }

                    if (Direction == 3)
                    {
                        SpellTiles[i] = GameObject.Instantiate(Resources.Load("Prefabs/Spell Tile"), new Vector3((playerMovement.GetComponent<Transform>().position.x - PlaneSize - (PlaneSize * i)), planeHeigth, (playerMovement.GetComponent<Transform>().position.z)), playerMovement.GetComponent<Transform>().rotation) as GameObject;
                    }

                    if (Direction == 2)
                    {
                        SpellTiles[i] = GameObject.Instantiate(Resources.Load("Prefabs/Spell Tile"), new Vector3((playerMovement.GetComponent<Transform>().position.x), planeHeigth, (playerMovement.GetComponent<Transform>().position.z + (PlaneSize * (i + 1)))), playerMovement.GetComponent<Transform>().rotation) as GameObject;
                    }

                    if (Direction == 1)
                    {
                        SpellTiles[i] = GameObject.Instantiate(Resources.Load("Prefabs/Spell Tile"), new Vector3((playerMovement.GetComponent<Transform>().position.x + PlaneSize + (PlaneSize * i )), planeHeigth, (playerMovement.GetComponent<Transform>().position.z)), playerMovement.GetComponent<Transform>().rotation) as GameObject;
                    }
                }
            }

            if (Shape == 2)
            {
                NrOfTiles = 8;

                for (int i = 0; i < 3; i++)
                {
                    SpellTiles[i] = GameObject.Instantiate(Resources.Load("Prefabs/Spell Tile"), new Vector3((playerMovement.GetComponent<Transform>().position.x - PlaneSize), planeHeigth, (playerMovement.GetComponent<Transform>().position.z - PlaneSize + (PlaneSize* i))) , playerMovement.GetComponent<Transform>().rotation) as GameObject;
                }

                for (int i = 0; i < 3; i++)
                {
                    SpellTiles[3 + i] = GameObject.Instantiate(Resources.Load("Prefabs/Spell Tile"), new Vector3((playerMovement.GetComponent<Transform>().position.x + PlaneSize), planeHeigth, (playerMovement.GetComponent<Transform>().position.z - PlaneSize + (PlaneSize * i))), playerMovement.GetComponent<Transform>().rotation) as GameObject;
                }

                for (int i = 0; i < 2; i++)
                {
                    SpellTiles[6 + i] = GameObject.Instantiate(Resources.Load("Prefabs/Spell Tile"), new Vector3((playerMovement.GetComponent<Transform>().position.x), planeHeigth, (playerMovement.GetComponent<Transform>().position.z - PlaneSize + (2 * PlaneSize * i))), playerMovement.GetComponent<Transform>().rotation) as GameObject;
                }

            }

            Debug.Log("Spell Cast : Element =" + Element + " ; Strength = " + Strength + " ; Shape =" + Shape + "mana cost :" + ManaCost);

            for (int i = 0; i < NrOfTiles; i++)
            {
                SpellTiles[i].GetComponent<SpellCollider>().InitValues(Strength, Element);
            }

            SpellTileSounds[Element].Play();
        }

        else
            Debug.Log("Needs moor meneh");
    }
}
