using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameMng : MonoBehaviour
{
    public GameObject redVirus;
    public GameObject greenVirus;
    public GameObject blueVirus;

    public GameObject medkit;

    public TextMeshProUGUI healthText;
    public TextMeshProUGUI scoreText;

    public static int health;
    public static int score;
    public static int grannyScore;

    public float timer = 4.0f;

    public GameObject gameOverPanel;

    public Canvas canvas;

    bool isGameEnded = false;

    // Start is called before the first frame update
    void Awake()
    {
        health = 3;
        score = 0;
    }

    // Update is called once per frame
    void Update()
    {
        healthText.text = "Health: " + health.ToString();
        scoreText.text = "Score: " + grannyScore.ToString();

        timer -= Time.deltaTime;
        if (timer <= 0f)
        {
            Instantiate(redVirus, new Vector2(Random.Range(-33.0f, 40.0f), Random.Range(-17.0f, 14.0f)), Quaternion.identity);
            Instantiate(blueVirus, new Vector2(Random.Range(-33.0f, 40.0f), Random.Range(-17.0f, 14.0f)), Quaternion.identity);
            Instantiate(greenVirus, new Vector2(Random.Range(-33.0f, 40.0f), Random.Range(-17.0f, 14.0f)), Quaternion.identity);
            Instantiate(medkit, new Vector2(Random.Range(-33.0f, 40.0f), Random.Range(-17.0f, 14.0f)), Quaternion.identity);
            timer = 4.0f;
        }

        if (health <= 0 && isGameEnded == false)
        {
            isGameEnded = true;
            StartCoroutine(EndTheGame());
        }
    }

    private IEnumerator EndTheGame()
    {
        gameOverPanel.GetComponentInChildren<TextMeshProUGUI>().text = "Score: " + grannyScore.ToString();
        Instantiate(gameOverPanel, new Vector3(960, 540, 0), Quaternion.identity, canvas.transform);

        yield return new WaitForSeconds(5);

        SceneManager.LoadScene(0);
    }
}
