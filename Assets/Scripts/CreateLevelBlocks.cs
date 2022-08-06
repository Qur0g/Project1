using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CreateLevelBlocks : MonoBehaviour
{
    private GameObject Levels;
    [SerializeField]
    private GameObject levelPrefab;

    void Start()
    {
        //int doneLevels = GameManager.doneLevels;
        int doneLevels = PlayerPrefs.GetInt("doneLevels", 0);

        Levels = GameObject.Find("Levels");
        TMPro.TextMeshProUGUI textPrefab = levelPrefab.GetComponentInChildren<TMPro.TextMeshProUGUI>();
        levelPrefab.GetComponent<Image>().color = Color.green;

        float x = -2f;
        float y = 3.5f;

        for(int i = 0; i < doneLevels; i++)
        {
            textPrefab.text = (i + 1).ToString();

            Instantiate(levelPrefab, new Vector3(x, y, 0), Quaternion.identity, Levels.transform);

            x += 0.75f;
            //y = y;   
        }

        textPrefab.text = (doneLevels + 1).ToString();
        levelPrefab.GetComponent<Image>().color = Color.gray;

        Instantiate(levelPrefab, new Vector3(x, y, 0), Quaternion.identity, Levels.transform);
    }
}
