using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrenadeCaster : MonoBehaviour
{
    public float damage = 100;
    public Rigidbody grenadePrefab;
    public Transform grenadeSourceTransform;
    public float force = 10;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
       if(Input.GetKeyDown(KeyCode.G))
        {
            var grenade = Instantiate(grenadePrefab);
            grenade.transform.position = grenadeSourceTransform.position;
            grenade.GetComponent<Rigidbody>().AddForce(grenadeSourceTransform.forward * force);
            grenade.GetComponent<Grenade>().damage = damage;
        }
    }
}
