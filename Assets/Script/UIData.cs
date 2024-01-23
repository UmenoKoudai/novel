using System;
using UnityEngine;
using UnityEngine.UI;

[Serializable]
public class UIData
{
    [SerializeField]
    private SpriteRenderer _backGround;
    public SpriteRenderer BackGround
    {
        get => _backGround;
        set => _backGround = value;
    }

    [SerializeField]
    private Image _fade;
    public Image Fade
    {
        get => _fade;
        set => _fade = value;
    }
}
