using UnityEngine;
using System.Collections;

public class HealthHandler : MonoBehaviour {

    public GameObject HealthCanvas;

    private GameObject[] HealthBar;

    public float Health;

    private GameObject Player;

    void Start () {
        HealthBar = new GameObject[8];
        for (int i = 0; i < HealthCanvas.transform.childCount; i++)
        {
            HealthBar[i] = HealthCanvas.transform.GetChild(i).gameObject;
        }

        Health = 8;

        StartCoroutine(RestoreHealth());

        Player = GameObject.Find("Player");
    }

    IEnumerator RestoreHealth()
    {
        for (;;)
        {
            if (Health < 8)
            {
                Health++;
                UpdateHealth();
            }
            yield return new WaitForSeconds(2f);
        }
    }

    public void ReduceHealth(int Damage)
    {
        Health -= Damage;

        Debug.Log("Took Damage for " + Damage + " . new health is " + Health);

        if(Health <= 0)
        {   
            Debug.Log("Rip m9");
            Health = 0;
        }
            UpdateHealth();

        StartCoroutine(DamagedBlink());
    }

    void UpdateHealth()
    {
        for (int i = 0; i <= 7; i++)
        {
            if (Health > i)
                HealthBar[i].SetActive(true);

            else
                HealthBar[i].SetActive(false);
        }
    }

    IEnumerator DamagedBlink()
    {
        for (int i = 0; i < 3; i++)
        {
            Player.GetComponent<SpriteRenderer>().color = new Color(1f, 1f, 1f, .5f);
            yield return new WaitForSeconds(.1f);
            Player.GetComponent<SpriteRenderer>().color = new Color(1f, 1f, 1f, 1f);
            yield return new WaitForSeconds(.1f);
        }
    }
}
