using Cysharp.Threading.Tasks;
using UnityEngine;

public class SpriteSwapCommand : ICommand
{
    [SerializeField]
    private bool _isConcurrent;
    [SerializeField]
    private Sprite _changeSprite;
    public bool IsConcurrent => _isConcurrent;

    private GameInfo _gameInfo;

    public async UniTask Execute()
    {
        _gameInfo = GameInfo.Instance;
        await Swap();
    }

    async UniTask Swap()
    {
        _gameInfo.UIData.BackGround.sprite = _changeSprite;
    }
}
