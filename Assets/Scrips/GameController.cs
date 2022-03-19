using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
    public Text Pontuação;
    public PlayerController player;
   
    Vector3 posicaoInicial;
    
    public float divisor;

    public GameObject painelGAMEROVER;
    public GameObject painelVenceuJogo;

    public AudioClip sfxWinGame;
    public AudioController audioController;

  
    public void VencerJogo()
    {
        audioController.TouchSFX(sfxWinGame);
        painelVenceuJogo.SetActive(true);
    } 

    void Start()
    {
        posicaoInicial = player.transform.position;
    }

    void Update()
    {
        if (player == null)
        {
            return;
        }

        Vector3 distanciaPercorrida = player.transform.position - posicaoInicial;
        float pontuacao = distanciaPercorrida.z / divisor;
        Pontuação.text = pontuacao.ToString("0");
    }

    public void GameOver()
    {
        painelGAMEROVER.SetActive(true);
    }

}
