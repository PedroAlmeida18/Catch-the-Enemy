using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoderInimigo : MonoBehaviour
{
    [SerializeField]
    private Rigidbody2D rigidbody2DPoder;
    [SerializeField]
    private float VelocidadeMovimentacao;
    
   

    public void MoverPoder(UnityEngine.Vector2 direcao){
        rigidbody2DPoder.velocity= direcao* VelocidadeMovimentacao;
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    

}
