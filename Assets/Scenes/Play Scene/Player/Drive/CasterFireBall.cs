using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CasterFireBall : MonoBehaviour
{
    public FireBall F;
    public Transform fireballSourceTransform;
    public float damage = 10;
    // Start is called before the first frame update
    void Start()
    {
        
    }

  
    void Update()
    {
        if(Input.GetMouseButtonDown(0))
        {
            var fireball  = Instantiate(F,  fireballSourceTransform.position, fireballSourceTransform.rotation);
            fireball.damage = damage;
        }
    }
    
}
