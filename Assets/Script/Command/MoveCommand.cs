using Cysharp.Threading.Tasks;
using UnityEngine;

public class MoveCommand : ICommand
{
    [SerializeField]
    private bool _isConCurrent;
    [SerializeField]
    private Character _character = Character.Kohaku;
    [SerializeField]
    private MovePoint _movePoint = MovePoint.Point1;
    [SerializeField, Min(1.0f)]
    private float _moveSpeed = 1.0f;
    [SerializeField]
    private float _interval = 0.5f;

    private Transform _endPos;
    private GameObject _target;
    private GameInfo _gameInfo;

    public bool IsConcurrent => _isConCurrent;

    enum Character
    {
        Kohaku,
        Misaki,
        Yuko,
    }

    enum MovePoint
    {
        Point1,
        Point2,
    }

    public async UniTask Execute()
    {
        _gameInfo = GameInfo.Instance;
        _target = _gameInfo.CharacterData.CharacterArray[(int)_character];
        _endPos = _gameInfo.CharacterData.MovePoint[(int)_movePoint];
        Debug.Log("MoveStart");
        await TargetMove();
        Debug.Log("MoveEnd");
    }

    async UniTask TargetMove()
    {
        float distance = Vector3.Distance(_target.transform.position, _endPos.position);
        while(distance > _interval)
        {
            distance = Vector3.Distance(_target.transform.position, _endPos.position);
            var dir = (_endPos.position - _target.transform.position).normalized;
            _target.transform.Translate(dir);
            await UniTask.Delay(1);
        }
    }
}
