using UnityEngine;

public class ControlTaco : MonoBehaviour
{
    public Transform bolaBlanca; // Arrastra tu BolaBlanca aquí en el Inspector
    public float distanciaTaco = 2.5f; // Distancia para que no quede encima de la bola
    public float fuerzaGolpe = 15f;
    private Rigidbody2D rbBlanca;
    private SpriteRenderer spriteTaco; // Para ocultar/mostrar el taco visualmente

    void Start()
    {
        if (bolaBlanca != null)
            rbBlanca = bolaBlanca.GetComponent<Rigidbody2D>();
        
        spriteTaco = GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        if (bolaBlanca == null || rbBlanca == null) return;

        // Comprobamos si la bola blanca está casi detenida
        bool bolaQuieta = rbBlanca.linearVelocity.magnitude < 0.05f;

        if (bolaQuieta)
        {
            // 1. Mostrar el taco cuando es turno de tirar
            if (spriteTaco != null) spriteTaco.enabled = true;

            // Seguir la posición del mouse y apuntar
            Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            mousePos.z = 0f;

            Vector2 direccion = (mousePos - bolaBlanca.position).normalized;

            // Colocar el taco detrás de la bola
            transform.position = (Vector2)bolaBlanca.position - (direccion * distanciaTaco);

            // Rotar el taco hacia la bola (ajusta el ángulo si tu sprite apunta al revés)
            float angulo = Mathf.Atan2(direccion.y, direccion.x) * Mathf.Rad2Deg;
            transform.rotation = Quaternion.Euler(new Vector3(0, 0, angulo + 180f));

            // 2. Al hacer clic izquierdo, golpear la bola
            if (Input.GetMouseButtonDown(0))
            {
                rbBlanca.AddForce(direccion * fuerzaGolpe, ForceMode2D.Impulse);
            }
        }
        else
        {
            // Ocultar el taco automáticamente mientras las bolas se estén moviendo
            if (spriteTaco != null) spriteTaco.enabled = false;
        }
    }
}