using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveInimigo : MonoBehaviour
{

    // variável de Animator controla as transições entre animações
    Animator inimigo;

    // variável Rigidbody controla a física e movimentação
    Rigidbody rb;

    // variável que guarda as informações do jogador
    Transform jogador;


    // guarda a velocidade
    public float velocidade;
    // variável que guarda o campo de visão 
    public float vision;


    bool podeSeguir;
    float distanciaAteAlvo;


    // inicialização do script
    void Start()
    {

        // GetComponent só busca no mesmo objeto do script
        inimigo = GetComponent<Animator>();
        rb = GetComponent<Rigidbody>();

        // busca a cena toda por um obj com a tag de Player
        jogador = GameObject.FindGameObjectWithTag("Player").transform;
        
    }

    // Update is called once per frame
    void Update()
    {
        distanciaAteAlvo = Vector3.Distance( transform.position, jogador.position );
        podeSeguir = distanciaAteAlvo < vision;

        inimigo.SetBool("Pode Seguir", podeSeguir);
    }

    // ocorre sempre 50 vezes por segundo
    void FixedUpdate() 
    {
        if( podeSeguir )
        {
            transform.LookAt(jogador);

            // para encontrar a direção entre 2 pontos utilizamos a formula:
            // ponto final - ponto inicial
            Vector3 dir = jogador.position - transform.position;

            // aplicamos uma força na direção encontrada
            rb.AddForce( dir.normalized * velocidade, ForceMode.Force );
        }
    }





}
