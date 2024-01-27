using Cysharp.Threading.Tasks;
using UnityEngine;

public class CommandInputter : MonoBehaviour
{
    [SerializeField]
    private TalkData _data;

    private int _index = 0;

    private async void Start()
    {
        await Next();
    }

    async UniTask Next()
    {
        bool isEndCoroutine = true;
        while (true)
        {
            if (Input.GetButtonDown("Fire1") && isEndCoroutine)
            {
                if (_index >= _data.Data.Count || _index < 0) break;
                isEndCoroutine = false;
                var command = _data.Data[_index].Commands;
                for (int i = 0; i < command.Count;)
                {
                    while (command[i].IsConcurrent)
                    {
                        CommandInvoke.Invoke(command[i]).Forget();
                        i++;
                    }
                    await CommandInvoke.Invoke(command[i]);
                    i++;
                }
                _index++;
                isEndCoroutine = true;
            }
            await UniTask.Delay(1);
        }
    }
}
