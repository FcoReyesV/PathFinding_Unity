using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingDoggo : MonoBehaviour {
    public float MaxPos = 1f;
    public float Speed = 62.5f; //es la distancia 
    public GameObject Doggo;
    public static MovingDoggo instance;
    private float pos_actual;

    private Animator anim;
    private void Awake()
    {
        anim = GetComponent<Animator>();
      
    }


    public IEnumerator movDerecha()
    {
        Debug.Log("Der");
        anim.SetTrigger("MovDer");   
        Doggo.transform.Translate(1, 0, 0);
        yield return new WaitForSeconds(1.5f);
    
        
    }

    public IEnumerator movIzquierda()
    {
        Debug.Log("Izq");

        anim.SetTrigger("MovIzq");
        Doggo.transform.Translate(-1, 0, 0);
        yield return new WaitForSeconds(1.5f);
        
    }
    public IEnumerator movAbajo()
     {
        Debug.Log("Abajo");

        anim.SetTrigger("MovAbajo");


        Doggo.transform.Translate(0, -1, 0);
        yield return new WaitForSeconds(1.5f);
        

    }

 
     
     public IEnumerator movArriba()
     {
        Debug.Log("Arriba");

        anim.SetTrigger("MovArriba");
        Doggo.transform.Translate(0, 1 , 0);
  
        yield return new WaitForSeconds(1.5f);
       
    }


}
