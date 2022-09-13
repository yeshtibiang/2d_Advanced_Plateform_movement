using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionState : MonoBehaviour
{
    public LayerMask collisionLayer;

    public bool standing;
    // detect if player is on wall
    public bool onWall;
    public Vector2 bottomPosition = Vector2.zero;
    // if player is on the right or left position
    public Vector2 rightPosition = Vector2.zero;
    public Vector2 leftPosition = Vector2.zero;
    
    public float collisionRadius = 10f;
    // color for debuggin the collision
    public Color debugCollisionColor = Color.red;
    
    // reference pour le input state
    private InputState inputState;
    
    void Awake()
    {
        inputState = GetComponent<InputState>();
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
        
        // pour détecter le player wall collision
        // on va caluler si le player est sur le mur ou non
        // on veut regarder si on recherche la pos gauche ou droite
        pos = inputState.direction == Directions.Right ? rightPosition : leftPosition;
        // on a besoin d'offset avec les position gauche et droite du gameobject
        pos.x += transform.position.x;
        pos.y += transform.position.y;
        onWall = Physics2D.OverlapCircle(pos, collisionRadius, collisionLayer);

    }
    
    
    // on crée une méthode onDrowGuizmo qui va être appelé juste à l'interieure de la scène. 
    void OnDrawGizmos()
    {
        // change the color of the guizmo
        Gizmos.color = debugCollisionColor;
        
        // au lieu de récopier le suivant pour chaque position, créons un array de position
        var positions = new Vector2[] { rightPosition, bottomPosition, leftPosition };

        foreach (var position in positions)
        {
            // on a besoin des position pour dessiner le cercle
            var pos = position;
            pos.x += transform.position.x;
            pos.y += transform.position.y;
            // dessinons le cercle
            Gizmos.DrawWireSphere(pos, collisionRadius);
        }

    }
}
