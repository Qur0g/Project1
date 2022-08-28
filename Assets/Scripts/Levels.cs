using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Levels : MonoBehaviour
{
    [SerializeField]
    private GameObject levelPrefab;

    private TMPro.TextMeshProUGUI textPrefab;

    void Start()
    {
        textPrefab = levelPrefab.GetComponentInChildren<TMPro.TextMeshProUGUI>();
        levelPrefab.GetComponent<Image>().color = Color.green;

        Create();
    }

    private void Create()
    {
       int doneLevels = PlayerPrefs.GetInt("doneLevels", 0);

        float x = -2f;
        float y = 3.5f;

        for (int i = 0; i < doneLevels; i++)
        {
            textPrefab.text = (i + 1).ToString();

            Instantiate(levelPrefab, new Vector3(x, y, 0), Quaternion.identity, gameObject.transform);
            x += 0.825f;

            if(x >= 1.5)
            {
                x = -2f;
                y -= 0.9f;
            }           
        }

        textPrefab.text = (doneLevels + 1).ToString();
        levelPrefab.GetComponent<Image>().color = Color.gray;

        Instantiate(levelPrefab, new Vector3(x, y, 0), Quaternion.identity, gameObject.transform);
    }
}
