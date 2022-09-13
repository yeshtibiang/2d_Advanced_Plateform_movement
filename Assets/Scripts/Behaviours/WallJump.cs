using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallJump : AbstractBehaviour
{
    public Vector2 jumpVelocity = new Vector2(50, 200);
    // propriété pour savoir si il est entrain de sauter du mur
    public bool jumpingOffWall;
    public float resetDelay = .2f;

    private float timeElapsed = 0;
    
    // Update is called once per frame
    void Update()
    {
        if (collisionState.onWall && !collisionState.standing)
        {
            var canjump = inputState.GetButtonValue(inputButtons[0]);
            
            // on verifie s'il peut sauter mais également s'il n'est pas entrain de sauter
            if (canjump && !jumpingOffWall)
            {
                // il faut d'abord reverse la direction du joueur
                inputState.direction = inputState.direction == Directions.Right ? Directions.Left : Directions.Right;
                // on peut maintenant appliquer la velocité
                body2d.velocity = new Vector2(jumpVelocity.x * (float)inputState.direction, jumpVelocity.y);
                
                // on va désactiver les scripts qui pourraient poser problème
                ToggleScripts(false);
                jumpingOffWall = true;

            }
        }
        
        // s'il est entrain de sauter on augmente le temps passé depuis le saut
        if (jumpingOffWall)
        {
            timeElapsed += Time.deltaTime;
            // on peut réactiver les scripts après un certain temsp
            if (timeElapsed > resetDelay)
            {
                ToggleScripts(true);
                jumpingOffWall = false;
                timeElapsed = 0;
            }
        }
    }
}
