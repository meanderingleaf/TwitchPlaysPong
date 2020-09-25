using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PongBall : MonoBehaviour
{

    private Rigidbody2D rb;
    public float speed;
    public AudioSource bounceSound;
    public AudioSource respawnSound;
    public Transform respawnPoint;
    public GameObject poof;


    // Start is called before the first frame update
    void Start()
    {
        rb = this.GetComponent<Rigidbody2D>();

        rb.AddForce(new Vector2(200f * (Random.Range(-1f, 1f) < 0 ? -1 : 1), 60f * (Random.Range(-1f, 1f) < 0 ? -1 : 1)) * speed);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        bounceSound.Play();

        GameObject po = Instantiate(poof, this.transform.position, Quaternion.identity);
        Destroy(po, 1.5f);
    }

    private void Respawn()
    {
        rb.velocity = new Vector2(0f, 0f);
        
        rb.AddForce(new Vector2(200f * (Random.Range(-1f, 1f) < 0 ? -1 : 1), 60f * (Random.Range(-1f, 1f) < 0 ? -1 : 1)) * speed );

        this.transform.position = respawnPoint.position;
        respawnSound.Play();
    }
}
