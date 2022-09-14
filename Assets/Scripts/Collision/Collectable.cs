using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collectable : MonoBehaviour
{
    // on a besoin de la reference du target du joueur
    public string targetTag = "Player";


    private void OnTriggerEnter2D(Collider2D target)
    {
        // d'abord verifier si le target est bien player
        if (target.gameObject.tag == targetTag)
        {
            OnCollect(target.gameObject);
            OnDestroy();
        }
    }
    
    // on aura deux méthodes une pour collecter et l'autre pour supprimer l'objet une fois prise
    protected virtual void OnCollect(GameObject target)
    {
        
    }

    protected virtual void OnDestroy()
    {
        Destroy(gameObject);
    }
}
