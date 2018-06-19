using UnityEngine;
using System.Collections;

public class FogOfWarHandler : MonoBehaviour {

    public ManaHandler manaHandler;

    private float Size;

    public float MinSize;
    public float MaxSize;

    private float Counter;

	void Start () {
        MinSize = .3f;
        MaxSize = 1.5f;

        Size = .3f;
	}

    void FixedUpdate()
    {
        if(Input.GetKey(KeyCode.Mouse1))
        {
            Size += (Time.fixedDeltaTime / 5);
        }

        else
        {
            Size -= (Time.fixedDeltaTime / 5);
        }

        if (Size > MaxSize)
        {
            Size = MaxSize;
            CheckForMana();
        }

        if (Size < MinSize)
            Size = MinSize;

        this.gameObject.transform.localScale = new Vector3(Size, Size, Size);
    }

    void CheckForMana()
    {
        Counter += Time.fixedDeltaTime;

        if(Counter > .5)
        {
            Counter = 0;    
            manaHandler.reduceMana(1);
        }
    }

}
