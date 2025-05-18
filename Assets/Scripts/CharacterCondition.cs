using UnityEngine;

// 캐릭터의 컨디션을 관리하는 클래스
public class CharacterCondition : MonoBehaviour
{
    public float maxHealth = 100f;
    public float maxHunger = 100f;
    public float maxStamina = 100f;

    public float currentHealth;
    public float currentHunger;
    public float currentStamina;

    [HideInInspector]
    public UICondition uiCondition;

    private void Awake()
    {
        // 초기값 설정
        currentHealth = maxHealth;
        currentHunger = maxHunger;
        currentStamina = maxStamina;
    }

    public void UpdateUI()
    {
        if (uiCondition != null)
        {
            if (uiCondition.health != null)
                uiCondition.health.SetValue(currentHealth);
            
            if (uiCondition.hunger != null)
                uiCondition.hunger.SetValue(currentHunger);
            
            if (uiCondition.stamina != null)
                uiCondition.stamina.SetValue(currentStamina);
        }
    }

    // 체력 변경
    public void ChangeHealth(float amount)
    {
        currentHealth += amount;
        currentHealth = Mathf.Clamp(currentHealth, 0f, maxHealth);
        UpdateUI();
    }

    // 허기 변경
    public void ChangeHunger(float amount)
    {
        currentHunger += amount;
        currentHunger = Mathf.Clamp(currentHunger, 0f, maxHunger);
        UpdateUI();
    }

    // 스태미나 변경
    public void ChangeStamina(float amount)
    {
        currentStamina += amount;
        currentStamina = Mathf.Clamp(currentStamina, 0f, maxStamina);
        UpdateUI();
    }
} 