using UnityEngine;

// 개별 Condition 바의 조합으로 이루어진 UICondition
public class UICondition : MonoBehaviour
{
    public Condition health;
    public Condition hunger;
    public Condition stamina;

    private void Start()
    {
        if (CharacterManager.Instance != null && CharacterManager.Instance.Player != null)
        {
            CharacterManager.Instance.Player.uiCondition = this;
        }
        else
        {
            Debug.LogError("CharacterManager 또는 Player가 설정되지 않았습니다!");
        }
    }
}