using UnityEngine;
using System.Collections;

public class EnemyAttack : MonoBehaviour {

    public float Damage;
    bool InARange;
    private HealthHandler healthHandler;

    void Start () {
        InARange = false;
        healthHandler = GameObject.Find("Scripts").GetComponent<HealthHandler>();
        Damage = 3f;

        StartCoroutine(InRange());
    }
	
    public void SetInARange(bool inARange)
    {
        InARange = inARange;
    }

    IEnumerator InRange()
    {
        for(;;)
        {
            if(InARange)
            {
                healthHandler.ReduceHealth((int)Damage);
            }
            yield return new WaitForSeconds(1f);
        }
    }
}
