using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeduzaBala : MonoBehaviour
{
    private void Awake()
    {
        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.GetComponent<Player1Controller>() && !collision.gameObject.GetComponent<Player1Controller>().Petrificado)
        {
            StartCoroutine(collision.gameObject.GetComponent<Player1Controller>().Petrificar());
            Destroy(gameObject,collision.gameObject.GetComponent<Player1Controller>().tiempoPetrificado + 5f );

        }
        else
        {
            Destroy(gameObject, 20f);
        }
        if (collision.gameObject.GetComponent<Player2Controller>() && !collision.gameObject.GetComponent<Player2Controller>().Petrificado)
        {
            StartCoroutine(collision.gameObject.GetComponent<Player2Controller>().Petrificar());
            Destroy(gameObject, collision.gameObject.GetComponent<Player2Controller>().tiempoPetrificado + 5f);
        }
        //Destroy(gameObject, 0.5f);

    }
}
