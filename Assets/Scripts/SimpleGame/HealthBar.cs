using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    [Header("UI References")]
    public Image fillImage;

    [Header("Data References")]
    public HealthSystem healthSystem;

    void Update()
    {
        if (healthSystem != null && fillImage != null)
        {
            UpdateHealthBar();
        }
    }

    void UpdateHealthBar()
    {
        float fillValue = (float)healthSystem.currentHealth / healthSystem.maxHealth;

        fillImage.fillAmount = fillValue;
    }

    void LateUpdate()
    {
        transform.rotation = Quaternion.identity;
    }
}