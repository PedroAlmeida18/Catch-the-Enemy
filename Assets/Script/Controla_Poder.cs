using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Controla_Poder : MonoBehaviour
{
    public GameObject Poder ;
    public GameObject Inimigo; 
    private Collision2D collision2DPoder;
    private  int zumbimorto = 0;

    void Start()
    {

        Poder.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        AcompanhaMouse();

        
    }
private void AcompanhaMouse(){
         Vector3 mousePosition = Input.mousePosition;
        Vector3 worldPosition = Camera.main.ScreenToWorldPoint(mousePosition);
        Poder.transform.position = worldPosition;
    }
}

