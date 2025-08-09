using UnityEngine;

public class EnemyPatrol : MonoBehaviour
{
    [SerializeField] private float velocidade = 2f;
    [SerializeField] private Transform wallCheck;
    [SerializeField] private Vector2 boxSize = new Vector2(0.5f, 1f);
    [SerializeField] private LayerMask wallLayer;

    private Rigidbody2D rb;
    private int direcaoMovimento = 1;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {
        rb.velocity = new Vector2(direcaoMovimento * velocidade, rb.velocity.y);

        bool temParede = Physics2D.OverlapBox(wallCheck.position, boxSize, 0, wallLayer);

        if (temParede)
        {
            Virar();
        }
    }

    private void Virar()
    {
        direcaoMovimento *= -1;
        
        Vector3 localScale = transform.localScale;
        localScale.x *= -1f;
        transform.localScale = localScale;
    }

    private void OnDrawGizmos()
    {
        if (wallCheck != null)
        {
            Gizmos.color = Color.blue;
            Gizmos.DrawWireCube(wallCheck.position, boxSize);
        }
    }
}