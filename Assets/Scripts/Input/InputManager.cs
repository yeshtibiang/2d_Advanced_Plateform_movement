using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum Buttons
{
    Right,
    Left,
    Up,
    Down,
    A,
    B
}

public enum Condition
{
    GreaterThan,
    LessThan
}

[System.Serializable]
public class InputAxisState
{
    public string axisName;
    public float offValue;
    public Buttons button;
    public Condition condition;

    public bool value
    {
        get
        {
            // on fait le getAxis de la bonne axe
            var val = Input.GetAxis(axisName);

            switch (condition)
            {
                case Condition.GreaterThan:
                    return val > offValue;
                case Condition.LessThan:
                    return val < offValue;
            }

            return false;
        }
    }

}

public class InputManager : MonoBehaviour
{
    public InputAxisState[] inputs;
    // property to store the inputState
    public InputState inputState;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // on parcourt l'ensemble de nos inputs et debug les inputs
        foreach (var input in inputs)
        {
            // on test le input value si c'est true on retourne le button auquel il est mappé
            // on passe les valeurs directement dans le inputState et on utilise button enum pour 
            // abstraire ce qui se passe en réalité. 
            inputState.SetButtonValue(input.button, input.value);
        }
    }
}
