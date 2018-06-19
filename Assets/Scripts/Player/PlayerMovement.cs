using UnityEngine;
using System.Collections;

public class PlayerMovement : MonoBehaviour {

    private CharacterController CharContr;
    private Vector3 Movement;

    public float Speed;

    public Sprite Front;
    public Sprite Back;
    public Sprite Right;
    public Sprite Left;

    float Direction;

    private SpriteRenderer Rend;

    void Start () {
        CharContr = this.gameObject.GetComponent<CharacterController>();
        Movement = Vector3.zero;
        Speed = 10;

        Rend = this.gameObject.GetComponent<SpriteRenderer>();

        Direction = 0;

	}
	
	void FixedUpdate () {
        Movement.z = Input.GetAxis("Vertical");
        Movement.x = Input.GetAxis("Horizontal");
        Movement.y = -1f;

        if (Movement.z < 0)
        {
            Rend.sprite = Front;
            Direction = 0;
        }

        if (Movement.z > 0)
        {
            Rend.sprite = Back;
            Direction = 2;
        }

        if (Movement.x > 0 && Movement.x > Movement.z && Movement.x * -1 < Movement.z)
        {
            Rend.sprite = Right;
            Direction = 1;
        }

        if (Movement.x < 0 && Movement.x < Movement.z && Movement.x * -1 > Movement.z)
        {
            Rend.sprite = Left;
            Direction = 3;
        }

        CharContr.Move(Movement * Speed * Time.fixedDeltaTime);
	}

    public float getDirection()
    {
        return Direction;
    }
}
