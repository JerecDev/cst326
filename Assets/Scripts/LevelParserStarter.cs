﻿using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class LevelParserStarter : MonoBehaviour
{
    public string filename;

    public GameObject Acid;
    public GameObject Brick;
    public GameObject Rock;
    public GameObject QuestionBox;
    public GameObject Stone;
    public GameObject Ethan;
    public GameObject Goal;

    public Transform parentTransform;

    void Start()
    {
        Acid = GameObject.FindGameObjectWithTag("hazard");
        RefreshParse();
    }


    private void FileParser()
    {
        string fileToParse = string.Format("{0}{1}{2}.txt", Application.dataPath, "/Resources/", filename);
        using (StreamReader sr = new StreamReader(fileToParse))
        {
            string line = "";
            int row = 0;
            while ((line = sr.ReadLine()) != null)
            {
                int column = 0;
                char[] letters = line.ToCharArray();
                foreach (var letter in letters)
                {
                    SpawnPrefab(letter, new Vector3(column, -row, -0.5f));
                    column++;
                }
                row++;

            }
            sr.Close();
        }
    }

    private void SpawnPrefab(char spot, Vector3 positionToSpawn)
    {
        GameObject ToSpawn;
        bool qb = false;

        switch (spot)
        {
            case 'b': ToSpawn = Brick; break;
            case '?': ToSpawn = QuestionBox; break;
            case 'x': ToSpawn = Rock; break;
            case 's': ToSpawn = Stone; break;
            case 'a': ToSpawn = Acid; break;
            case 'e': ToSpawn = Ethan; break;
            case 'g': ToSpawn = Goal; break;
            default: return;
        }
        ToSpawn = GameObject.Instantiate(ToSpawn, parentTransform);
        if (qb == true)
        {
            positionToSpawn.z = -1f;
        }
        ToSpawn.transform.localPosition = positionToSpawn;
    }

    public void RefreshParse()
    {
        GameObject newParent = new GameObject();
        newParent.name = "Environment";
        newParent.transform.position = parentTransform.position;
        newParent.transform.parent = this.transform;

        if (parentTransform) Destroy(parentTransform.gameObject);

        parentTransform = newParent.transform;
        FileParser();
    }
}