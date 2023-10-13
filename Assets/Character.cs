using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Image))]
public class Character : MonoBehaviour
{
    [SerializeField]
    Sprite[] _characterImages;
    Image _image;

    private void Start()
    {
        _image = GetComponent<Image>();
        _image.sprite = _characterImages[0];
    }
}
