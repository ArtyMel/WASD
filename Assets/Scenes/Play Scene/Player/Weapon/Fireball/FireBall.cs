using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FireBall : MonoBehaviour
{
    public float speed;

    public float lifeTime;

    public float damage = 10;


    void Start()
    {
        Invoke("DestroyFireball", lifeTime);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        transform.position += transform.forward * speed * Time.fixedDeltaTime;
    }

    private void OnCollisionEnter(Collision collsion)
    {
        DestroyFireball();
        DamageEnemy(collsion);

        
    }

    private void DamageEnemy(Collision collsion)
    {
        var enemyHealth = collsion.gameObject.GetComponent<EnemyHealth>();
        if (enemyHealth.value != 0)
        {
            enemyHealth.value -= damage;
        }
        enemyHealth.DealDamage(damage);
    }
  

    public void DestroyFireball()
    {
        Destroy(gameObject);
    }
}
