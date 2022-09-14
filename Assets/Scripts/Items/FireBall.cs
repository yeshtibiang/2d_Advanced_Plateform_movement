using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireBall : MonoBehaviour
{
    
    // on veut appliquer une vélocité lorsque le fireball est créé
    public Vector2 initialVelocity = new Vector2(100, -100);
    public int bounces = 3;
    
    // reference au rigidbody
    private Rigidbody2D body2d;

    private void Awake()
    {
        body2d = GetComponent<Rigidbody2D>();
    }

    // Start is called before the first frame update
    void Start()
    {
        // calculons l'actuel velocité
        // velocité de départ
        var startVelX = initialVelocity.x * transform.localScale.x;
        
        // appliquons cela au body2d
        body2d.velocity = new Vector2(startVelX, initialVelocity.y);
    }

    private void OnCollisionEnter2D(Collision2D target)
    {
        // si la position du target est inferieure a notre ball
        if (target.gameObject.transform.position.y < transform.position.y)
        {
            bounces--;
        }

        if (bounces <= 0)
        {
            // on détruit le GameObject
            Destroy(gameObject);
        }
    }
}
