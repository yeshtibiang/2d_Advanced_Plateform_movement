using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Equip : AbstractBehaviour
{
    // on aura besoin de l'id de l'équipement équiper
    private int _currentItem = 0;

    private Animator animator;
    
    // get et setter 
    public int currentItem
    {
        get { return _currentItem; }
        set
        {
            _currentItem = value;
            // on veut dire à notre animator quel item a été équipé
            animator.SetInteger("EquippedItem", _currentItem);
        }
    }
    
    // override the awake pour pouvoir avoir accès à l'animator
    override protected void Awake()
    {
        base.Awake();
        animator = GetComponent<Animator>();
    }
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
