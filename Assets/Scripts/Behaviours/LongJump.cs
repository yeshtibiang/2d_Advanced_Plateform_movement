using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LongJump : Jump
{
    public float longJumpDelay = .15f;
    public float longJumpMultiplier = 1.5f;
    public bool canLongJump;
    public bool isLongJumping;
    

    // Update is called once per frame
    // on override la fonction update
    protected override void Update()
    {
        var canJump = inputState.GetButtonValue(inputButtons[0]);
        // variable pour le holdTime
        var holdTime = inputState.GetButtonHoldTime(inputButtons[0]);

        if (!canJump)
            canLongJump = false;
        if (collisionState.standing && isLongJumping)
        {
            isLongJumping = false;
        }
        // s'il n'y a pas de long jump on exécute le jump normal sinon
        // il faut appeler la fonction update 
        base.Update();
        // on veut maintenant vérifier si le bouton a été appuyé pendant un certain
        // de temps. 
        if (canLongJump && !collisionState.standing && holdTime > longJumpDelay)
        {
            // nous allons donc appliquer une plus grande vélocité lorsque l'on bouge le player en haut
            //ref de l'actuel velocité
            var vel = body2d.velocity;
            body2d.velocity = new Vector2(vel.x, jumpSpeed * longJumpMultiplier);
            canLongJump = false;
            isLongJumping = false;
        }
        
    }

    // permet d'override la méthode onJump pour reset le canLongJump
    protected override void OnJump()
    {
        base.OnJump();
        canLongJump = true;
    }
}
