using UnityEngine;

public class GameInfo : MonoBehaviour
{
    static GameInfo _instance;
    public static GameInfo Instance
    {
        get
        {
            if (_instance == null)
            {
                _instance = FindObjectOfType<GameInfo>();
                if(_instance == null)
                {
                    Debug.LogError("GameInfo���A�^�b�`���ꂽ�I�u�W�F�N�g�����݂��܂���");
                }
            }
            return _instance;
        }
    }

    [SerializeField]
    private UIData _uIData;
    public UIData UIData => _uIData;

    [SerializeField]
    private MessageUIData _messageUIData;
    public MessageUIData MessageUI => _messageUIData;

    [SerializeField]
    private CharacterData _characterData;
    public CharacterData CharacterData => _characterData;
}
