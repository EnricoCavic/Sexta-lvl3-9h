// bibliotecas / libs
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// comaça a nossa lógica
public class AnimarPersonagem : MonoBehaviour
{
    // declaração de variável
    float inputVertical;
    Animator meuAnimator;

    Rigidbody rb;
    public float velocidadeMovimento;

    float inputHorizontal;

    public float velocidadeGiro;

    // ocorre uma vez ao iniciar o jogo
    void Start()
    {
        meuAnimator = GetComponent<Animator>();

        rb = GetComponent<Rigidbody>();

    }

    // ocorre uma vez por frame (fps)
    void Update()
    {
        // lendo os inputs
        inputVertical = Input.GetAxis("Vertical");
        inputHorizontal = Input.GetAxis("Horizontal");

        // rodando a animação
        meuAnimator.SetFloat("Vertical", inputVertical);

        // rotacionando o personagem
        Vector3 dir = transform.up * velocidadeGiro * inputHorizontal;
        rb.AddTorque(dir, ForceMode.Force);

        // movendo o personagem
        Vector3 frente = transform.forward * velocidadeMovimento * inputVertical;
        rb.AddForce(frente, ForceMode.Force);
    }
}
