using Cysharp.Threading.Tasks;
using System.Collections.Generic;
using UnityEngine;

public class CommandInvoke : MonoBehaviour
{
    private static Stack<ICommand> undoCommand = new Stack<ICommand>();

    public static async UniTask Invoke(ICommand command)
    {
        //undoCommand.Push(command);
        await command.Execute();
    }
}
