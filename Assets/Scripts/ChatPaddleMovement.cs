using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChatPaddleMovement : MonoBehaviour
{

    private Rigidbody2D rb;
    public float pushForce;

    // Start is called before the first frame update
    void Start()
    {
        rb = this.GetComponent<Rigidbody2D>();
    }

    public void ChatButtonPressed(string button) {

        Vector2 move = new Vector2();

        if(button == "up") {
            move.y = pushForce;
        }

        if(button == "down") {
            move.y = -pushForce;
        }

        Debug.Log(move);

        rb.AddForce(move);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
