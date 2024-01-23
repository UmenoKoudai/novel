using System;
using UnityEngine;
using UnityEngine.UI;

[Serializable]
public class MessageUIData
{
    [SerializeField]
    private Image _messageWindow;
    public Image Window
    {
        get => _messageWindow;
        set => _messageWindow = value;
    }

    [SerializeField]
    private Text _messageText;
    public Text Text
    {
        get => _messageText;
        set => _messageText = value;
    }
}
