// Script que adiciona a moviementação de um game Plataforma 2D na Unity:

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovimentoInimigo : MonoBehaviour
{
    public float velocidade;
    public Transform pontoA;
    public Transform pontoB;

    private Vector3 direcao;
    private bool viradoDireita = true;
    private Rigidbody2D rb;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        direcao = (pontoB.position - pontoA.position).normalized;
    }

    void Update()
    {
        Mover();
        Virar();
    }

    void Mover()
    {
        rb.velocity = new Vector2(direcao.x * velocidade, rb.velocity.y);

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

    void Virar()
    {
        if ((direcao.x > 0 && !viradoDireita) || (direcao.x < 0 && viradoDireita))
        {
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
