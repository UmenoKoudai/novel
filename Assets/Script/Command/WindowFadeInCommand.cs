using Cysharp.Threading.Tasks;
using UnityEngine;
using UnityEngine.UI;

public class WindowFadeInCommand : ICommand
{
    [SerializeField]
    private bool _isConcurrent;
    [SerializeField]
    private float _changeValue;

    private GameInfo _gameInfo;

    public bool IsConcurrent => _isConcurrent;

    public async UniTask Execute()
    {
        _gameInfo = GameInfo.Instance;
        _gameInfo.MessageUI.Window.gameObject.SetActive(true);
        Debug.Log("windowInStart");
        await FadeIn();
        Debug.Log("windowInEnd");
    }

    async UniTask FadeIn()
    {
        var window = _gameInfo.MessageUI.Window;
        float a = window.color.a;
        while (a < 1)
        {
            a += _changeValue;
            _gameInfo.MessageUI.Window.color = new Color(window.color.r, window.color.g, window.color.b, a);
            await UniTask.Delay(1);
        }
    }
}
