using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour
{
    public int score;
    [SerializeField] private Text scoreText;
    // Start is called before the first frame update
    void Awake()
    {
        scoreText = GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        score = GameManager.instance.score;
        scoreText.text = score.ToString();

        
    }

    
}
