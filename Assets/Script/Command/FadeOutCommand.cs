using Cysharp.Threading.Tasks;
using UnityEngine;

public class FadeOutCommand : ICommand
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
        Debug.Log("FadeOutStart");
        await FadeIn();
        Debug.Log("FadeOutEnd");

    }

    async UniTask FadeIn()
    {
        var fadeBoard = _gameInfo.UIData.Fade;
        float a = fadeBoard.color.a;
        while (a < 1)
        {
            a += _changeValue;
            fadeBoard.color = new Color(fadeBoard.color.r, fadeBoard.color.g, fadeBoard.color.b, a);
            await UniTask.Delay(1);
        }
    }
}
