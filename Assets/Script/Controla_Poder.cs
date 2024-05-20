using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using Unity.VisualScripting;
using UnityEngine;
using Vector2 = UnityEngine.Vector2;
using Vector3 = UnityEngine.Vector3;


public class Controla_Poder : MonoBehaviour
{

  
  [SerializeField] private Rigidbody2D rigidbody2DPoder;
    [SerializeField] private float velocidadeMovimentacao = 10;

    private Vector3 _direcao = UnityEngine.Vector2.zero;

    void Start()
    {
        Destroy(gameObject, 10.0f);
    }

    void Update()
    {
        transform.position = transform.position + Time.deltaTime * velocidadeMovimentacao * _direcao;
    }

    public void MoverPoder(Vector2 novaDirecao)
    {
        _direcao = novaDirecao;
    }
}

