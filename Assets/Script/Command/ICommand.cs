using Cysharp.Threading.Tasks;

public interface ICommand
{
    public bool IsConcurrent { get;}
    public abstract UniTask Execute();
}
