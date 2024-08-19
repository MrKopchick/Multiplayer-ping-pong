using UnityEngine;
using Mirror;

public class Ball : NetworkBehaviour
{
    public float speed = 30;
    public Rigidbody2D rigidbody2d;

    public override void OnStartServer()
    {
        base.OnStartServer();
        
        rigidbody2d.simulated = true;
        rigidbody2d.velocity = Vector2.right * speed;
    }

    float HitFactor(Vector2 ballPos, Vector2 racketPos, float racketHeight)
    {
        return (ballPos.y - racketPos.y) / racketHeight;
    }

    [ServerCallback]
    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.transform.GetComponent<Player>())
        {
            float y = HitFactor(transform.position, col.transform.position, col.collider.bounds.size.y);
            
            float x = col.relativeVelocity.x > 0 ? 1 : -1;
            Vector2 dir = new Vector2(x, y).normalized;
            rigidbody2d.velocity = dir * speed;
        }
    }
}
