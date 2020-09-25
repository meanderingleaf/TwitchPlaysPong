using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInput : MonoBehaviour
{

    private Rigidbody2D rb;
    public float speed;

    // Start is called before the first frame update
    void Start()
    {
        rb = this.GetComponent<Rigidbody2D>();   
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 velocity = new Vector2(0f, Input.GetAxis("Vertical"));
        rb.MovePosition(rb.position + velocity * speed * Time.fixedDeltaTime);
    }
}
