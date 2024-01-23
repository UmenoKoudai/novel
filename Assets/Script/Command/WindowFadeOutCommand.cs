using Cysharp.Threading.Tasks;
using UnityEngine.UI;
using UnityEngine;

public class WindowFadeOutCommand : ICommand
{
    [SerializeField]
    private bool _isConcurrent;
    [SerializeField]
    private float _changeValue;

    GameInfo _gameInfo;

    public bool IsConcurrent => _isConcurrent;

    public async UniTask Execute()
    {
        _gameInfo = GameInfo.Instance;
        _gameInfo.MessageUI.Text.gameObject.SetActive(false);
        Debug.Log("WindowOutStart");
        await FadeOut();
        Debug.Log("WindowOutEnd");
        _gameInfo.MessageUI.Window.gameObject.SetActive(false);
    }

    async UniTask FadeOut()
    {
        var window = _gameInfo.MessageUI.Window;
        float a = window.color.a;
        while(a > 0)
        {
            a -= _changeValue;
            _gameInfo.MessageUI.Window.color = new Color(window.color.r, window.color.g, window.color.b, a);
            await UniTask.Delay(1);
        }
    }
}