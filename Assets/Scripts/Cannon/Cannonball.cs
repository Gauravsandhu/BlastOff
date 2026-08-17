using UnityEngine;

public class Cannonball : MonoBehaviour
{
    [SerializeField] private float destroyCounter = 0;
    [SerializeField] private float damage = 50f;
    public float maxSpeed = 400f;
    public Rigidbody2D rb;
    public float max_bounce = 5f;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.transform.root.gameObject.CompareTag("Player1Cannon") ||
            collision.transform.root.gameObject.CompareTag("Player2Cannon"))
        {
            CannonHealth health = collision.transform.root.gameObject.GetComponent<CannonHealth>();
            if (health != null)
            {
                health.TakeDamage(damage);
            }
            Destroy(gameObject);
            return;
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

        public void SetDamage(float amount)
    {
        damage = amount;
    }
}