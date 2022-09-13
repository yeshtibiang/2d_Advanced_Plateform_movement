using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallSlide : StickToWall
{
    // la quantité de velocité qu'on applique au joueur quand il descend
    public float slideVelocity = -5f;
    public float slideMultiplier = 7f;
    public GameObject dustPrefab;
    // delai pour l'affichage de chaque animation de dust
    public float dustSpawnDelay = .5f;
    
    // time from the last dust spawn
    private float timeElapsed = 0f;

    // Update is called once per frame
    override protected void Update()
    {
        base.Update();
        // verifier si on est sur le mur
        if (onWallDetected && !collisionState.standing)
        {
            var velY = slideVelocity;
            
            // si on appuie le down key on va ajouter le multiplier a la velocité
            if (inputState.GetButtonValue(inputButtons[0]))
            {
                velY *= slideMultiplier;
            }
            body2d.velocity = new Vector2(body2d.velocity.x, velY);

            if (timeElapsed > dustSpawnDelay)
            {
                // instanciate the prefab
                var dust = Instantiate(dustPrefab);
                // on veut spawn le truc là où est le joueur
                var pos = transform.position;
                pos.y += 2;
                // reappliquer la positioin au dust instance
                dust.transform.position = pos;
                // s'assurer que le dust ait le meme localScale que le player
                dust.transform.localScale = transform.localScale;
                // reset le temps elapsed
                timeElapsed = 0;
            }

            timeElapsed += Time.deltaTime;

        }
        
    }
    
    // assurons de désactiver les manipulations concernant la gravité 
    // que nous avons dans la classe precedente.
    override protected void OnStick()
    {
        // nous permettre de ralentir le joueur mettre la velocité à 0 
        body2d.velocity = Vector2.zero;
    }

    override protected void OffWall()
    {
        // on ne fait rien et cela va désactiver toute la logique dans la classe enfant
        timeElapsed = 0;
    }
}
