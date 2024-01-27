using Cysharp.Threading.Tasks;
using UnityEngine;

public class StayCommand : IMoveCommand
{
    [SerializeField]
    private float _stayTime;
    private float _timer;

    public async UniTask MoveObject(GameObject obj, float interval, float speed)
    {
        _timer = 0f;
        while(_timer < _stayTime)
        {
            _timer += Time.deltaTime;
            await UniTask.Delay(1);
        }
    }
}
