using Cysharp.Threading.Tasks;
using UnityEngine;

public class FadeInCommand : ICommand
{
    [SerializeField]
    private bool _isConcurrent;
    [SerializeField]
    private float _changeValue;

    public bool IsConcurrent => _isConcurrent;

    private GameInfo _gameInfo;

    public async UniTask Execute()
    {
        _gameInfo = GameInfo.Instance;
        Debug.Log("FadeInStart");
        await FadeIn();
        Debug.Log("FadeInEnd");

    }

    async UniTask FadeIn()
    {
        var fadeBoard = _gameInfo.UIData.Fade;
        float a = fadeBoard.color.a;
        while(a > 0)
        {
            a -= _changeValue;
            _gameInfo.UIData.Fade.color = new Color(fadeBoard.color.r, fadeBoard.color.g, fadeBoard.color.b, a);
            await UniTask.Delay(1);
        }
    }
}
