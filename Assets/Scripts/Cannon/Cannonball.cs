using System;
using Unity.VisualScripting.Antlr3.Runtime.Misc;
using UnityEngine;
using UnityEngine.Rendering;

public class Cannonball : MonoBehaviour
{

    [SerializeField] private float destroyCounter = 0;
    public float maxSpeed = 400f;
    public Rigidbody2D rb;
    public float max_bounce = 5f;



    private void OnCollisionEnter2D(Collision2D collision)
{
    if (collision.transform.root.gameObject.CompareTag("Player1Cannon"))
    {
        collision.transform.root.gameObject.SetActive(false);
        GameManager.Instance.RegisterRoundWin(2);
        Destroy(gameObject);
    }
    else if (collision.transform.root.gameObject.CompareTag("Player2Cannon"))
    {
        collision.transform.root.gameObject.SetActive(false);
        GameManager.Instance.RegisterRoundWin(1);
        Destroy(gameObject);
    }

    if (collision.gameObject.CompareTag("Wall"))
    {
        Destroy(gameObject);
    }

    if (collision.gameObject.CompareTag("NeutralWall"))
    {
        destroyCounter += 1;
    }

    if (destroyCounter >= max_bounce)
    {
        Destroy(gameObject);
    }
}
}