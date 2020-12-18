using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class UpDown : MonoBehaviour
{
    public struct Rat {
        public GameObject mon;
        public bool isUp;
        };

    public Rat mum1;
    public Rat mum2;
    public Rat mum3;
    public Rat peng1;
    public Rat peng2;
    public Rat peng3;
    GameObject[] array = new GameObject[5];
    int milliseconds = 1500;
    public GameObject mon1; public GameObject mon2; public GameObject mon3; 
    //public GameObject pmon1; public GameObject pmon2; public GameObject pmon3;
    //public GameObject mon1; public GameObject mon1; public GameObject mon1;


    //adjust this to change speed
    public float speed = 5f;
    //adjust this to change how high it goes
    public float height = 0.5f;

    Vector3 initialHeight;

    private void Start()
    {
        
        
       // mum1.mon = mon1; mum2.mon = mon2; mum3.mon = mon3;
       // peng1.mon = pmon1; peng2.mon = pmon2; peng2.mon = pmon2;
       

        array[1] = mon1;
        initialHeight = array[1].transform.localPosition;
        array[2] = mon2; array[3] = mon3; 
        //array[4] = peng2; array[5] = peng3;
    }
    void Update()
    {
      


            //calculate what the new Y position will be
            float newY = Mathf.Sin(Time.time * speed) * height + initialHeight.y - 34;
            //set the object's Y to the new calculated Y
            
        
            array[2].transform.position = new Vector3(array[2].transform.position.x, newY, array[2].transform.position.z);
            Thread.Sleep(milliseconds);
        
            
        
    }
}
