﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StoryTelling : MonoBehaviour
{
    public Database database;
    private TMPro.TextMeshProUGUI textHolder, instrictionHolder;
    private Transform canvasTransform;
    public List<string> storyLines;
    public List<int> storyImageIndexs;
    public Sprite[] storyImages;
    private int page = 0;
    public GameObject spriteHolder;
    private SpriteRenderer sr;

    private void Awake()
    {
        database = GameObject.Find("Database").GetComponent<Database>();
        canvasTransform = GameObject.Find("Canvas").transform;

        instrictionHolder = Instantiate(database.instruction).GetComponent<TMPro.TextMeshProUGUI>();
        instrictionHolder.text = "[Z] to flip, [X] to skip";
        instrictionHolder.transform.SetParent(canvasTransform);

        textHolder = Instantiate(database.instruction).GetComponent<TMPro.TextMeshProUGUI>();
        textHolder.text = null;
        textHolder.fontSize = 2;
        textHolder.transform.SetParent(canvasTransform);
        textHolder.transform.position = new Vector2(0, -4.5f);
        textHolder.alignment = TMPro.TextAlignmentOptions.Midline;
        textHolder.color = new Color32(250, 200, 55, 255);
    }

    private void Start()
    {
        AddStoryLines(database.level);
        StartCoroutine(TellStory());
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.X))
        {
            database.transform.parent.GetComponent<CrossSceneManagement>().LoadScene("BattleScene");
            enabled = false;
        }
    }

    private IEnumerator TellStory()
    {
        sr = Instantiate(spriteHolder).GetComponent<SpriteRenderer>();
        sr.sprite = null;
        sr.transform.position = Vector2.zero;

        do
        {
            yield return new WaitUntil(() => !Input.GetKeyDown(KeyCode.Z));

            if (page < storyLines.Count)
            {
                textHolder.text = storyLines[page];
                sr.sprite = storyImages[storyImageIndexs[page]];
            }
            yield return new WaitUntil(() => Input.GetKeyDown(KeyCode.Z));
            page++;
        } while (page < storyLines.Count);
        Destroy(instrictionHolder.gameObject);
        Destroy(sr.gameObject);

        enabled = false;
        textHolder.text = GetLevelName(database.level);
        textHolder.transform.position = Vector2.zero;
        textHolder.fontSize = 4f;
        yield return new WaitForSeconds(1.8f);
        database.transform.parent.GetComponent<CrossSceneManagement>().LoadScene("BattleScene");
    }

    public void AddStoryLines(int level)
    {
        storyLines.Clear();
        storyImageIndexs.Clear();
        switch (level)
        {
            case 0:
                storyLines.Add("Once upon a time, there was a prosperous and peaceful kingdom.");
                storyLines.Add("Under the blessing of God, the kingdom had the richest soil and the strongest army.");
                storyLines.Add("But greed could never be fulfilled...");
                storyImageIndexs.Add(0);
                storyImageIndexs.Add(0);
                storyImageIndexs.Add(0);
                break;
            case 1:
                storyLines.Add("Wrath of the God drowned the kingdom.");
                storyLines.Add("Since then, the land was doomed.");
                storyLines.Add("The king caused it all...");
                storyImageIndexs.Add(1);
                storyImageIndexs.Add(1);
                storyImageIndexs.Add(1);
                break;
            case 2:
                storyLines.Add("From the east of the Royal Edge, \n to the west of the Serinus Garden,\nfear danced.");
                storyLines.Add("Light of the Great Beacon dimed. \nTowers of the Carnival City collapsed.");
                storyLines.Add("Sky burnt and mountains fell...");
                storyImageIndexs.Add(2);
                storyImageIndexs.Add(2);
                storyImageIndexs.Add(2);
                break;
            case 3:
                storyLines.Add("\"The absence of mind.\nThe beauty and the purity of consciousness...\"");
                storyLines.Add("\"Human thoughts are full of sins...,\nI have to get rid of it.\"");
                storyLines.Add("\"...So we can behaves in a completely unprejudiced and unconscious manner,\nlike a child or a God.\"");
                storyImageIndexs.Add(2);
                storyImageIndexs.Add(2);
                storyImageIndexs.Add(2);
                break;
            case 4:
                storyLines.Add("Such unholy act angered the God.");
                storyLines.Add("The curtain of blood and flesh arose.");
                storyLines.Add("Its title was Doomsday");
                storyImageIndexs.Add(2);
                storyImageIndexs.Add(2);
                storyImageIndexs.Add(2);
                break;
            case 5:
                storyLines.Add("The survivors built a great wall next to the Sierra Carnival Mountains.");
                storyLines.Add("It seemed promising at first.");
                storyLines.Add("People named it \"The Promising Wall\",\n wished to reclaim the lost kingdom...");
                storyLines.Add("But it failed.");
                storyImageIndexs.Add(2);
                storyImageIndexs.Add(2);
                storyImageIndexs.Add(2);
                storyImageIndexs.Add(2);
                break;
            default:
                storyLines.Add("Homeland...");
                storyImageIndexs.Add(0);
                break;
        }
    }

    public string GetLevelName(int level)
    {
        switch (level)
        {
            case 0:
                return "Bloodline Fortress";
            case 1:
                return "Cynthia Coast";
            case 2:
                return "West Beacon";
            case 3:
                return "Dark Forest";
            case 4:
                return "Promise Wall";
            case 5:
                return "Carnival City";
            case 6:
                return "Royal Edge";
            case 7:
                return "Northostone Castle West ";
            case 8:
                return "Northostone Castle Top";
            case 9:
                return "Serinus Garden";
            case 10:
                return "East Beacon";

        }
        return "Mysterious Place";
    }
}