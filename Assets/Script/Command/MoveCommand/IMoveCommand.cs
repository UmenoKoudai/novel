using Cysharp.Threading.Tasks;
using UnityEngine;

public interface IMoveCommand
{
    public abstract UniTask MoveObject(GameObject obj, float interval, float speed);
}