using UnityEngine;

public class LeftMoveCommand : IMoveCommand
{
    [SerializeField]
    private Vector2 _moveDirection;
    async public void MoveObject(GameObject obj)
    {

    }
}
