using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{  
    [SerializeField]
    private GameObject Lose, Win;

    private GameObject[] levelObjects;
    private BoxCollider2D[] levelColliders;
    private SpriteRenderer[] levelSprites;

    private AudioSource audioSource;
    private SoundManager soundManager;

    private int countBlocks;
    private int index = 0;
    private int doneLevels;

    void Start()
    {
        doneLevels = PlayerPrefs.GetInt("doneLevels", 0);

        levelObjects = GameObject.FindGameObjectsWithTag("LevelElement");
        countBlocks = levelObjects.Length;

        levelColliders = new BoxCollider2D[countBlocks];
        levelSprites = new SpriteRenderer[countBlocks];

        for (int i = 0; i < countBlocks; i++)
        {
            levelColliders[i] = levelObjects[i].GetComponent<BoxCollider2D>();
            levelColliders[i].enabled = false;

            levelSprites[i] = levelObjects[i].GetComponent<SpriteRenderer>();
        }

        audioSource = GameObject.Find("SoundManager").GetComponent<AudioSource>();
        soundManager = GameObject.Find("SoundManager").GetComponent<SoundManager>();

        StartCoroutine(nameof(PlayOrder));
    }

    IEnumerator PlayOrder()
    {
        levelObjects[0].GetComponent<Animator>().enabled = false;

        for (int i = 0; i < countBlocks; i++)
        {
            yield return new WaitForSeconds(0.5f);

            levelColliders[i].enabled = true;
            levelSprites[i].color = Color.Lerp(Color.yellow, new Color32(0, 173, 84, 255), (float)i / countBlocks);
            levelColliders[i].enabled = false;

            audioSource.PlayOneShot(audioSource.clip);
        }

        yield return new WaitForSeconds(0.5f);

        for (int i = 0; i < countBlocks; i++)
        {
            levelColliders[i].enabled = true;
            levelSprites[i].color = Color.white;
        }

        levelObjects[0].GetComponent<Animator>().enabled = true;
    }

    public void CheckOrder(GameObject obj)
    {
        if (obj == levelObjects[index])
        {
            audioSource.PlayOneShot(soundManager.goodClick);

            if (index == 0)
            {
                obj.GetComponent<Animator>().enabled = false;
            }

            obj.GetComponent<SpriteRenderer>().color = Color.Lerp(Color.yellow, new Color32(0, 173, 84, 255), (float)index / countBlocks);
            obj.GetComponent<BoxCollider2D>().enabled = false;
            index++;
        }
        else
        {
            audioSource.PlayOneShot(soundManager.loseSound);

            GameObject.Find("PostProcessing").GetComponent<PostProcessingController>().SettingsToogle(true);

            obj.GetComponent<SpriteRenderer>().color = Color.red;

            Lose.GetComponentInChildren<Canvas>().worldCamera = Camera.main;
            Instantiate(Lose, new Vector3(0, 0, 0), Quaternion.identity); 

            for(int i = 0; i < countBlocks; i++)
            {
                levelColliders[i].enabled = false;
            }
        }

        if(index == countBlocks)
        {
            audioSource.PlayOneShot(soundManager.winSound);

            GameObject.Find("PostProcessing").GetComponent<PostProcessingController>().SettingsToogle(true);

            Win.GetComponentInChildren<Canvas>().worldCamera = Camera.main;
            Instantiate(Win, new Vector3(0, 0, 0), Quaternion.identity);

            for (int i = 0; i < countBlocks; i++)
            {
                levelColliders[i].enabled = false;
            }

            if (SceneManager.GetActiveScene().buildIndex - doneLevels == 2)
            {
                doneLevels++;
            }
        }  
    }

    private void OnDestroy()
    {
        PlayerPrefs.SetInt("doneLevels", doneLevels);
    }
}
