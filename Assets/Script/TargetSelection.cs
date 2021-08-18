using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetSelection : MonoBehaviour
{
    public BattleMenu battleMenu;
    private int previousIndex = 0;
    private SpriteRenderer sr;
    private Sprite sp;
    public Database database;

    private void Start()
    {
        if (battleMenu != null)
        {
            transform.position = GetPositionFromBattleMenu(battleMenu.isTargetAlly, battleMenu.currentTarget);
        }

        sr = GetComponent<SpriteRenderer>();
        sp = sr.sprite;
    }

    private void LateUpdate()
    {
        transform.Rotate(new Vector3(0, 0, -10 * Time.deltaTime));
        if (battleMenu != null)
        {
            if (previousIndex != battleMenu.currentTarget)
            {
                transform.position = GetPositionFromBattleMenu(battleMenu.isTargetAlly, battleMenu.currentTarget);
            }
        }
        else
        {
            if (database.isHandling == false)
            {
                if (previousIndex != database.beatCharacterSelectionIndex)
                {
                    transform.position = GetPositionFromDatabase(database.beatCharacterSelectionIndex);
                }
            }
        }
    }

    public Vector2 GetPositionFromBattleMenu(bool isAlly, int index)
    {
        previousIndex = index;
        if (isAlly)
        {
            return battleMenu.database.allyDetails[index].GetComponent<Character>().sceneCharacter.transform.position;
        }
        else
        {
            return battleMenu.database.enemyDetails[index].GetComponent<Character>().sceneCharacter.transform.position;
        }
    }

    public Vector2 GetPositionFromDatabase (int index)
    {
        previousIndex = index;
        return database.enemyDetails[index].GetComponent<Character>().sceneCharacter.transform.position;
    }

    public void Hide()
    {
        sr.sprite = null;
        enabled = false;
    }

    public void Show()
    {
        sr.sprite = sp;
        enabled = true;
    }
}
