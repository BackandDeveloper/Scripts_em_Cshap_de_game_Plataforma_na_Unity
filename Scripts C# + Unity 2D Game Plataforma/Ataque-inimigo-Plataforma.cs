// Script para adicionar o ataque inimigo a um Game Plataforma 2D na Unity:

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class inimigoEsqueleto : MonoBehaviour
{
    public Transform pontoA;
    public Transform pontoB;
    public float velocidade = 1f;
    private Vector3 direcao;
    private bool viradoDireita = true;
    //private float tempo = 0f;
    //public float alturaSalto = 0.5f;
    void Start()
    {
        direcao = (pontoB.position - pontoA.position).normalized;
    }
    void Update()
    {
        transform.position += direcao * velocidade * Time.deltaTime;
        //float flutuacao = Mathf.Sin(tempo) * alturaSalto;
        transform.position = new Vector3(transform.position.x, pontoA.position.y + transform.position.z);


        if (Vector2.Distance(transform.position, pontoB.position) < 0.1f)
        {
            direcao = (pontoA.position - pontoB.position).normalized;
            Flipar();
        }
        else if (Vector2.Distance(transform.position, pontoA.position) < 0.1f)
        {
            direcao = (pontoB.position - pontoA.position).normalized;
            Flipar();

        }

    }
    void Flipar()
    {
        viradoDireita = !viradoDireita;
        Vector3 escalaLocal = transform.localScale;
        escalaLocal.x *= -1;
        transform.localScale = escalaLocal;
    }
}