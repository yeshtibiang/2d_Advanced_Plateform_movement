using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireProjectile : AbstractBehaviour
{
    
    // shoot delay
    public float shootDelay = .5f;
    // reference à l'objet que l'on doit tirer
    public GameObject projectilePrefab;
    // pour mettre en place ou le fireball doit être lancé
    public Vector2 firePosition = Vector2.zero;
    public Color debugColor = Color.yellow;
    //radius pour le debu
    public float debugRadius = 3f;
    
    
    // time passé depuis le premier tir
    private float timeElapsed = 0f;
    

    // Update is called once per frame
    void Update()
    {
        // logique pour tirer le projectile
        // s'assurer de tirer si le projectilePrefab est différent de null
        if (projectilePrefab != null)
        {
            var canFire = inputState.GetButtonValue(inputButtons[0]);
            
            // s'assurer de pouvoir tirer
            if (canFire && timeElapsed > shootDelay)
            {
                // au lieu de passer en paramètre la position du player
                // on va juste calculer la position à laquelle on veut que le projectile apparait
                //CreateProjectile(transform.position);
                CreateProjectile(CalculateFirePosition());
                timeElapsed = 0;
            }
            // incrementer le timeElapsed
            timeElapsed += Time.deltaTime;
        }
    }
    
    // méthode pour calculer le fire position
    Vector2 CalculateFirePosition()
    {
        var pos = firePosition;
        // offset la position
        pos.x *= (float)inputState.direction;
        pos.x += transform.position.x;
        pos.y += transform.position.y;

        return pos;
    }

    public void CreateProjectile(Vector2 pos)
    {
        // as GameObject nous permet de cloner en tant que GameObject. 
        var clone = Instantiate(projectilePrefab, pos, Quaternion.identity) as GameObject;
        // faire en sorte que le localscale de l'objet tiré puisse correspondre à celui du tirant
        clone.transform.localScale = transform.localScale;
    }
    
    // pour déssiiner le guizmo nous permettant de set la position
    private void OnDrawGizmos()
    {
        Gizmos.color = debugColor;
        
        var pos = firePosition;
        // offset la position
        // s'assure que le inputState est != null puisque si on ne lance pas le jeu on n'a pas une reference de l'inputsate
        if (inputState != null)
            pos.x *= (float)inputState.direction;
        pos.x += transform.position.x;
        pos.y += transform.position.y;

        Gizmos.DrawWireSphere(pos, debugRadius);
    }
}
