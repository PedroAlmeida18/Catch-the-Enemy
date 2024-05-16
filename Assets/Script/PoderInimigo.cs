using UnityEngine;

public class PoderInimigo : MonoBehaviour
{
    [SerializeField] private Rigidbody2D rigidbody2DPoder;
    [SerializeField] private float velocidadeMovimentacao = 10;

    private Vector3 _direcao = Vector2.zero;

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

//using System.Collections;
//using System.Collections.Generic;
//using UnityEngine;

//public class PoderInimigo : MonoBehaviour
//{
//    [SerializeField]
//    private Rigidbody2D rigidbody2DPoder;
//    [SerializeField]
//    private float VelocidadeMovimentacao = 10;

//    void Start()
//    {
//        Destroy(gameObject, 10.0f);
//    }

//     Update is called once per frame
//    void Update()
//    {

//    }

//    public void MoverPoder(Vector2 direcao)
//    {
//        rigidbody2DPoder.velocity = direcao * VelocidadeMovimentacao;
//    }
//}
