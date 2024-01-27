using Cysharp.Threading.Tasks;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterOutCommand : ICommand
{
    [SerializeField]
    private bool _isConcurrent;
    public bool IsConcurrent => _isConcurrent;

    [SerializeField]
    private Character _characterTarget;

    [SerializeField]
    private float _changeValue;

    private GameInfo _gameInfo;
    private SpriteRenderer _target;
    private SpriteRenderer _targetFace;

    enum Character
    {
        Kohaku,
        Misaki,
        Yuko,
    }

    public async UniTask Execute()
    {
        _gameInfo = GameInfo.Instance;
        _target = _gameInfo.CharacterData.CharacterArray[(int)_characterTarget].GetComponent<SpriteRenderer>();
        _targetFace = _gameInfo.CharacterData.FaceArray[(int)_characterTarget];
        Debug.Log("CharaOutStart");
        await TargetOut();
        Debug.Log("CharaOutEnd");
    }

    async UniTask TargetOut()
    {
        var a = _target.color.a;
        while (a > 0)
        {
            a -= _changeValue;
            _target.color = new Color(_target.color.r, _target.color.g, _target.color.b, a);
            _targetFace.color = new Color(_targetFace.color.r, _targetFace.color.g, _targetFace.color.b, a);
            await UniTask.Delay(1);
        }
    }
}
