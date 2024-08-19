using UnityEngine;
using Mirror;

public class Player : NetworkBehaviour
{
    public float speed = 30;
    public Rigidbody2D rigidbody2d;
    
    void FixedUpdate()
    {
        if (isLocalPlayer)
            rigidbody2d.velocity = new Vector2(0, Input.GetAxisRaw("Vertical")) * speed * Time.fixedDeltaTime;
    }
}
