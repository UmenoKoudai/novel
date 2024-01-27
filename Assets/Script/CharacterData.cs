using System;
using UnityEngine;

[Serializable]
public class CharacterData
{
    [SerializeField]
    private GameObject[] _characterArray;
    public GameObject[] CharacterArray => _characterArray;

    [SerializeField]
    private SpriteRenderer[] _faceArray;
    public SpriteRenderer[] FaceArray => _faceArray;
}
