using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PauseMenu : MonoBehaviour, IPointerClickHandler
{
    [SerializeField] GameObject pauseMenu;
    [SerializeField] Button button;
    [SerializeField] InputChannel inputChannel;
    private PlayerInput playerInput;
    //private bool isPaused = false;

    private void Start()
    {
        playerInput = GetComponent<PlayerInput>();
        //if (playerInput == null)
       // {
          //  Debug.LogError("Player Input component not found.");
          //  return;
       // }

        playerInput.actions["Player/Click"].performed += OnClickPerformed;

        var beacon = FindObjectOfType<BeaconSO>();
        if (beacon == null)
        {
            Debug.LogError("BeaconSO not found!");
            return;
        }

        inputChannel = beacon.inputChannel;
        if (inputChannel == null)
        {
            Debug.LogError("ClickChannel not found in Beaco nSO!");
            return;
        }
        inputChannel.ClickEvent += Pause;
        
        button.onClick.AddListener(() => Pause());
    }

    private void OnClickPerformed(InputAction.CallbackContext context)
    {
        Debug.Log("Mouse Click Detected");
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        Debug.Log("UI Element Clicked");
    }


    public void Pause()
    {
        if (pauseMenu.activeInHierarchy)
        {
            pauseMenu.SetActive(false);
            inputChannel.EnablePlayer();
            return;
        }
        if (!pauseMenu.activeInHierarchy)
        {
            pauseMenu.SetActive(true);
            EventSystem.current.SetSelectedGameObject(button.gameObject);
            inputChannel.EnableMenu();
        }

    }
    public void Resume()
    {
        pauseMenu.SetActive(false);
        Time.timeScale = 1f;
    }
    public void Home(int sceneID)
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(sceneID);
    }

}
