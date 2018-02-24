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
        Debug.Log("Entro aqui der xdd");
        anim.SetBool("RightMov",true);   
        Doggo.transform.Translate(1, 0, 0);

        yield return new WaitForSeconds(1.5f);
    
        anim.SetBool("RightMov", false);
    }

    public IEnumerator movIzquierda()
    {
        Debug.Log("Entro aqui izq xdd");
       
        anim.SetBool("LeftMov", true);
        Doggo.transform.Translate(-1, 0, 0);
        yield return new WaitForSeconds(1.5f);
        anim.SetBool("LeftMov", false);
    }
    public IEnumerator movAbajo()
     {
        Debug.Log("Entro aqui abajo xdd");
       
        anim.SetBool("DownMov", true);
        

        Doggo.transform.Translate(0, -1, 0);
        yield return new WaitForSeconds(1.5f);
        anim.SetBool("DownMov", false);

    }

 
     
     public IEnumerator movArriba()
     {
        Debug.Log("Entro aqui arriba xdd");
       
        anim.SetBool("UpMov", true);
        Doggo.transform.Translate(0, 1 , 0);
  
        yield return new WaitForSeconds(1.5f);
        anim.SetBool("UpMov", false);
    }


}
