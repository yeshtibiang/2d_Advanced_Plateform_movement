using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionState : MonoBehaviour
{
    public LayerMask collisionLayer;

    public bool standing;

    public Vector2 bottomPosition = Vector2.zero;
    public float collisionRadius = 10f;
    // color for debuggin the collision
    public Color debugCollisionColor = Color.red;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    //utilisons une méthode fixedUpdate pour faire les calculs physiques
    void FixedUpdate()
    {
        // reference de la position qu'on veut tester
        var pos = bottomPosition;
        pos.x += transform.position.x;
        pos.y += transform.position.y;
        
        // on va vérifier si on détecte une collision overlap entre la position et son radius par 
        // rapport au collision layer
        // overlap permet de vérifier si un collider est dans un circular area
        // cela va retourner true si cela est dans le layer sinon false
        standing = Physics2D.OverlapCircle(pos, collisionRadius, collisionLayer);
    }
    
    
    // on crée une méthode onDrowGuizmo qui va être appelé juste à l'interieure de la scène. 
    void OnDrawGizmos()
    {
        // change the color of the guizmo
        Gizmos.color = debugCollisionColor;
        // on a besoin des position pour dessiner le cercle
        var pos = bottomPosition;
        pos.x += transform.position.x;
        pos.y += transform.position.y;
        
        // dessinons le cercle
        Gizmos.DrawWireSphere(pos, collisionRadius);
        
    }
}
