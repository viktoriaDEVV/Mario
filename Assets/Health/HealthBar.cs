using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    [SerializeField] private Health playerHalth;
    [SerializeField] private Image totalHeaalthBar;
    [SerializeField] private Image currentHeaalthBar;

    void Start()
    {
        totalHeaalthBar.fillAmount = playerHalth.currentHealth / 10;
    }

    // Update is called once per frame
    void Update()
    {
        currentHeaalthBar.fillAmount = playerHalth.currentHealth / 10; 
    }
}
