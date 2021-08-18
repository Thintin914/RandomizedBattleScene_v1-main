using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BattleController : MonoBehaviour
{
    public Database database;
    public bool isBeatable = true;

    private void Awake()
    {
        database = GameObject.Find("Database").GetComponent<Database>();
    }

    void Update()
    {
        if (isBeatable == true)
        {
            if (Input.GetKeyDown(KeyCode.A) && database.beatCharacterSelectionIndex - 1 >= 0)
            {
                database.beatCharacterSelectionIndex--;
            }

            if (Input.GetKeyDown(KeyCode.D) && database.beatCharacterSelectionIndex + 1 < database.enemyDetails.Count)
            {
                database.beatCharacterSelectionIndex++;
            }

            if (database.isHandling == true)
            {
                isBeatable = false;
                database.targetIconHolder.Hide();
            }
            else
            {
                isBeatable = true;
            }

            if (isBeatable == true)
            {
                if (Input.GetKeyDown(KeyCode.Z) || Input.GetKeyDown(KeyCode.X))
                    database.enemyDetails[database.beatCharacterSelectionIndex].GetComponent<Character>().sceneCharacter.barCharacter.progress -= 0.5f;
            }
        }
        else
        {
            database.targetIconHolder.transform.position = new Vector2(2, -2);
            if (database.isHandling == false && database.enemyDetails.Count > 0)
            {
                isBeatable = true;
                database.beatCharacterSelectionIndex = 0;
                database.targetIconHolder.Show();
            }

        }
    }

}
