using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    [SerializeField] bool buttonCOntrol;
    [SerializeField] float speed = 4f;
    [SerializeField] float speed2 = 4f;
    [SerializeField] Rigidbody2D rb;

    [SerializeField] SpriteRenderer sprite;

    private float movement = 0f;
    // Update is called once per frame
    void Update()
    {
        if (!buttonCOntrol)
        {
            movement = Input.GetAxisRaw("Horizontal") * speed;
        }
        else
        {
            movement = speed2;
        }

        if (Input.GetAxisRaw("Horizontal") != 0)
        {
            sprite.flipX = (movement > 0);
        }
    }

    private bool isMovingLeft;
    private bool isMovingRight;
    public void MoveLeft()
    {
        sprite.flipX = false;
        isMovingLeft = true;
    }
    public void MoveRight()
    {
        sprite.flipX = true;
        isMovingRight = true;
    }

    public void StopMoving()
    {
        isMovingRight = false;
        isMovingLeft = false;
    }

    private void FixedUpdate()
    {
        if (!buttonCOntrol)
        {
            rb.MovePosition(rb.position + new Vector2(movement * Time.fixedDeltaTime, 0f));
        }
        else
        {
            if (isMovingLeft)
            {
                rb.MovePosition(rb.position - new Vector2(movement * Time.fixedDeltaTime, 0f));
            }
            else if (isMovingRight)
            {
                rb.MovePosition(rb.position + new Vector2(movement * Time.fixedDeltaTime, 0f));
            }

        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Saw")
        {
            //GamePlayController.Instance.UpdateScore(collision.gameObject.GetComponent<SawController>().GetPoint());
            //GamePlayController.Instance.IncreaseTime(collision.gameObject.GetComponent<SawController>().GetHP());
            //Destroy(collision.gameObject);
        }
    }
}
