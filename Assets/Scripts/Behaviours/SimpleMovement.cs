using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimpleMovement : MonoBehaviour
{
    public float speed = 5f;
    public Buttons[] input;
    
    private Rigidbody2D body2d;
    private InputState inputState;
    
    // Start is called before the first frame update
    void Start()
    {
        body2d = GetComponent<Rigidbody2D>();
        inputState = GetComponent<InputState>();
    }

    // Update is called once per frame
    void Update()
    {
        // test si right and left keys sont pressé
        // on fait cela en créant une variable pour right et en obtenant la première valeur que l'on a mappé
        var right = inputState.GetButtonValue(input[0]);
        var left = inputState.GetButtonValue(input[1]);
        var velX = speed;

        if (right || left)
        {
            velX *= left ? -1 : 1;
        }
        else
        {
            velX = 0;
        }
        // on bouge le personnage
        body2d.velocity = new Vector2(velX, body2d.velocity.y);
    }
}
