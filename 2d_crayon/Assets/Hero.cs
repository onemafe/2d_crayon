using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hero : MonoBehaviour
{
    [SerializeField] private float _speed = 2f;
    private Vector2 _direction;

    //Обновление каждый кадр. Если нажата клавиша, задающая направление, то выполняется if и персонаж движется
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
    }


    public void SetDirection(Vector2 direction)
    {
        _direction = direction;
    }

    public void SaySomething()
    {
        Debug.Log("Something");
    }
        
    void Awake()
    {
        Debug.Log("Awake from Hero Script");
    }


}
