using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour {


    // VARIAVEIS
    #region 
    public bool GameIsPaused = false;
    public GameObject pauseMenuUI;
    public GameObject restartUI;
    public GameObject inGameOptionsUI;

    public GameObject skillPanel;
    public GameObject hudCanvas;
    public GameObject shopCanvas;
    public GameObject shopConsuCanvas;
    public GameObject shopWeaponCanvas;

    public bool isInPanel;
    bool shopPanel;
    public bool isInShop;
    GameObject player;
    GameObject playerWeapon;
    GameObject waveTeleport;
    PlayerHealth playerHealth;
    bool inOptions;
    Teleport tp;
    Weapon weapon;
    Experience experience;
    PlayerMovement playerMovement;
    public bool shopConsu;
    public bool shopWeapon;
    public bool shopEquip;
    AudioSource audioSource;

    bool clickButton;
    #endregion

    void Start()
    {       

        player = GameObject.FindGameObjectWithTag("Player");
        audioSource = player.GetComponent<AudioSource>();

        playerHealth = player.GetComponent<PlayerHealth>();
        experience = player.GetComponent<Experience>();
        playerMovement = player.GetComponent<PlayerMovement>();
       
    }

    public void Onclick()
    {
        clickButton = true;
    }

  

    void Update()
    {
        ShopCanvas();

        if ((Input.GetKeyDown(KeyCode.K) && !inOptions) || (clickButton && !inOptions))
        {
            if (GameIsPaused && skillPanel.activeInHierarchy && !isInShop)
            {
                Resume();
            }
            else
            {
                isInPanel = true;
                clickButton = false;
                hudCanvas.SetActive(false);
                skillPanel.SetActive(true);
                Pause();

            }
        }
        if ((Input.GetKeyDown(KeyCode.K) && !isInPanel) )
        {
            Pause();
            clickButton = false;
            skillPanel.SetActive(true);
            isInPanel = true;       
        }

        if (Input.GetKeyDown(KeyCode.Escape) && !inOptions)
        {
            if (GameIsPaused)
            {

                Resume();
            }
            else
            {
                pauseMenuUI.SetActive(true);
                Pause();
            }
        }
        if (Input.GetKeyDown(KeyCode.Escape) && inOptions)
        {
            inGameOptionsUI.SetActive(false);
            pauseMenuUI.SetActive(true);
            inOptions = false;
        }

    }

    private void ShopCanvas()
    {

        if (Input.GetKeyDown(KeyCode.F) && !inOptions && isInShop)
        {

                Pause();
                if (shopEquip)
                {
                    shopCanvas.SetActive(true);
                }
                if (shopConsu)
                {
                    shopConsuCanvas.SetActive(true);
                }
                if (shopWeapon)
                {
                    shopWeaponCanvas.SetActive(true);
                }
            
        }
    }

    public void ShowRestartUI()
    {
        restartUI.SetActive(true);
    }

   public void Resume()
    {
        skillPanel.SetActive(false);
        pauseMenuUI.SetActive(false);
        shopWeaponCanvas.SetActive(false);
        shopConsuCanvas.SetActive(false);
        shopCanvas.SetActive(true);
        hudCanvas.SetActive(true);
        audioSource.volume = 1;
        Time.timeScale = 1f;
        GameIsPaused = false;
        clickButton = false;
        shopCanvas.SetActive(false);
        playerWeapon = GameObject.FindGameObjectWithTag("Weapon");
        weapon = playerWeapon.GetComponent<Weapon>();
        experience.UpdateBonus();
        weapon.MultiplicarDamage();
        playerMovement.Velocidade();

    }

   void Pause()
    {

        hudCanvas.SetActive(false);
        audioSource.volume = 0;
        Time.timeScale = 0f;
        GameIsPaused = true;  
              
    }

    public void LoadMenu()
    {
        SceneManager.LoadScene("Menu");
        Time.timeScale = 1f;      
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    public void InGameOptions()
    {
        inGameOptionsUI.SetActive(true);
        Time.timeScale = 0f;
        GameIsPaused = true;
        inOptions = true;
    }

    public void RestartLevel()
    {
       
        SceneManager.LoadScene("Jogo");
        Time.timeScale = 1f;
    }
   
}
