using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoderInimigo : MonoBehaviour
{
    [SerializeField]
    private Rigidbody2D rigidbody2DPoder;
    [SerializeField]
    private float VelocidadeMovimentacao = 10;
    
   

  
    void Start()
    {
         Destroy(gameObject,10.0f);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
      public void MoverPoder(UnityEngine.Vector2 direcao){
        rigidbody2DPoder.velocity = direcao* VelocidadeMovimentacao;
        
    }



}
