using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireProjectile : AbstractBehaviour
{
    
    // shoot delay
    public float shootDelay = .5f;
    // reference à l'objet que l'on doit tirer
    public GameObject projectilePrefab;
    
    // time passé depuis le premier tir
    private float timeElapsed = 0f;
    

    // Update is called once per frame
    void Update()
    {
        // logique pour tirer le projectile
        // s'assurer de tirer si le projectilePrefab est différent de null
        if (projectilePrefab != null)
        {
            var canFire = inputState.GetButtonValue(inputButtons[0]);
            
            // s'assurer de pouvoir tirer
            if (canFire && timeElapsed > shootDelay)
            {
                CreateProjectile(transform.position);
                timeElapsed = 0;
            }
            // incrementer le timeElapsed
            timeElapsed += Time.deltaTime;
        }
    }

    public void CreateProjectile(Vector2 pos)
    {
        // as GameObject nous permet de cloner en tant que GameObject. 
        var clone = Instantiate(projectilePrefab, pos, Quaternion.identity) as GameObject;
        // faire en sorte que le localscale de l'objet tiré puisse correspondre à celui du tirant
        clone.transform.localScale = transform.localScale;
    }
}
