using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum PlayerState
{
    walk,
    attack
}

public class PlayerMovement : MonoBehaviour
{
    public Animator anim;

    public float speed = 5;
    public Rigidbody2D rb;
    new Vector2 movement;
    public PlayerState currentState;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        currentState = PlayerState.walk;
    }

    // Update is called once per frame
    void Update()
    {
        movement = Vector2.zero;
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");

        if (Input.GetKeyDown(KeyCode.Mouse0) && currentState != PlayerState.attack)
        {
            StartCoroutine(Attack());
        }
        else if (currentState != PlayerState.attack)
        {
            UpdateAnimationandMove();
        }
    }

    private IEnumerator Attack()
    {
        anim.SetBool("Attacking", true);
        currentState = PlayerState.attack;
        yield return null;
        anim.SetBool("Attacking", false);
        yield return new WaitForSeconds(.33f);
        currentState = PlayerState.walk;
    }

    void UpdateAnimationandMove()
    {
        if (movement != Vector2.zero)
        {
            anim.SetFloat("Horizontal", movement.x);
            anim.SetFloat("Vertical", movement.y);
            anim.SetFloat("Speed", speed);
            anim.SetBool("Moving", true);
        }
        else
        {
            anim.SetBool("Moving", false);
        }
    }

    private void FixedUpdate()
    {
        rb.MovePosition(rb.position + movement.normalized * speed * Time.fixedDeltaTime);
    }
}
