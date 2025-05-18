using UnityEngine;
using UnityEngine.UI;

public class Condition : MonoBehaviour
{
    public Slider slider;
    public float maxValue = 100f;
    public float currentValue = 100f;
    public float passiveValue = 0f; // 매 프레임마다 자동으로 적용될 값 (양수: 증가, 음수: 감소)

    // 외부에서 현재 값에 접근하기 위한 프로퍼티
    public float curValue 
    { 
        get { return currentValue; } 
        set { SetValue(value); }
    }

    public void Initialize(float startValue)
    {
        currentValue = startValue;
        UpdateUI();
    }

    public void ChangeValue(float amount)
    {
        currentValue += amount;
        currentValue = Mathf.Clamp(currentValue, 0f, maxValue);
        UpdateUI();
    }

    public void Add(float amount)
    {
        ChangeValue(amount);
    }

    public void Subtract(float amount)
    {
        ChangeValue(-amount);
    }

    public void SetValue(float value)
    {
        currentValue = Mathf.Clamp(value, 0f, maxValue);
        UpdateUI();
    }

    private void UpdateUI()
    {
        if (slider != null)
        {
            slider.value = currentValue / maxValue;
        }
    }
}
