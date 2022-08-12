using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GateTrigger : MonoBehaviour
{
    [SerializeField] GameObject canvas, panel1, youWinBoard;
    private void OnTriggerEnter(Collider other)
    {
        canvas.SetActive(true);
        panel1.SetActive(false);
        youWinBoard.SetActive(true);
        Time.timeScale = 0;
        Cursor.lockState = CursorLockMode.None;
    }
}
