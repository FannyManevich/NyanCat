using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOver : MonoBehaviour
{
    [SerializeField] GameObject gameOver;
    public Animator playerAnimator;

  
    public void Home(int sceneID)
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(sceneID);
    }

    private void OnTriggerEnter2D(Collider2D player)
    {
        if (player.CompareTag("Apple"))
        {
          Destroy(player.gameObject);
          gameOver.SetActive(true);
          Time.timeScale = 0f;
        }
    }
}
