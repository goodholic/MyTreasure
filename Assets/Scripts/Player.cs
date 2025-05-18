using System;
using UnityEngine;

public class Player : MonoBehaviour
{
    public PlayerController controller;
    public PlayerCondition condition;
    
    // 아이템 시스템 관련
    private ItemData itemData;
    public event Action addItem;
    
    // 인벤토리 시스템 관련
    public event Action inventory;
    public Transform dropPosition;
    
    private void Awake()
    {
        controller = GetComponent<PlayerController>();
        condition = GetComponent<PlayerCondition>();
        
        if (CharacterManager.Instance != null)
        {
            CharacterManager.Instance.Player = condition;
        }
    }
    
    private void Start()
    {
        // 아이템 획득 시 이벤트 등록
        addItem += OnItemAdded;
        
        // 드롭 위치 설정 (기본적으로 플레이어의 위치)
        if (dropPosition == null)
        {
            dropPosition = transform;
        }
    }
    
    // 외부에서 아이템을 추가할 때 사용하는 메서드
    public void AddItem(ItemData newItem)
    {
        itemData = newItem;
        if (addItem != null)
        {
            addItem();
        }
    }
    
    // 인벤토리 토글 메서드
    public void ToggleInventory()
    {
        if (inventory != null)
        {
            inventory();
        }
    }
    
    // ItemData getter 추가
    public ItemData GetItemData()
    {
        return itemData;
    }
    
    // ItemData setter 추가
    public void SetItemData(ItemData data)
    {
        itemData = data;
    }
    
    private void OnItemAdded()
    {
        // 아이템 획득 시 처리 로직
        Debug.Log($"아이템 획득: {itemData.displayName}");
        
        // 아이템 효과 적용
        if (itemData.healthEffect != 0)
        {
            condition.Heal(itemData.healthEffect);
        }
        
        if (itemData.hungerEffect != 0)
        {
            condition.Eat(itemData.hungerEffect);
        }
    }
}
