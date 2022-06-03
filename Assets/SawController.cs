using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SawController : MonoBehaviour
{
    public int index;

    [SerializeField] float speed;
    [SerializeField] int dir;

    // Start is called before the first frame update
    void Start()
    {
        speed = dir * speed;
    }

    private void Update()
    {
        transform.position = new Vector2(transform.position.x + speed * Time.deltaTime, transform.position.y);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Ground")
        {
            // Send info
            GamePlayController.Instance.GameOver();
        }
    }

    public int GetIndex()
    {
        return index;
    }

}
