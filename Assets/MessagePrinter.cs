
using TMPro;
using UnityEngine;

public class MessagePrinter : MonoBehaviour
{
    [SerializeField]
    private TMP_Text _textUi = default;

    [SerializeField]
    private string _message = "";

    [SerializeField]
    private float _speed = 1.0F;

    private float _elapsed = 0; // ������\�����Ă���̌o�ߎ���
    private float _interval; // �������̑҂�����

    // _message �t�B�[���h����\�����錻�݂̕����C���f�b�N�X�B
    // �����w���Ă��Ȃ��ꍇ�� -1 �Ƃ���B
    private int _currentIndex = -1;

    /// <summary>
    /// �����o�͒����ǂ����B
    /// </summary>
    public bool IsPrinting
    {
        get
        {
            // TODO: �����ɃR�[�h������
            return _currentIndex + 1 < _message.Length;
        }
    }

    private void Start()
    {
        ShowMessage(_message);
        _interval = _speed / _message.Length;
    }

    private void Update()
    {
        if (_textUi is null || _message is null || _currentIndex + 1 >= _message.Length) { return; }

        _elapsed += Time.deltaTime;
        if (_elapsed > _interval)
        {
            float a= 0;
            _elapsed = 0;
            _currentIndex++;
            _textUi.text += _message[_currentIndex];
        }
    }

    /// <summary>
    /// �w��̃��b�Z�[�W��\������B
    /// </summary>
    /// <param name="message">�e�L�X�g�Ƃ��ĕ\�����郁�b�Z�[�W�B</param>
    public void ShowMessage(string message)
    {
        // TODO: �����ɃR�[�h������
        _textUi.text = "";
        _message = message;
        _currentIndex = -1;
    }

    /// <summary>
    /// ���ݍĐ����̕����o�͂��ȗ�����B
    /// </summary>
    public void Skip()
    {
        // TODO: �����ɃR�[�h������
        _textUi.text = _message;
        _currentIndex = _message.Length - 1;
    }
}