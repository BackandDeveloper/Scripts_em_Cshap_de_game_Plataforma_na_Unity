// Script para que o Player, realize um ataque em um game plataforma 2D na Unity:

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class inimigoEsqueleto : MonoBehaviour
{
    public float distanciaAtaque = 1f;
    public int dano = 10;
    private Transform jogador;

    void Start()
    {
        jogador = GameObject.FindGameObjectWithTag("Player").transform;
    }

    void Update()
    {
        VerificarAtaque();
    }

    void VerificarAtaque()
    {
        if (Vector2.Distance(transform.position, jogador.position) < distanciaAtaque)
        {
            Atacar();
        }
    }

    void Atacar()
    {
        Debug.Log("Ataque do inimigo! Dano: " + dano);
    }
}
