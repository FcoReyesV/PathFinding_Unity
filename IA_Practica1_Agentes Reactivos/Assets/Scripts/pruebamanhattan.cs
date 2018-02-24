using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pruebamanhattan : MonoBehaviour
{
    private MovingDoggo md;
    private void Awake()
    {
        md = GetComponent<MovingDoggo>();
    }
 

    // Update is called once per frame
    void Update()
    {


        /*------------------------------------------------------------------------------------------------------------*/
    }

    void ubicacionPerrito()
    {
        int n = 0;
        int x_p = 0, y_p = 0, x_o = 9, y_o = 0;
        //esto se le hace cada vez que se mueve
        if (n == 1)//arriba
        {
            y_p -= 1;
        }
        else if (n == 2)//abajo
        {
            y_p += 1;
        }
        else if (n == 3)//izquierda
        {
            x_p -= 1;
        }
        else if (n == 4)//derecha
        {
            x_p += 1;
        }

        /*------------Esta cosa ya es para tener en una matriz el que onda que pex---------------------------------*/
        string[,] tagesitos = new string[8, 10];
        GameObject[] ch = new GameObject[80];
        GameObject ParentGameObject = GameObject.FindGameObjectWithTag("EscenarioCompleto");
        for (int i = 0; i < 80; i++)
        {
            ch[i] = ParentGameObject.transform.GetChild(i).gameObject;
        }

        int k = 0;
        for (int i = 0; i < 8; i++)
        {
            for (int j = 0; j < 10; j++)
            {
                tagesitos[i, j] = ch[k++].tag;
            }
        }

        int cam_altx = x_p, cam_alty = y_p;
        int a = 0;
        while (cam_altx != x_o && cam_alty != y_o)
        {
            if (tagesitos[cam_altx, cam_alty - 1].Equals("Grass1") || tagesitos[cam_altx, cam_alty + 1].Equals("Grass2") || tagesitos[cam_altx, cam_alty + 1].Equals("Hueso1") || tagesitos[cam_altx, cam_alty + 1].Equals("Hueso2"))
            {//arriba
                StartCoroutine(md.movArriba());
            }
            else if (tagesitos[cam_altx + 1, cam_alty].Equals("Grass1") || tagesitos[cam_altx + 1, cam_alty].Equals("Grass2") || tagesitos[cam_altx + 1, cam_alty].Equals("Hueso1") || tagesitos[cam_altx + 1, cam_alty].Equals("Hueso2"))
            {//derecha
                StartCoroutine(md.movDerecha());
            }
            else if (tagesitos[cam_altx - 1, cam_alty].Equals("Grass1") || tagesitos[cam_altx - 1, cam_alty].Equals("Grass2") || tagesitos[cam_altx - 1, cam_alty].Equals("Hueso1") || tagesitos[cam_altx - 1, cam_alty].Equals("Hueso2"))
            {//izquierda
                StartCoroutine(md.movIzquierda());
            }
            else if (tagesitos[cam_altx, cam_alty + 1].Equals("Grass1") || tagesitos[cam_altx, cam_alty + 1].Equals("Grass2") || tagesitos[cam_altx, cam_alty + 1].Equals("Hueso1") || tagesitos[cam_altx, cam_alty + 1].Equals("Hueso2"))
            {//abajo
                StartCoroutine(md.movAbajo());
            }
        }

    }
}
