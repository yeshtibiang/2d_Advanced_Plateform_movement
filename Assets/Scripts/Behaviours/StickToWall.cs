using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StickToWall : AbstractBehaviour
{
    // verifié s'il est sur le mur
    public bool onWallDetected;
    
    // propriétés pour conserver les gravité par défaut et le drag
    protected float defaultGravityScale;
    protected float defaultDrag;
    
    // Start is called before the first frame update
    void Start()
    {
        // obtenir les valeur lorsque le script se lance
        defaultGravityScale = body2d.gravityScale;
        defaultDrag = body2d.drag;
    }

    // Update is called once per frame
    protected virtual void Update()
    {
        // modifions la méthode pour détecter si on est stick au wall ou non
        if (collisionState.onWall)
        {
            // pour éviter des problème de performances s'assurer avant d'appeler Onstick ou offwall on soit dans le bon état avec la propriété onwalldetected
            if (!onWallDetected)
            {
                OnStick();
                ToggleScripts(false);
                onWallDetected = true;
            }
        }
        else
        {
            if (onWallDetected)
            {
                OffWall();
                ToggleScripts(true);
                onWallDetected = false;
            }
        }
    }
    
    // creons deux méthodes une appelé lorsque que nous nous collons au mur et l'autre lorsque l'on quite 
    protected virtual void OnStick()
    {
        // vérifier que le player n'est pas sur le sol et qu'il est en l'air
        if (!collisionState.standing && body2d.velocity.y > 0)
        {
            // pour que le joueur reste fixe
            body2d.gravityScale = 0;
            body2d.drag = 100;
        }
    }

    protected virtual void OffWall()
    {
        // reset les valeurs au défaut
        if (body2d.gravityScale != defaultGravityScale)
        {
            body2d.gravityScale = defaultGravityScale;
            body2d.drag = defaultDrag;
        }
    }
    
}
