using UnityEngine;

public class Agujero : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D collision)
    {
        // 1. Si entra la bola blanca, regresa al centro
        if (collision.CompareTag("PelotaBlanca"))
        {
            collision.transform.position = Vector3.zero;
            collision.GetComponent<Rigidbody2D>().linearVelocity = Vector2.zero;
            collision.GetComponent<Rigidbody2D>().angularVelocity = 0f;
        }
        // 2. Si entra una bola con el tag BolaColor, la destruimos
        else if (collision.CompareTag("BolaColor"))
        {
            Destroy(collision.gameObject);
        }
    }
}