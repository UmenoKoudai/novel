using Cysharp.Threading.Tasks;
using System;
using UnityEngine;

[Serializable]
public class PrintCommand : ICommand
{
    [SerializeField]
    bool _isConcurrent;
    [SerializeField]
    float _messageSpeed = 1f;
    [SerializeField]
    string _message = "";

    GameInfo _gameInfo;

    public bool IsConcurrent => _isConcurrent;

    public async UniTask Execute()
    {
        _gameInfo = GameInfo.Instance;
        Debug.Log("PrintStart");
        await ShowMassage();
        Debug.Log("PrintEnd");
    }

    async UniTask ShowMassage()
    {
        _gameInfo.MessageUI.Text.text = "";
        float timer = 0f;
        float interval = _messageSpeed / _message.Length;
        int _index = 0;

        while (_index < _message.Length)
        {
            timer += Time.deltaTime;
            if (interval < timer)
            {
                timer = 0;
                _gameInfo.MessageUI.Text.text += _message[_index++];
            }
            await UniTask.Delay(1);
        }
    }
}
