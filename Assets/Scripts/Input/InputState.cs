using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonState
{
    // on veut avoir un boolean qui dit si le bouton est appuyé ou non
    public bool value;
    // float for the HoldTime
    public float holdTime = 0;
}

public enum Directions
{
    Right = 1,
    Left = -1
}

public class InputState : MonoBehaviour
{
    // créons notre dictionnaire
    public Directions direction = Directions.Right;
    public float absVelX = 0f;
    public float absVelY = 0f;

    private Rigidbody2D body2d;
    private Dictionary<Buttons, ButtonState> buttonStates = new Dictionary<Buttons, ButtonState>();

    void Awake()
    {
        body2d = GetComponent<Rigidbody2D>();
    }

    void FixedUpdate()
    {
        // on n'a pas besoin de savoir si le body bouge à gauche ou droite on a juste besoin de savoir s'il y'a un mouvement. 
        absVelX = Mathf.Abs(body2d.velocity.x);
        absVelY = Mathf.Abs(body2d.velocity.y);
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SetButtonValue(Buttons key, bool value)
    {
        // assurons que la clé existe si non ajoutons la et créons un nouveau buttonState() qui va avec
        if (!buttonStates.ContainsKey(key))
        {
            buttonStates.Add(key, new ButtonState());
        }
        // set the value of the state
        // we need to get a reference to it from the dictionnary
        var state = buttonStates[key];
        
        // pour verifier si le bouton est relaché ou toujours appuyé
        if (state.value && !value) // si le state est true et la valeur arrive est false 
        {
            // le bouton est released
            //Debug.Log("Button " + key + " released " + state.holdTime);
            state.holdTime = 0;
        }
        else if (state.value && value)
        {
            // on augment le holdTime par le Time delta qui reprente le nombre de milliseconde d'une frame à un autre.
            state.holdTime += Time.deltaTime;
            // le button est down
            //Debug.Log("Button " + key + " Down" + state.holdTime);
        }
        
        state.value = value;
    
    }
    
    // get the value of the button
    public bool GetButtonValue(Buttons key)
    {
        // on verifie si le buttonstate contient la valeur
        if (buttonStates.ContainsKey(key))
            return buttonStates[key].value;
        else
        {
            return false;
        }
    }
    
    // obtenir le temps d'appui d'un bouton
    public float GetButtonHoldTime(Buttons key)
    {
        // on verifie si le buttonstate contient la valeur
        if (buttonStates.ContainsKey(key))
            return buttonStates[key].holdTime;
        else
        {
            return 0;
        }
    }
}
