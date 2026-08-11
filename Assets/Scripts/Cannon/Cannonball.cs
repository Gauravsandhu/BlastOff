using System;
using UnityEngine;
using UnityEngine.Rendering;

public class Cannonball : MonoBehaviour
{

    [SerializeField] private float destroyCounter = 0;
    public float maxSpeed = 40f;
    public Rigidbody2D rb;
    public float max_bounce = 5f;

void FixedUpdate()
    {
        if (rb.linearVelocity.magnitude > maxSpeed)
        {
            rb.linearVelocity = rb.linearVelocity.normalized * maxSpeed;
        }
}

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.transform.root.gameObject.CompareTag("Player1Cannon"))
        {
            Debug.Log("Hit a cannon!");
            Destroy(collision.transform.root.gameObject);
            GameManager.Instance.RegisterRoundWin(2);
            Destroy(gameObject);
        }
        else if (collision.transform.root.gameObject.CompareTag("Player2Cannon"))
        {
            Destroy(collision.transform.root.gameObject);
            GameManager.Instance.RegisterRoundWin(1);
            Destroy(gameObject);
        }
        if (collision.gameObject.CompareTag("Wall"))
        {
            Destroy(gameObject);
        }

        if (collision.gameObject.CompareTag("NeutralWall"))
        {
            destroyCounter+=1;
        }
        
        // Destroy cannonball after bounces
        if(destroyCounter >=max_bounce)
        {
            Destroy(gameObject);
        }  
    }  
}