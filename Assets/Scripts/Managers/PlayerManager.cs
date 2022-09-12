using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    // Nous auraons besoin d'une reference au inputState et le walkBehaviour
    private InputState inputState;

    private Walk walkBehaviour;
    private Animator animator;
    private CollisionState collisionState;
    private Duck duckBehaviour;

    private void Awake()
    {
        inputState = GetComponent<InputState>();
        walkBehaviour = GetComponent<Walk>();
        animator = GetComponent<Animator>();
        collisionState = GetComponent<CollisionState>();
        duckBehaviour = GetComponent<Duck>();
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //ensuite là on effectue le changement
        // on va remplacer la vérification de la valeur absolu de x == 0 par si le joueur est standing
        // car des fois en saut il peut arriver que la valeur de x soit egalement = à 0
        if (collisionState.standing)
        {
            ChangeAnimationState(0);
        }
        if (inputState.absVelX > 0)
        {
            ChangeAnimationState(1);
        }

        if (inputState.absVelY > 0)
        {
            ChangeAnimationState(2);
        }
        // mettre a jour la vitesse de l'animation à travers la vitesse de l'objet
        animator.speed = walkBehaviour.running ? walkBehaviour.runMultiplier : 1;

        if (duckBehaviour.ducking)
        {
            ChangeAnimationState(3);
        }
    }

    void ChangeAnimationState(int value)
    {
        // on met en place un integet appeler animState
        animator.SetInteger("AnimState", value);
    }
}
