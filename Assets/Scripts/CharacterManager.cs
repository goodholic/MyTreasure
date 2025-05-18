using UnityEngine;

// 캐릭터 관리를 위한 싱글톤 매니저
public class CharacterManager : MonoBehaviour
{
    public static CharacterManager Instance { get; private set; }

    public GameObject playerObject;
    
    private PlayerCondition _player;
    public PlayerCondition Player 
    { 
        get { return _player; }
        set { _player = value; } 
    }

    private void Awake()
    {
        // 싱글톤 설정
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
            return;
        }

        // 플레이어 컴포넌트 가져오기
        if (playerObject != null)
        {
            _player = playerObject.GetComponent<PlayerCondition>();
            if (_player == null)
            {
                _player = playerObject.AddComponent<PlayerCondition>();
            }
        }
        else
        {
            Debug.LogError("플레이어 오브젝트가 할당되지 않았습니다!");
        }
    }
}