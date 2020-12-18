using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class PlayerCollision : MonoBehaviour
{
    public UpDownGame game;
    private bool e_press;
    private bool r_press;
    


    private void Start()
    {
        e_press = false;
        r_press = false;
    }

    private void Update()
    {
        if (Input.GetKey(KeyCode.E)) 
        { 
            e_press = true; 
        }
        else 
        {
            e_press = false; 
        }
        if (Input.GetKeyDown(KeyCode.U)) 
        {
            game.EndGame(); 
        }
       
        if (Input.GetKeyDown(KeyCode.X)) 
        {
            game.StartGame();
        
        }
        if (Input.GetKey(KeyCode.R))
        {
            r_press = true;
        }
        else
        {
            r_press = false;
        }

    }

    private void FixedUpdate()
    {
        
       
    }

    private void OnTriggerStay(Collider other)
    {
        int num = other.name[9] - 48;
        if (e_press && game.current == num) 
        {
            game.Score();
            game.NewMummy();
        }
        if (r_press && game.current == num)
        {
            game.MinusScore();
            game.NewMummy();
        }
    }
}
