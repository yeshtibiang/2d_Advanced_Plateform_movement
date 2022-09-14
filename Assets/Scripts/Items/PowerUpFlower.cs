using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUpFlower : Collectable
{
    public int itemID = 1;
    // reference du projectile
    // donc on associe un projectile précise a notre fleur.
    public GameObject projectilePrefab;
    
    // on va override la classe OnCollect
    override protected void OnCollect(GameObject target)
    {
        // equipbehaviour du target
        var equipBehaviour = target.GetComponent<Equip>();
        if (equipBehaviour != null)
        {
            Debug.Log("item quipped " + itemID);
            equipBehaviour.currentItem = itemID;
        }
        
        // reference au script FireProjectile
        var shootBehaviour = target.GetComponent<FireProjectile>();
        if (shootBehaviour != null)
        {
            // si le FireProjectile n'est pas null
            // on set le projectile prefab de ce dernier a celui de notre propre class
            shootBehaviour.projectilePrefab = projectilePrefab;
        }
    }
    
}
