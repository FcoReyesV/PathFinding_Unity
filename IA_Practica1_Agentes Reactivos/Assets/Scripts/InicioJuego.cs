using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InicioJuego : MonoBehaviour
{


    public float distance = 1f;
    public float vel_mov = 0.5f;
    public LayerMask boxMask; //Eso es para que detecte todas las colisiones que hay a su al rededor
    public Sprite[] Pasto = new Sprite[2];
    public GameObject doggo;
    private MovingDoggo md;
    public int x_p = 0, y_p, x_o, y_o;
    public string[,] tagesitos = new string[8, 10];
    public GameObject[] ch = new GameObject[80];
    public int banMigajas = 0;// en 0 sigue mijagas y no tiene carga
                              // en 1 tiene carga y sigue migajas de regreso a la nave
                              // en 2 no tiene carga pero va de regreso de la nave a donde encontro huesos

    private void Awake()
    {
        md = GetComponent<MovingDoggo>();
    }
    private void Start()
    {
        Physics2D.queriesStartInColliders = false;

        // Time.captureFramerate = 25;
        StartCoroutine("empieza");
    }


    IEnumerator empieza()
    {
        GameObject ParentGameObject = GameObject.FindGameObjectWithTag("EscenarioCompleto");
        x_p = 9; y_p = 0; x_o = 9; y_o = 0;//nuevo
        tagesitos = new string[8, 10];
        ch = new GameObject[80];
        while (true)
        {
            int brandom = (int)Random.Range(1.0f, 5.0f);
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

            if (brandom == 1)//arriba
            {
                StartCoroutine(movimientos(1));
                yield return new WaitForSeconds(vel_mov);

            }
            else if (brandom == 2)//abajo
            {
                StartCoroutine(movimientos(2));
                yield return new WaitForSeconds(vel_mov);


            }
            else if (brandom == 3)//izquierda
            {

                StartCoroutine(movimientos(3));
                yield return new WaitForSeconds(vel_mov);
            }
            else if (brandom == 4)//derecha
            {

                StartCoroutine(movimientos(4));
                yield return new WaitForSeconds(vel_mov);


            }
        }
    }



    private IEnumerator movimientos(int n)
    {
        RaycastHit2D[] moves = new RaycastHit2D[5];
        moves[1] = Physics2D.Raycast(transform.position, Vector2.up * transform.localScale.x, distance, boxMask);
        moves[2] = Physics2D.Raycast(transform.position, Vector2.down * transform.localScale.y, distance, boxMask);
        moves[3] = Physics2D.Raycast(transform.position, Vector2.left * transform.localScale.x, distance, boxMask);
        moves[4] = Physics2D.Raycast(transform.position, Vector2.right * transform.localScale.y, distance, boxMask);
        int cam_altx = x_p, cam_alty = y_p;
        if (moves[n].collider != null && (moves[n].collider.gameObject.tag == "Grass1" || moves[n].collider.gameObject.tag == "Grass2"))
        {
            if (n == 1)//arriba
            {
                StartCoroutine(md.movArriba());
                y_p -= 1;
            }
            else if (n == 2)//abajo
            {
                StartCoroutine(md.movAbajo());
                y_p += 1;
            }
            else if (n == 3)//izquierda
            {
                StartCoroutine(md.movIzquierda());
                x_p -= 1;
            }
            else if (n == 4)//derecha
            {
                StartCoroutine(md.movDerecha());
                x_p += 1;
            }
        }
        else if (moves[n].collider != null && (moves[n].collider.gameObject.tag == "Hueso1" || moves[n].collider.gameObject.tag == "Hueso2"))
        {

            Debug.Log("encontro hueso");
            
            Debug.Log("posicion x inicial: " + cam_altx);
            Debug.Log("posicion y inicial: " + cam_alty);
            if (moves[n].collider.gameObject.tag == "Hueso1")
            {
                dibujaPasto1(moves[n].transform.gameObject);
                
            }
            else if (moves[n].collider.gameObject.tag == "Hueso2")
            {
                dibujaPasto2(moves[n].transform.gameObject);
            }

            while (cam_altx < 9 || cam_alty > 0)
            {
                
                if (cam_alty > 0 && (tagesitos[cam_alty - 1, cam_altx].Equals("Casa") ||tagesitos[cam_alty - 1, cam_altx].Equals("Grass1") || tagesitos[cam_alty - 1, cam_altx].Equals("Grass2") || tagesitos[cam_alty - 1, cam_altx].Equals("Hueso1") || tagesitos[cam_alty - 1, cam_altx].Equals("Hueso2")))
                {//arriba

                    StartCoroutine(md.movArriba());
                    cam_alty = cam_alty - 1;
                    Debug.Log("posicion x despues de subir: " + cam_altx);
                    Debug.Log("posicion y despues de subir: " + cam_alty);
                    yield return new WaitForSeconds(vel_mov);
                }
                else if (cam_altx < 9 && (tagesitos[cam_alty  , cam_altx+1].Equals("Casa") || tagesitos[cam_alty, cam_altx + 1].Equals("Grass1") || tagesitos[cam_alty, cam_altx + 1].Equals("Grass2") || tagesitos[cam_alty, cam_altx + 1].Equals("Hueso1") || tagesitos[cam_alty, cam_altx + 1].Equals("Hueso2")))
                {//derecha
                    StartCoroutine(md.movDerecha());

                    cam_altx = cam_altx + 1;
                    Debug.Log("posicion x despues de derecha: " + cam_altx);
                    Debug.Log("posicion y despues de derecha: " + cam_alty);
                    yield return new WaitForSeconds(vel_mov);
                }
                else if (cam_altx > 0 && (tagesitos[cam_alty, cam_altx - 1].Equals("Grass1") || tagesitos[cam_alty, cam_altx - 1].Equals("Grass2") || tagesitos[cam_alty, cam_altx - 1].Equals("Hueso1") || tagesitos[cam_alty, cam_altx - 1].Equals("Hueso2")))
                {//izquierda
                    StartCoroutine(md.movIzquierda());
                    cam_altx = cam_altx - 1;
                    Debug.Log("posicion x despues de izquierda: " + cam_altx);
                    Debug.Log("posicion y despues de izquierda: " + cam_alty);
                    yield return new WaitForSeconds(vel_mov);
                }
                else if (cam_alty < 9 && (tagesitos[cam_alty + 1, cam_altx].Equals("Grass1") || tagesitos[cam_alty + 1, cam_altx].Equals("Grass2") || tagesitos[cam_alty + 1, cam_altx].Equals("Hueso1") || tagesitos[cam_alty + 1, cam_altx].Equals("Hueso2")))
                {//abajo
                    StartCoroutine(md.movAbajo());
                    cam_alty = cam_alty + 1;
                    Debug.Log("posicion x despues de bajar: " + cam_altx);
                    Debug.Log("posicion y despues de bajar: " + cam_alty);
                    yield return new WaitForSeconds(vel_mov);
                }
            }
            Debug.Log("posicion x final: " + cam_altx);
            Debug.Log("posicion y final: " + cam_alty);
            x_p = 9; y_p = 0;
            EventStGame.instance.Huesos_Agregados();
        }
        else if(moves[n].collider != null && (moves[n].collider.gameObject.tag == "CajaPuesta1" || moves[n].collider.gameObject.tag == "CajaPuesta2"|| moves[n].collider.gameObject.tag == "Limites"))
        {
            int brandom;
            do
            {
                brandom = (int)Random.Range(1.0f, 5.0f);
                if (brandom != n)
                {
                    if (brandom == 1)//arriba
                    {
                        StartCoroutine(movimientos(1));
                        yield return new WaitForSeconds(vel_mov);
                    }
                    else if (brandom == 2)//abajo
                    {
                        StartCoroutine(movimientos(2));
                        yield return new WaitForSeconds(vel_mov);
                    }
                    else if (brandom == 3)//izquierda
                    {
                        StartCoroutine(movimientos(3));
                        yield return new WaitForSeconds(vel_mov);
                    }
                    else if (brandom == 4)//derecha
                    {
                        StartCoroutine(movimientos(4));
                        yield return new WaitForSeconds(vel_mov);
                    }
                }
            } while (brandom == n);
                
        }
        else if (moves[n].collider != null && (moves[n].collider.gameObject.tag == "Migajas1" || moves[n].collider.gameObject.tag == "Migajas2"))
        {
            if(banMigajas == 0)
            {// se mete al camino de migajas y lo sigue hacia los huesos si es que hay

            }
            else if (banMigajas == 1)
            {// ya tiene una carga de migajas y se regresa por el camino de migajas

            }
            else if(banMigajas == 2)
            {//llego a la nave y entonces se regresa por el camino de migajas a buscar mas huesitoss

            }
            if (n == 1)//arriba
            {
                StartCoroutine(md.movArriba());
                y_p -= 1;
            }
            else if (n == 2)//abajo
            {
                StartCoroutine(md.movAbajo());
                y_p += 1;
            }
            else if (n == 3)//izquierda
            {
                StartCoroutine(md.movIzquierda());
                x_p -= 1;
            }
            else if (n == 4)//derecha
            {
                StartCoroutine(md.movDerecha());
                x_p += 1;
            }
        }
    }


    private void dibujaPasto1(GameObject objetoPasto)
    {
        
        objetoPasto.GetComponent<SpriteRenderer>().sprite = Pasto[0];
        objetoPasto.transform.gameObject.tag = "Grass1";
    }
    private void dibujaPasto2(GameObject objetoPasto)
    {
        objetoPasto.GetComponent<SpriteRenderer>().sprite = Pasto[1];
        objetoPasto.transform.gameObject.tag = "Grass2";
    }


    private void OnDrawGizmos()
    {
        Gizmos.color = Color.cyan;
        Gizmos.DrawLine(transform.position, (Vector2)transform.position + Vector2.right * transform.localScale.x * distance);
        Gizmos.DrawLine(transform.position, (Vector2)transform.position + Vector2.left * transform.localScale.x * distance);
        Gizmos.DrawLine(transform.position, (Vector2)transform.position + Vector2.up * transform.localScale.y * distance);
        Gizmos.DrawLine(transform.position, (Vector2)transform.position + Vector2.down * transform.localScale.y * distance);
    }


}
