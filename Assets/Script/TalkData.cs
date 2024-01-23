using System;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName ="Talk", menuName = "Talk")]
public class TalkData : ScriptableObject
{
    [SerializeField]
    List<Data> talkData = new List<Data>();

    public List<Data> Data => talkData;
    public int DataLength => talkData.Count;

    public void Add()
    {
        talkData.Add(new Data());
    }
}

[Serializable]
public class Data
{
    [SerializeField]
    [SerializeReference, SubclassSelector]
    List<ICommand> commands = new List<ICommand>();

    public List<ICommand> Commands => commands;
}
