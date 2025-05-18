using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Equipment : MonoBehaviour
{
    public Equip curEquip;
    public Transform equipParent;

    private Player player;
    private PlayerController controller;
    private PlayerCondition condition;

    void Start()
    {
        player = CharacterManager.Instance.Player.GetComponent<Player>();
        if (player != null)
        {
            controller = player.controller;
            condition = player.condition;
        }
        else
        {
            Debug.LogError("Player 컴포넌트를 찾을 수 없습니다!");
        }
    }

    public void EquipNew(ItemData data)
    {
        UnEquip();
        if (data.equipPrefab != null)
        {
            curEquip = Instantiate(data.equipPrefab, equipParent).GetComponent<Equip>();
            if (curEquip != null)
            {
                curEquip.OnEquip();
            }
        }
    }

    public void UnEquip()
    {
        if(curEquip != null)
        {
            curEquip.OnUnEquip();
            Destroy(curEquip.gameObject);
            curEquip = null;
        }
    }
}