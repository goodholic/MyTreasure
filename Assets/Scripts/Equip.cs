using UnityEngine;

// 장비 아이템의 기본 클래스
public class Equip : MonoBehaviour
{
    [Header("장비 정보")]
    public string equipName;
    public float useStamina; // 사용 시 소모되는 스태미나

    [Header("애니메이션")]
    public string equipAnim; // 장착 애니메이션
    public string useAnim;  // 사용 애니메이션
    
    // 장비 사용 관련 가상 메서드
    public virtual void OnUse()
    {
        // 기본 구현, 상속 클래스에서 오버라이드 가능
    }
    
    public virtual void OnEquip()
    {
        // 장착 시 호출
    }
    
    public virtual void OnUnEquip()
    {
        // 장착 해제 시 호출
    }
} 