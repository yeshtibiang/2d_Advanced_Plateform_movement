using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class AbstractBehaviour : MonoBehaviour
{
    // references des boutons
    public Buttons[] inputButtons;
    public MonoBehaviour[] dissableScripts;
    
    // reference au inputState et au rigidbody
    protected InputState inputState;
    protected Rigidbody2D body2d;
    protected CollisionState collisionState;
    
    // pour commencer nous allons utiliser une nouvelle méthode appelé awake
    // mais parce que l'on veut l'étendre après on va faire de cela une méthode virtual protected
    // qui permettent de retenir une méthode monobehaviour on peut le rendre protected virtual
    protected virtual void Awake()
    {
        inputState = GetComponent<InputState>();
        body2d = GetComponent<Rigidbody2D>();
        collisionState = GetComponent<CollisionState>();
    }

    protected virtual void ToggleScripts(bool value)
    {
        foreach (var script in dissableScripts)
        {
            script.enabled = value;
        }
    }
}
