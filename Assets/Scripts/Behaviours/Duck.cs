using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Duck : AbstractBehaviour
{
    // pour duck le joueur on aura besoin
    public float scale = .5f; // on veut reduire à moitié le collider
    public bool ducking; // pour savoir qu'il est entrain de se baisser
    public float centerOffsetY = 0f; // c'est la position à laquelle on va alligner le joueur lorsqu'il va se relever
    
    // on a besoin de deux proprietes privé
    private CircleCollider2D circleCollider;
    private Vector2 originalCenter; // le centre point du collider lorsque le script commence. 
    
    // on override la méthode awake
    protected override void Awake()
    {
        base.Awake();

        circleCollider = GetComponent<CircleCollider2D>();
        originalCenter = circleCollider.offset;
    }

    protected virtual void OnDuck(bool value)
    {
        ducking = value;
        
        // appelons le ToggleScripts ici
        // si ducking true donc on envoie l'opposé de true
        ToggleScripts(!ducking);
        
        // taille du collider
        var size = circleCollider.radius;

        float newOffsetY;
        float sizeReciprocal;

        if (ducking)
        {
            sizeReciprocal = scale;
            newOffsetY = circleCollider.offset.y - size / 2 + centerOffsetY;
        }
        else
        {
            // on redonne la valeur reciproque
            sizeReciprocal = 1 / scale;
            // le newoffset revient au centre original
            newOffsetY = originalCenter.y;
        }
        
        // on calcule la taille finale pour pouvoir changer le circlecollider
        size = size * sizeReciprocal;
        circleCollider.radius = size;
        // on modifie l'offset pour qu'il prennent en compte les valeurs
        circleCollider.offset = new Vector2(circleCollider.offset.x, newOffsetY);
    }
    
    // il nous reste à appeler la fonction onDuck quand on detecte l'input
    

    // Update is called once per frame
    void Update()
    {
        var canDuck = inputState.GetButtonValue(inputButtons[0]);
        if (canDuck && collisionState.standing && !ducking)
        {
            OnDuck(true);
        }
        else if (ducking && !canDuck)
        {
            // on veut s'assurer de resize Onduck à false quand se baisse uniquement
            OnDuck(false); 
        }
    }
}
