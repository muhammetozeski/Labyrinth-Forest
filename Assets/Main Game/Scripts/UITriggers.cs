using System.Collections;
using System.Collections.Generic;
using MainGame.PlayerInput;
using MainGame.GameCamera;
using MainGame.Player;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UITriggers : MonoBehaviour
{
    [SerializeField] private AbstractInputData _ESCKey;
    [SerializeField] CameraSettings mouse;
    [SerializeField] PlayerMovingSettings playerMovingSettings;

    [SerializeField] Dropdown dropdownQuality;

    [SerializeField] Text textGetMouseSensivity;
    [SerializeField] Text textSetMouseSensivity;

    [SerializeField] Text textGetSpeed;
    [SerializeField] Text textSetSpeed;

    [SerializeField] Canvas canvas;
    private void Start()
    {
        showUI();
    }

    public void showUI()
    {
        Time.timeScale = 0;
        AssignTheUIValues();
        canvas.gameObject.SetActive(true);
    }

    void AssignTheUIValues()
    {
            textSetMouseSensivity.text = "" + mouse.MouseSpeed;
            textSetSpeed.text = "" + playerMovingSettings.Speed;

        dropdownQuality.value = QualitySettings.GetQualityLevel(); 
    }

    public void ApplyQualitySetting()
    {
        QualitySettings.SetQualityLevel(dropdownQuality.value, true);
    }

    public void PlayButton()
    {
        if (textGetMouseSensivity.text != "")
            mouse.MouseSpeed = float.Parse(textGetMouseSensivity.text);
        if (textGetSpeed.text != "")
            playerMovingSettings.Speed = float.Parse(textGetSpeed.text);

        Time.timeScale = 1;
        canvas.gameObject.SetActive(false); 
        Cursor.lockState = CursorLockMode.Locked;
    }

    public void RestartButton()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void CloseButton()
    {
        Application.Quit();
    }
}
