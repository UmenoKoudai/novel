using Cysharp.Threading.Tasks;
using UnityEngine;

public class CharacterFaceChangeCommand : ICommand
{
    [SerializeField]
    private bool _isConcurrent;
    [SerializeField]
    private Character _character;
    [SerializeField]
    private Sprite _sprite;

    private GameInfo _gameInfo;

    public bool IsConcurrent => _isConcurrent;

    enum Character
    {
        Kohaku,
        Misaki,
        Yuko,
    }

    public async UniTask Execute()
    {
        _gameInfo = GameInfo.Instance;
        await Swap();
    }

    async UniTask Swap()
    {
        _gameInfo.CharacterData.FaceArray[(int)_character].sprite = _sprite;
    }
}
