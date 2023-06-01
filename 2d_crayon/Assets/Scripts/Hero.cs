using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hero : MonoBehaviour
{
    /* логика для прыжка:
     *на Awake вызываем rigidbody
     *Берём компонент layercheck и через метод IsGrounded вызываем IsTouchingLayer в нём
     *Значение возвращаем в IsGrounded
     *В FixedUpdate переписываем Velocity у _rigidbody
     *velocity по икс записываем через умножение _direction на скорость
     *
     *
     *
     */



    [SerializeField] private float _speed = 2f;
    [SerializeField] private float _jumpForce = 2f;
    private Vector2 _direction;
    private Rigidbody2D _rigidbody;
    [SerializeField] LayerCheck _groundCheck;


    private void Awake()
    {
        Debug.Log("Awake from Hero Script");
        _rigidbody = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {
        _rigidbody.velocity = new Vector2(_direction.x * _speed, _rigidbody.velocity.y);
        //движется только по икс
        var isJumping = _direction.y > 0; //считываем нажание вверх


        //Если нажата вверх и мы на земле - то прида>тся сила
        //если не зажата вверх, то прижимаемся к земле сильнее
        if (isJumping)
        {
            if (IsGrounded())
            {
                _rigidbody.velocity = new Vector2(_rigidbody.velocity.x, 0);
                _rigidbody.AddForce(Vector2.up * _jumpForce, ForceMode2D.Impulse);
            }

        }
        else if (_rigidbody.velocity.y > 0)
        {
            _rigidbody.velocity = new Vector2(_rigidbody.velocity.x, _rigidbody.velocity.y * 0.5f);
        }

    }

    private bool IsGrounded()
    {
        return _groundCheck._isTouchingLayer;
    }

    //этот метод вызывается в heroinputreader 
    public void SetDirection(Vector2 direction)
    {
        _direction = direction;
    }

    public void SaySomething()
    {
        Debug.Log("Something");
    }
        



}


/*Обновление каждый кадр. Если нажата клавиша, задающая направление, то выполняется if и персонаж движется
private void Update()
{
    Movement();
}

public void Movement()
{
    if (_direction.magnitude > 0)
    {
        var delta = _direction * _speed * Time.deltaTime;
        transform.position += new Vector3(delta.x, delta.y, transform.position.z);
    }
}*/