using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    public float value;

    public PlayerProgress playerProgress;

    public void DealDamage(float damage)
    {
        playerProgress.AddExperience(damage);
        value -= damage;
        playerProgress.AddExperience(damage);
        if (value <= 0)
        {
            Destroy(gameObject);
        }
    }
    private void Start()
    {
        playerProgress = FindObjectOfType<PlayerProgress>();
    }
}
