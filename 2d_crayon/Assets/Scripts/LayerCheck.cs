using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LayerCheck : MonoBehaviour
{
    /* компонент, который проверяет пересекаем ли мы слой. на выходе получаем bool
     
    вводные bool _isTouchingLayer
    _collider забираем на awake
    _layer Layermask

    Тут создаём методы для назначения этого самого bool
    */

    [SerializeField] private LayerMask _layer;
    private Collider2D _collider;

    public bool _isTouchingLayer;

    private void Awake()
    {
        _collider = GetComponent<Collider2D>();
    }

    // Я не очень понимаю что тут в скобках
    private void OnTriggerStay2D(Collider2D collision)
    {
        _isTouchingLayer = _collider.IsTouchingLayers(_layer);
    }


    private void OnTriggerExit2D(Collider2D collision)
    {
        _isTouchingLayer = _collider.IsTouchingLayers(_layer);
    }
}
