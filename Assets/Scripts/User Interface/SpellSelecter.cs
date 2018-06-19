using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class SpellSelecter : MonoBehaviour {

    public Spell SpellValues;

    public Sprite [] SpellImages;
    public Sprite[] SizeImages;
    public Sprite[] ShapeImages;

    public float SelectedSpell;
    public float SelectedSize;
    public float SelectedShape;

    public GameObject SpellImage;
    public GameObject SizeImage;
    public GameObject ShapeImage;

    private GameObject[] Pictures;

    private int SelectedImage;

    private Color c;

    float Difference;

    void Start () {
        SelectedSpell = 0;
        SelectedSize = 0;
        SelectedShape = 0;

        SelectedImage = 0;

        Difference = 0;

        Pictures = new GameObject[3];
        Pictures[0] = SpellImage;
        Pictures[1] = SizeImage;
        Pictures[2] = ShapeImage;
	}
	
	void Update () {

        SelectImage();

        SetSelectedImage();

        HandleScroll();

        UpdateImages();

        SpellValues.UpdateValues(SelectedSpell, SelectedSize, SelectedShape);
	}

    void SelectImage()
    {

        if (Input.GetKeyDown(KeyCode.Q) && !Input.GetKeyDown(KeyCode.E))
            SelectedImage--;

        else if (Input.GetKeyDown(KeyCode.E) && !Input.GetKeyDown(KeyCode.Q))
            SelectedImage++;
    }

    void SetSelectedImage()
    {
        if (SelectedImage < 0)
            SelectedImage = 2;

        if (SelectedImage > 2)
            SelectedImage = 0;

        for(int i = 0; i < 3; i++)
        {
            c = Pictures[i].GetComponent<Image>().color;
            if (SelectedImage == i)
                c.a = 1f;
            else
                c.a = .5f;
            Pictures[i].GetComponent<Image>().color = c;    
        }
    }

    void HandleScroll()
    {
        Difference = 0;

        if(Input.GetAxis("Mouse ScrollWheel") > 0)
            Difference = 1;

        if(Input.GetAxis("Mouse ScrollWheel") < 0 )
            Difference = -1;

        if (SelectedImage == 0)
            SelectedSpell += Difference;
        else if (SelectedImage == 1)
            SelectedSize += Difference;
        else if (SelectedImage == 2)
            SelectedShape += Difference;

        SetSelectedImageNr();
    }

    void SetSelectedImageNr()
    {
        if (SelectedSpell > 2)
            SelectedSpell = 0;

        if (SelectedSpell < 0)
            SelectedSpell = 2;

        if (SelectedSize > 2)
            SelectedSize = 0;

        if (SelectedSize < 0)
            SelectedSize = 2;

        if (SelectedShape > 2)
            SelectedShape = 0;

        if (SelectedShape < 0)
            SelectedShape = 2;
    }

    void UpdateImages()
    {
        SpellImage.GetComponent < Image >().sprite = SpellImages[(int)SelectedSpell];
        SizeImage.GetComponent<Image>().sprite = SizeImages[(int)SelectedSize];
        ShapeImage.GetComponent<Image>().sprite = ShapeImages[(int)SelectedShape];
    }
}
