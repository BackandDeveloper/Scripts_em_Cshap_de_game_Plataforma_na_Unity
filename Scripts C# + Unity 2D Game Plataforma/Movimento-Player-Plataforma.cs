// Script que faz o Player se movimentar um Game Plataforma 2D na Unity:

plataforma using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovimentoPlataforma : MonoBehaviour
{


    public float velocidade;
    public float forcaPulo;
    public Transform verificadorDeChao;
    public LayerMask camadaChao;

    private bool estanoChao;
    private Rigidbody2D rb;
    private bool viradoDireita = true;

    public Animator animator;

    public AudioSource attackSound;
    public AudioSource stepSound;

    void Start()
    {

        rb = GetComponent<Rigidbody2D>();
        animator.SetBool("estaCorrendo", false);
        animator.SetBool("estaPulando", false);
    }


    void Update()
    {

        Mover();
        Pular();
        Virar();
        Atacar();
    }
    void Mover()
    {
        float entradaMovi = Input.GetAxisRaw("Horizontal");
        rb.velocity = new Vector2(entradaMovi * velocidade, rb.velocity.y);

        float deadZone = 0.1f;
        bool isRunning = Mathf.Abs(entradaMovi) > deadZone;

        if (isRunning)
        {
            if (!stepSound.isPlaying)
            {
                stepSound.Play();
            }
        }
        else
        {
            if (stepSound.isPlaying)
            {
                stepSound.Stop();
            }
        }

        animator.SetBool("estaCorrendo", isRunning);
    }

    void Pular()
    {
        estanoChao = Physics2D.OverlapCircle(verificadorDeChao.position, 0.2f, camadaChao);
        if (estanoChao && Input.GetKeyDown(KeyCode.Space))
        {
            rb.velocity = new Vector2(rb.velocity.x, forcaPulo);
        }

    }

    void Virar()
    {
        float entradaDeMovimento = Input.GetAxis("Horizontal");

        if (entradaDeMovimento > 0 && !viradoDireita)
        {
            Flipar();

        }
        else if (entradaDeMovimento < 0 && viradoDireita)
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

    void Atacar()
    {
        if (Input.GetKeyDown("fire1"))
        {
            animator.SetTrigger("Attack");
            attackSound.Play();
        }
    }
}