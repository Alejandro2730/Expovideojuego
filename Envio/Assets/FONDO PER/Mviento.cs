using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mviento : MonoBehaviour
{
    [SerializeField] private Vector2 velocidadMoviento;

    private Vector2 offset;

    private Material material;

    private void Awake(){

        material=GetComponent<SpriteRenderer>().material;
    }

    private void Update(){

        offset = velocidadMoviento * Time.deltaTime;
        material.mainTextureOffset += offset;
    }

} 
