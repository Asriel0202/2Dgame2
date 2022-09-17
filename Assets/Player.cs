using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    // Start is called before the first frame update
    // �X�v���C�g�ԍ���`
    const int SPR_FALL = 0; // ������

    const int SPR_JUMP = 1; // �W�����v��

    [SerializeField]
    float JUMP_VELOCITY = 1000; // �W�����v�͂̒�`

    public Sprite[] SPR_LIST; // �A�j���[�V�����p�X�v���C�g�̕ێ�

    Rigidbody2D _rigidbody; // ���������R���|�[�l���g�ێ��p

    SpriteRenderer _renderer; // �@�X�v���C�g�`��

    // �J�n����
    void Start()
    {

       //  ���������R���|�[�l���g���擾
        _rigidbody = GetComponent<Rigidbody2D>();

       //  �X�v���C�g�`��R���|�[�l���g���擾
        _renderer = GetComponent<SpriteRenderer>();

    }

    // �X�V
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
    �@// Space�L�[���������̂ŃW�����v����
            _rigidbody.velocity = Vector2.zero; // �������x����x���Z�b�g����
            _rigidbody.AddForce(new Vector2(0, JUMP_VELOCITY)); // ������ɗ͂�������
        }

        // �B�v���C���[�̏�ԂŃX�v���C�g��؂�ւ���
        if (_rigidbody.velocity.y < 0)
        {
            // ������
            _renderer.sprite = SPR_LIST[SPR_FALL];
        }
        else
        {
            // �㏸��
            _renderer.sprite = SPR_LIST[SPR_JUMP];
        }
    }


    // �Œ�t���[���X�V
    private void FixedUpdate()
    {
        // ���W���擾
        Vector3 position = transform.position;
        // ��ʊO�ɏo�Ȃ��悤�ɂ���
        float y = transform.position.y;
        float vx = _rigidbody.velocity.x;
        if (y > GetTop())
        {
            _rigidbody.velocity = Vector2.zero; // ���x����x���Z�b�g����
            position.y = GetTop(); // �����߂�����
        }
        if (y < GetBottom())
        {
            // ���ɗ�������I�[�g�W�����v
            _rigidbody.velocity = Vector2.zero; // �������x����x���Z�b�g����
            position.y = GetBottom(); // �����߂�����
        }

        // ���W�𔽉f����
        transform.position = position;
    }

    // ��ʏ���擾����
    float GetTop()
    {
        // ��ʂ̉E��̃��[���h���W���擾����
        Vector2 max = Camera.main.ViewportToWorldPoint(Vector2.one);
        return max.y;
    }

    // ��ʉ����擾����
    float GetBottom()
    {
        // ��ʂ̍����̃��[���h���W���擾����
        Vector2 min = Camera.main.ViewportToWorldPoint(Vector2.zero);
        return min.y;
    }

}
