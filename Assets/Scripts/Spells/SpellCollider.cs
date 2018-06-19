using UnityEngine;
using System.Collections;

public class SpellCollider : MonoBehaviour {

    private float Damage;
    private float Element;

    public Sprite[] ThisSprite = new Sprite[4];

    private int Counter;

    void Start()
    {
        Counter = 0;
    }

    public void InitValues(float damage, float element)
    {
        Damage = damage;

        Element = element;
        
        switch((int)element)
        {
            case 0:
                ThisSprite[0] = Resources.Load<Sprite>("Floor Spell Icons/FireFloorSquare");
                ThisSprite[1] = Resources.Load<Sprite>("Floor Spell Icons/FireFloorSquare2");
                ThisSprite[2] = Resources.Load<Sprite>("Floor Spell Icons/FireFloorSquare3");
                ThisSprite[3] = Resources.Load<Sprite>("Floor Spell Icons/FireFloorSquare2");
                StartCoroutine(SwapTimer());
                break;

            case 1:
                ThisSprite[0] = Resources.Load<Sprite>("Floor Spell Icons/WaterFloorSquare");
                //StartCoroutine(SwapTimer());
                break;

            case 2:
                ThisSprite[0] = Resources.Load<Sprite>("Floor Spell Icons/LightningFloorSquare");
                break; 
        }

        this.gameObject.GetComponent<SpriteRenderer>().sprite = ThisSprite[0];

        StartCoroutine(DestroySelf());
    }
	
void OnTriggerEnter(Collider Other)
    {
        Debug.Log(Other.gameObject.tag);
        Debug.Log(Other.gameObject.ToString());

        if (Other.gameObject.tag == "Enemy")
        {
            Debug.Log("Oyy mate, u did da damage. Damage is " + Damage + " and Element is " + Element);
            Other.gameObject.GetComponent<EnemyVisuals>().Damage((int)Damage);
        }
        else
        {
            Debug.Log("Hit somethin, m9 .. .Damage is " + Damage + " and Element is " + Element);
        }
    }

    IEnumerator DestroySelf()
    {
        yield return new WaitForSeconds(2f);
        Destroy(this.gameObject);
    }

    IEnumerator SwapTimer()
    {
        for (;;)
        {
            this.gameObject.GetComponent<SpriteRenderer>().sprite = ThisSprite[Counter];
            yield return new WaitForSeconds(.3f);
            Counter++;
            if (Counter >= 4)
                Counter = 0;
        }
    }
}