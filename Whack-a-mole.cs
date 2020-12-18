using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UpDownGame : MonoBehaviour
{
    public GameObject[] monsters;
    public GameObject[] penguins;
    private int previous;
    public int current;
    public int score;
    public Text ScoreT;
    private float timer;
    private float gametimer;
    public Text gtime;
    private bool start;
    public Text rules;
    

    private void Start()
    {

        score = 0;
        ScoreT.text = "Press x to start \nPress u to end game";
        rules.text = "WASD to move \nPress E to hit mosters\nPress R to hug Penguins";
        previous = 0;
        current = 0;
        timer = 0f;
        gametimer = 0f;
        start = false;
        gtime.text = "";
        
        
    }


    private void FixedUpdate()
    {
        timer += Time.fixedDeltaTime;
        if (start) { 
            WhackAmole();
            gametimer += Time.fixedDeltaTime;
            gtime.text = gametimer.ToString().Remove(4);
            rules.text = "";
        }
     }

    private void WhackAmole()
    {
        
        if(timer >= 4) 
        { 
            timer = 0; 
            NewMummy(); 
        }
        if(gametimer >= 50)
        {
            EndGame();
        }
    }
    public void NewMummy()
    {
        monsters[current].SetActive(false);
        penguins[current].SetActive(false);
        int i = Random.Range(1, 3);
        
        if(i == 1)//mummy
        {
            previous = current;
            current = Random.Range(0, 9);
            if (current == previous)
            {
                current = previous + 5;
                if (current > 8 || current < 0)
                {
                    current = 6;
                }
            }
            monsters[current].SetActive(true);
        }
        
        if( i == 2) //penguin
        {
            previous = current;
            current = Random.Range(0, 9);
            if (current == previous)
            {
                current = previous + 5;
                if (current > 8 || current < 0)
                {
                    current = 6;
                }
            }
            penguins[current].SetActive(true);
        }
        
        

    }
    public void Score()
    {
        score += 10;
        ScoreT.text = "Score: " + score;
    }
    public void MinusScore()
    {
        score -= 10;
        ScoreT.text = "Score: " + score;
    }

   
    public void EndGame()
    {
        start = false;
        ScoreT.text = "Final Score: " + score;
        gtime.text = "Press x to start again";
        rules.text = "WASD to move \nPress E to hit mosters\nPress R to hug Penguins";
        for (int i = 0; i < 10; ++i)
        {
            monsters[i].SetActive(false);
            penguins[i].SetActive(false);
        }
        gametimer = 0;
    }

    public void StartGame()
    {
        start = true;
        score = 0;
        ScoreT.text = "Score: 0";
        rules.text = "";
        gametimer = 0;
    }

}

