using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using Unity.VisualScripting;
using UnityEngine;


public class Controla_Poder : MonoBehaviour
{

  
    [SerializeField]
    private Rigidbody2D rigidbody2DPoder;
    [SerializeField]
    private float VelocidadeMovimentacao;
    
   

    public void MoverPoder(UnityEngine.Vector2 direcao){
        rigidbody2DPoder.velocity= direcao* VelocidadeMovimentacao;
    }
   
}

