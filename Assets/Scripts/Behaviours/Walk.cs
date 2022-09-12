using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Walk : AbstractBehaviour
{
    public float speed = 50f;
    // le run multiplier
    public float runMultiplier = 2f;

    public bool running;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // remettre a zero a chaque frame
        running = false;
        var right = inputState.GetButtonValue(inputButtons[0]);
        var left = inputState.GetButtonValue(inputButtons[1]);
        var run = inputState.GetButtonValue(inputButtons[2]);
        

        if (right || left)
        {
            var tmpSpeed = speed;
            
            // vant de calculer le velX on va recalculer le tmpSpeed
            // il faut aussi vérifier que le run multiplier est supérieur à zero car il pourrait
            //exister des scenario ou on ne veut pas que le joeur cours come lorsqu'il est bloqué
            if (run && runMultiplier > 0)
            {
                tmpSpeed *= runMultiplier;
                running = true;
            }
            
            //penser a convertir la direction qu'on obtient des enums en float
            var velX = tmpSpeed * (float)inputState.direction;
            // on applique le velocityx à notre gameobject le player
            body2d.velocity = new Vector2(velX, body2d.velocity.y);
        }
        
    }
}
