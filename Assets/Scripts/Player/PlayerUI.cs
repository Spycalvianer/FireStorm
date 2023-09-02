using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerUI : MonoBehaviour
{
    PlayerData playerDataVar;
    Shooting playerShooting;
    MovementScript playerMovement;
    public Image boostImage;
    public Text bulletsText;
    public Image lifebarImage;
    public Image ammoImage;
    public GameObject pauseMenu;
    public GameObject optionsMenu;
    bool openPauseMenu;
    bool openOptionsMenu;
    public Text objectiveText;
    public DoorScript doorScript;

    private void Awake()
    {
        pauseMenu.SetActive(false);
        
        GetComponents();
    }
    private void Update()
    {
        UpdateUIElements();
        OpenPauseMenuFunction();
        ObjectiveTextChange();
    }
    void GetComponents()
    {
        playerMovement = GetComponent<MovementScript>();
        playerShooting = GetComponent<Shooting>();
        playerDataVar = GetComponent<PlayerData>();
    }

    void ObjectiveTextChange()
    {
        if (doorScript.numberOfTurrets <= 0)
        {
            objectiveText.text = "Escape the fire tornado";
        }
        else objectiveText.text = "Destroy all turrets to open the door";
    }
    void OpenPauseMenuFunction()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            openPauseMenu = !openPauseMenu;
            pauseMenu.SetActive(openPauseMenu);
        }
        if (openPauseMenu)
        {
            Time.timeScale = 0;
        }
        else if (openPauseMenu == false)
        {
            Time.timeScale = 1;
        }
    }
    void UpdateUIElements()
    {
        boostImage.fillAmount = playerMovement.boostLimit / playerMovement.maxBoost;
        lifebarImage.fillAmount = playerDataVar.playerLife / playerDataVar.playerMaxLife;
        ammoImage.fillAmount = Mathf.Clamp01((playerShooting.maxBullets - playerShooting.bulletLimit) / playerShooting.maxBullets);
    }
    public void OpenOptionsMenuFunction()
    {
        openOptionsMenu = !openOptionsMenu;
        optionsMenu.SetActive(openOptionsMenu);
    }
}
