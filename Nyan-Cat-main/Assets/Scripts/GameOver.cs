using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOver : MonoBehaviour
{
    [SerializeField] GameObject gameOver;
    public Animator PlayerAnimator;

    public void Home(int sceneID)
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(sceneID);
    }

    private void OnTriggerEnter2D(Collider2D Player)
    {
        if (Player.CompareTag("Apple"))
        {
            Destroy(Player.gameObject);
            gameOver.SetActive(true);
            Time.timeScale = 0f;
        }
    }
}
