using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class KnifeSpawner : MonoBehaviour
{
    public Transform spawnPoint;
    public GameObject knifePrefab;

    private Text scoreText;
    private int score;

    // Start is called before the first frame update
    void Awake()
    {
        scoreText = GameObject.Find("Score Text").GetComponent<Text>();
    }

    public void SpawnKnife()
    {
        GameObject go = Instantiate(knifePrefab, spawnPoint.position, spawnPoint.rotation);
        go.transform.parent = spawnPoint;
    }

    public void IncrementScore()
    {
        score += 5;
        scoreText.text = score.ToString();
    }
}
