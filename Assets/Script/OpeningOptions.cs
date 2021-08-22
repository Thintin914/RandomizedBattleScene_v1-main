using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class OpeningOptions : MonoBehaviour
{
    public SpriteRenderer[] sr;
    private int selectionIndex = 0;

    private void Start()
    {
        sr[1].color = new Color32(145, 15, 175, 255);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.W) && selectionIndex - 1 >= 0)
        {
            sr[selectionIndex].color = new Color32(145, 15, 175, 255);
            selectionIndex--;
            sr[selectionIndex].color = new Color32(255, 255, 255, 255);
        }
        if (Input.GetKeyDown(KeyCode.S) && selectionIndex + 1 < 2)
        {
            sr[selectionIndex].color = new Color32(145, 15, 175, 255);
            selectionIndex++;
            sr[selectionIndex].color = new Color32(255, 255, 255, 255);
        }
        if (Input.GetKeyDown(KeyCode.Z))
        {
            if (selectionIndex == 0)
            {
                SceneManager.LoadScene("SelectInitialCharacter");
            }
            else
            {
                Application.Quit();
            }
        }
    }
}
