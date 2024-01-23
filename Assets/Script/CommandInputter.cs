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
                if (_index >= _data.Data.Count || _index < 0) continue;
                isEndCoroutine = false;
                var command = _data.Data[_index].Commands;
                for (int i = 0; i < command.Count; i++)
                {
                    if (command[i].IsConcurrent)
                    {
                        while (command[i].IsConcurrent)
                        {
                            CommandInvoke.Invoke(command[i]);
                            i++;
                        }
                    }
                    else
                    {
                        await CommandInvoke.Invoke(command[i]);
                    }
                }
                _index++;
                isEndCoroutine = true;
            }
            await UniTask.Delay(1);
        }
    }
}
