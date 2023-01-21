using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CodingClear : MonoBehaviour
{
    public GameObject[] stars;
    public GameObject scoreCanvas;
    private int score;
    public static int deduct;

    // Start is called before the first frame update
    void Start()
    {
        score = 100;
        deduct = 0;
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void ScoreComputation()
    {
        int scoreDeduct = deduct;
        scoreDeduct *= 5;
        score -= scoreDeduct;

        scoreCanvas.SetActive(true);

        if (score > 95)
        {
            //three stars
            stars[0].SetActive(true);
            stars[1].SetActive(true);
            stars[2].SetActive(true);
        }
        else if (score <= 95 && score >= 50)
        {
            //two stars
            stars[0].SetActive(true);
            stars[1].SetActive(true);
        }
        else if (score < 50 && score >= 10)
        {
            //one star
            stars[0].SetActive(true);
        }
        else
        {
            //no stars
        }

    }
}
