using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PlayerProgress : MonoBehaviour
{
    public RectTransform experienceValueRectTransform;
    public TextMeshProUGUI levelValueTMP;
    public List<PlayerProgressLevel> levels;

    private float _experienceCurrentValue = 0;
    private float _experienceTargetValue = 100;
    private int _levelValue = 1;


    private void Start()
    {
        DrawnUI();
        SetLevel(_levelValue);
    }


    public void AddExperience(float value)
    {
        _experienceCurrentValue += value;
        if(_experienceCurrentValue >= _experienceTargetValue)
        {
            SetLevel(_levelValue + 1);
            _experienceCurrentValue = 0;
        }
        DrawnUI();
    }
    private void DrawnUI()
    {
        experienceValueRectTransform.anchorMax = new Vector2(_experienceCurrentValue / _experienceTargetValue, 1);
        levelValueTMP.text = _levelValue.ToString();
    }
    private void SetLevel(int value)
    {
        _levelValue = value;

        var currentLevel = levels[_levelValue - 1];
        _experienceTargetValue = currentLevel.exprerienceForTheNextLevel;
        GetComponent<CasterFireBall>().damage = currentLevel.fireballDamage;
        GetComponent<GrenadeCaster>().damage = currentLevel.grenadeDamage;

        var grendeCaster = GetComponent<GrenadeCaster>();
        grendeCaster.damage = currentLevel.grenadeDamage;
        if (currentLevel.grenadeDamage < 0)

            grendeCaster.enabled = false;

        else
            grendeCaster.enabled = true;
    }
}
