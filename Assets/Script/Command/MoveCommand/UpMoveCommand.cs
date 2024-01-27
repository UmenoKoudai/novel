using Cysharp.Threading.Tasks;
using UnityEngine;

public class UpMoveCommand : IMoveCommand
{
    [SerializeField]
    private Vector3 _moveDirection;

    [SerializeField]
    private float _moveSpeed;

    public async UniTask MoveObject(GameObject obj, float interval, float speed)
    {
        var destinationPoint = obj.transform.position + _moveDirection;
        var distance = Vector3.Distance(destinationPoint, obj.transform.position);
        while(distance > interval)
        {
            distance = Vector3.Distance(destinationPoint, obj.transform.position);
            obj.transform.position += new Vector3(0, _moveSpeed, 0);
            await UniTask.Delay(1);
        }
    }
}
