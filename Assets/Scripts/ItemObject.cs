using UnityEngine;

// 인터랙션 가능한 객체에 상속할 인터페이스
public interface IInteractable
{
    public string GetInteractPrompt();  // UI에 표시할 정보
    public void OnInteract();           // 인터랙션 호출
}

public class ItemObject : MonoBehaviour, IInteractable
{
    public ItemData data;

    public string GetInteractPrompt()
    {
        string str = $"{data.displayName}\n{data.description}";
        return str;
    }

    public void OnInteract()
    {
        // Player 클래스에 아이템 데이터 전달
        Player player = CharacterManager.Instance.Player.GetComponent<Player>();
        if (player != null)
        {
            player.AddItem(data);
            Destroy(gameObject);
        }
        else
        {
            Debug.LogError("Player 컴포넌트를 찾을 수 없습니다!");
        }
    }
}