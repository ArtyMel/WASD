using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealf : MonoBehaviour
{
    public float value = 300;
    public RectTransform valueRectTransform;
    public GameObject gameOverScreen;
    private float _maxValue;
    public GameObject CastFire;
    public Animator animator;


    void Start()
    {
        _maxValue = value;
        gameOverScreen.SetActive(false);
        CastFire.SetActive(true);
    }
    void Update()
    {

    }
    private void DrawHealthBar()
    {
        valueRectTransform.anchorMax = new Vector2(value / _maxValue, 1);
    }
   
    public void DealDamage(float damage)
    {
        value -= damage;
        if(value <= 0)
        {
            PlayerIsDead();
        }
        DrawHealthBar();
    }
    public void AddHealth(float amoumt)
    {
        value += amoumt;
        value = Mathf.Clamp(value, 0, _maxValue);
        DrawHealthBar();
    }
    private void PlayerIsDead()
    {
        
        gameOverScreen.SetActive(true);
        GetComponent<PlayerController>().enabled = false;
        CastFire.SetActive(false);
        GetComponent<CameraRotation>().enabled = false;
        animator.SetTrigger("death");
    }
}
