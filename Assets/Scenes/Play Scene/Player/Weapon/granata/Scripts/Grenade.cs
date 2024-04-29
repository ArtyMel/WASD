using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grenade : MonoBehaviour
{
    public float damage = 100;

    public float delay = 3;
    public GameObject explosionPrefab;
    private void OnCollisionEnter(Collision collision)
    {
        Invoke("Exposion", delay);
    }
    private void Exposion()
    {
        Destroy(gameObject);
        var explosion = Instantiate(explosionPrefab);
        explosion.transform.position = transform.position;
        explosion.GetComponent<Explosion>().damage = damage;
    }
}
