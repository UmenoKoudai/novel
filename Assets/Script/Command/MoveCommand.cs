using Cysharp.Threading.Tasks;
using System.Collections.Generic;
using UnityEngine;

public class MoveCommand : ICommand
{
    [SerializeField]
    private bool _isConCurrent;
    [SerializeField]
    private Character _character = Character.Kohaku;
    [SerializeField, Min(1.0f)]
    private float _moveSpeed = 1.0f;
    [SerializeField]
    private float _interval = 0.5f;
    [SerializeField]
    [SerializeReference, SubclassSelector]
    private List<IMoveCommand> _moveCommand;

    private GameObject _target;
    private GameInfo _gameInfo;

    public bool IsConcurrent => _isConCurrent;

    enum Character
    {
        Kohaku,
        Misaki,
        Yuko,
    }

    public async UniTask Execute()
    {
        _gameInfo = GameInfo.Instance;
        _target = _gameInfo.CharacterData.CharacterArray[(int)_character];
        Debug.Log("MoveStart");
        await TargetMove();
        Debug.Log("MoveEnd");
    }

    async UniTask TargetMove()
    {
        foreach(var command in _moveCommand)
        {
            await command.MoveObject(_target, _interval, _moveSpeed);
        }
    }
}
