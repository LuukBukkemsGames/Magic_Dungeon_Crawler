using UnityEngine;
using System.Collections;

public class ManaHandler : MonoBehaviour {

    public GameObject ManaCanvas;

    private GameObject[] ManaBar;

    public float Mana;


	void Start () {
        ManaBar = new GameObject[8];
	   for(int i = 0; i < ManaCanvas.transform.childCount; i++)
        {
            ManaBar[i] = ManaCanvas.transform.GetChild(i).gameObject;
        }

        Mana = 8; 

        StartCoroutine(RestoreMana());
	}

    public float getMana()
    {
        return Mana;
    }

    public void reduceMana(float mana)
    {
        Mana -= mana;

        if (Mana < 0)
            Mana = 0;

        UpdateMana();
    }

    IEnumerator RestoreMana()
    {
        for (;;)
        {
            if (Mana < 8)
            {
                Mana++;
                UpdateMana();
            }
            yield return new WaitForSeconds(1.5f);
        }
    }

    void UpdateMana()
    {
        for (int i = 0; i <= 7; i++)
        {
            if(Mana > i)
                ManaBar[i].SetActive(true);
            
            else
                ManaBar[i].SetActive(false);
        }
    }
}
