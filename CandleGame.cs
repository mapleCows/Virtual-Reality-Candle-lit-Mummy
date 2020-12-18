using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CandleGame : MonoBehaviour
{
    public Light RedCandle;
    public Light GreenCandle;
    public Light BlueCandle;
    public Text CandleScore;
    Color colorR = Color.red; // Red - 1
    Color colorG = Color.green; // Green - 2
    Color colorB = Color.blue; // Blue - 3
    private double timer;
    private bool gameFinished;
    private int randColor;
    private int roundNum;
    List<int> ColorList;
    private bool rPressed;
    private bool gPressed;
    private bool bPressed;
    private int currScore;

    private void Start()
    {
        RedCandle.color = colorR;
        GreenCandle.color = colorG;
        BlueCandle.color = colorB;
        RedCandle.intensity = 0.0f;
        GreenCandle.intensity = 0.0f;
        BlueCandle.intensity = 0.0f;

        gameFinished = false;
        timer = 0.0;
        randColor = 1;
        roundNum = 1;
        currScore = 0;

        rPressed = false;
        gPressed = false;
        bPressed = false;

        ColorList = new List<int>();
    }

    private void Update()
    {
        timer += Time.fixedDeltaTime;
        if (Input.GetKeyDown("c"))
        {
            gameStart();
        }
        if (Input.GetKeyDown("r"))
        {
            rPressed = true;
            gPressed = false;
            bPressed = false;
        }
        if (Input.GetKeyDown("g"))
        {
            rPressed = false;
            gPressed = true;
            bPressed = false;
        }
        if (Input.GetKeyDown("b"))
        {
            rPressed = false;
            gPressed = false;
            bPressed = true;
        }
    }

    private void gameStart()
    {
        StartCoroutine(candleGame());
    }

    private IEnumerator candleGame()
    {
        while (!gameFinished)
        {
            CandleScore.text = "Round " + roundNum.ToString() + "\n";
            CandleScore.text = CandleScore.text + "Score: " + currScore.ToString();
            randColor = Random.Range(1, 4);
            if (randColor == 1)
            {
                ColorList.Add(1);
            }
            else if (randColor == 2)
            {
                ColorList.Add(2);
            }
            else if (randColor == 3)
            {
                ColorList.Add(3);
            }

            StartCoroutine(ColorDisplayer());

            if (roundNum == 10)
            {
                gameFinished = true;
            }
            roundNum = roundNum + 1;
            StartCoroutine(TestUser());
            yield return new WaitForSeconds((roundNum * 3) + 1);
        }
    }

    private IEnumerator ColorDisplayer()
    {
        foreach (char ColorTemp in ColorList)
        {
            if (ColorTemp == 1)
            {
                StartCoroutine(RedWaiter());
                yield return new WaitForSeconds(1);
            }
            else if (ColorTemp == 2)
            {
                StartCoroutine(GreenWaiter());
                yield return new WaitForSeconds(1);
            }
            else
            {
                StartCoroutine(BlueWaiter());
                yield return new WaitForSeconds(1);
            }
            yield return new WaitForSeconds(2);
        }
    }

    private IEnumerator RedWaiter()
    {
        RedCandle.intensity = 5.0f;
        yield return new WaitForSeconds(1);
        RedCandle.intensity = 0.0f;
        yield return new WaitForSeconds(1);
    }

    private IEnumerator GreenWaiter()
    {
        GreenCandle.intensity = 5.0f;
        yield return new WaitForSeconds(1);
        GreenCandle.intensity = 0.0f;
        yield return new WaitForSeconds(1);
    }

    private IEnumerator BlueWaiter()
    {
        BlueCandle.intensity = 8.0f;
        yield return new WaitForSeconds(1);
        BlueCandle.intensity = 0.0f;
        yield return new WaitForSeconds(1);
    }

    private IEnumerator TestUser()
    {
        foreach (int listChars in ColorList)
        {
            if (listChars == 1)
            {
                if (rPressed)
                {
                    currScore = currScore + 1;
                    CandleScore.text = CandleScore.text + currScore.ToString();
                }
            }
            else if (listChars == 2)
            {
                if (gPressed)
                {
                    currScore = currScore + 1;
                    CandleScore.text = CandleScore.text + currScore.ToString();
                }
            }
            else
            {
                if (bPressed)
                {
                    currScore = currScore + 1;
                    CandleScore.text = CandleScore.text + currScore.ToString();
                }
            }
            yield return new WaitForSeconds(1);
        }
    }
}