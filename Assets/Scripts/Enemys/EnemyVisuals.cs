using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class EnemyVisuals : MonoBehaviour {

    public Sprite Frame1;
    public Sprite Frame2;

    private GameObject Player;

    private Sprite[] EnemySprites;

    private int Counter;

    public int Health;

    private UnityEngine.AI.NavMeshAgent Agent;

    private EnemyAttack enemyAtt;
    
	void Start () {

        EnemySprites = new Sprite[2];

        EnemySprites[0] = Frame1;
        EnemySprites[1] = Frame2;

        Health = 10;

        Player = GameObject.FindWithTag("Player");

        Agent = GetComponent<UnityEngine.AI.NavMeshAgent>();

        enemyAtt = GetComponent<EnemyAttack>();
	}

    IEnumerator AttackPlayer()
    {
        for (;;)
        {
            this.gameObject.transform.GetChild(0).GetComponent<SpriteRenderer>().sprite = EnemySprites[Counter];
            Agent.SetDestination(Player.GetComponent<Transform>().position);
            yield return new WaitForSeconds(.3f);
            Counter++;
            if (Counter >= 2)
                Counter = 0;
        }
    }

    IEnumerator DamagedBlink()
    {
        for (int i = 0; i < 5; i++)
        {
            this.gameObject.transform.GetChild(0).GetComponent<SpriteRenderer>().color = new Color(1f,1f,1f,.5f);
            yield return new WaitForSeconds(.1f);
            this.gameObject.transform.GetChild(0).GetComponent<SpriteRenderer>().color = new Color(1f, 1f, 1f, 1f);
            yield return new WaitForSeconds(.1f);
        }
    }

public void Triggered()
    {
        Debug.Log("TRIGGERED");
        StartCoroutine(AttackPlayer());
    }

    public void Damage(int Damage)
    {
        Debug.Log("I took Damage for : " + Damage + "And my health before this is " + Health);
        Health -= (Damage + 1);

        if (Health < 0)
            GameObject.Destroy(this.gameObject);
        StartCoroutine(DamagedBlink());
    }


    void OnTriggerEnter(Collider Other)
    {
        Debug.Log(Other.ToString());

        if (Other.tag == "Player")
        {
            Debug.Log("IM TRIGGERED");
            Triggered();
        }

        if (Other.tag == "PlayerAttack")
        {
            Debug.Log("IM TRIGGERED TO ATTACK");
            enemyAtt.SetInARange(true);
        }
    }

    void OnTriggerExit(Collider Other)
    {
        Debug.Log(Other.ToString());

        if (Other.tag == "PlayerAttack")
        {
            Debug.Log("IM TRIGGERED TO NOT ATTACK");
            enemyAtt.SetInARange(false);
        }
    }
}