using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jump : AbstractBehaviour
{
    // la vitesse du jump
    public float jumpSpeed = 200f;
    // for the double jump
    public float jumpDelay = .1f;
    public int jumpCount = 2;
    public GameObject dustEffectPrefab;

    protected float lastJumpTime = 0;
    protected int jumpsRemaining = 0;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    protected virtual void Update()
    {
        var canJump = inputState.GetButtonValue(inputButtons[0]);
        // variable pour le holdTime
        var holdTime = inputState.GetButtonHoldTime(inputButtons[0]);
        if (collisionState.standing)
        {
            // on va s'assurer que le holdTime est < .1f
            // on met à .1f car il y'a un petit temps de l'appui du button et la detection
            if (canJump && holdTime < .1f)
            {
                // on donne le remaining time
                jumpsRemaining = jumpCount - 1;
                OnJump();
            }
        }
        else
        {
            // dans le cas ou le joeur n'est pas sur le sol
            // s'assurer que le Time.time - lastJumpTime > jumpDelay
            if (canJump && holdTime < .1f && Time.time - lastJumpTime > jumpDelay)
            {
                // on donne le remaining time
                // on verifie si le jumpsRemaining > 0
                if (jumpsRemaining > 0)
                {
                    OnJump();
                    jumpsRemaining--;
                    // instantiation du prefab
                    var clone = Instantiate(dustEffectPrefab);
                    // s'assure que la position du clone soit celui du joueur 
                    clone.transform.position = transform.position;
                }

            }
        }
        
    }

    protected virtual void OnJump()
    {
        var vel = body2d.velocity;
        // double jump: dernièrement il faut tracker le last time jump
        lastJumpTime = Time.time;
        // on va maintenir la velocité x et changer la velocité y
        body2d.velocity = new Vector2(vel.x, jumpSpeed);
    }
}
