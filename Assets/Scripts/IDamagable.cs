using UnityEngine;

// 데미지를 받을 때 필요한 인터페이스 작성
// Player, Monster에 모두 사용 가능
public interface IDamagable
{
    void TakePhysicalDamage(int damageAmount);
}
