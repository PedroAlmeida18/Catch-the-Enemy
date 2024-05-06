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
   private void OnCollisionEnter2D(Collision2D collision)
    {
    
        if (collision.gameObject.CompareTag("Inimigo"))
        {
        
            Destroy(collision.gameObject);
            float eixox = Random.Range(-9,9);
            float eixoy = Random.Range(-4,4);
            zumbimorto++;
            print(zumbimorto);
            Inimigo.transform.position = new Vector3(eixox,eixoy,0);
            Instantiate(Inimigo);
        } 
        

        }
private void AcompanhaMouse(){
         Vector3 mousePosition = Input.mousePosition;
        Vector3 worldPosition = Camera.main.ScreenToWorldPoint(mousePosition);
        Poder.transform.position = worldPosition;
    }
}

