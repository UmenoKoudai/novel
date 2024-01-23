using System;
using UnityEngine;

[Serializable]
public class CharacterData
{
    [SerializeField]
    private GameObject[] _characterArray;
    public GameObject[] CharacterArray => _characterArray;

    [SerializeField]
    private Transform[] _movePoint;
    public Transform[] MovePoint => _movePoint;
}
