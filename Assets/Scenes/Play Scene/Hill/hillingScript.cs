using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class hillingScript : MonoBehaviour
{
    public float HealAmount = 50;
    private void OnTriggerEnter(Collider other)
    {
        
        var playerHealth = other.gameObject.GetComponent<PlayerHealf>();
        if(playerHealth != null)
        {
            playerHealth.AddHealth(HealAmount);
            Destroy(gameObject);
        }
    }
    
}
