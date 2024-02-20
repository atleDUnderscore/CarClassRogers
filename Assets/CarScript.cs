using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CarScript : MonoBehaviour
{   //Car Class
    public class Car
    {
        private int year;
        private string make;
        int maxSpeed = 100;
        int minSpeed = 0;
        float currentSpeed;

        public int Year
        {
            get { 
                return year;
            }
            set{
                year = value;
            }
        }

        public string Make
        {
            get { 
                return make;
            }
            set{
                make = value;
            }
        }

        public float CurrentSpeed
        {
            get { return currentSpeed; }
        }

        //Adds acceleration to the car
        public void Accel()
        {
            currentSpeed += .1f;

        }
        //Decelerates the car
        public void Decel()
        {
            currentSpeed -= .1f;
        }
        //Overflow negator
        public void Hundred()
        {
            currentSpeed = maxSpeed;
        }
        //Underflow negator
        public void Zero()
        {
            currentSpeed = minSpeed;
        }

    }

    //Variables
    [SerializeField] Car car = new Car();
    [SerializeField] TMP_Text cSpeed;
    [SerializeField] TMP_Text cYearMake;
    [SerializeField] TMP_Text cGameYM;
    [SerializeField] int inputYear;
    [SerializeField] GameObject menuCar;
    [SerializeField] GameObject gameHolder;
    [SerializeField] GameObject menuHolder;
    [SerializeField] GameObject carOBJ;
    [SerializeField] GameObject failText;
    [SerializeField] GameObject sFail;
    GameObject carRef;
    CarVars carRefScript;
    bool makeBool;
    bool yearBool;
    bool canPlay;


    void Start()
    {
        cYearMake.text = "";
        canPlay = false;
        yearBool = false;
        makeBool = false;
        gameHolder.SetActive(false);
        menuHolder.SetActive(true);
        failText.SetActive(false);
        sFail.SetActive(false);
    }

    void Update()
    {
        if(Input.GetKey(KeyCode.UpArrow) && car.CurrentSpeed < 100f && canPlay)
        {
            car.Accel();
            cSpeed.text = car.CurrentSpeed.ToString("0") + " MPH";



        }
        if(Input.GetKey(KeyCode.DownArrow) && car.CurrentSpeed > 0 && canPlay)
        {
            car.Decel();
            cSpeed.text = car.CurrentSpeed.ToString("0") + " MPH";


        }
        if(car.CurrentSpeed > 100)
        {
            car.Hundred();
            cSpeed.text = car.CurrentSpeed.ToString("0") + " MPH";
        }
        if (car.CurrentSpeed < 0)
        {
            car.Zero();
            cSpeed.text = car.CurrentSpeed.ToString("0") + " MPH";
        }
        if(yearBool && makeBool)
        {
            canPlay = true;
            
        }
        menuCar.transform.Rotate(0, .1f, 0);
        
        
    }

    //Detects if the Year value changes
    public void OnChangeYear(string input)
    {
        int.TryParse(input, out inputYear);
        if(1885 < inputYear && inputYear < 2025)
        {
            car.Year = inputYear;
            Debug.Log("This Year is Correct");
            Debug.Log(car.Year);
            yearBool = true;
            cYearMake.text = car.Year.ToString() + " " + car.Make;
            failText.SetActive(false);
        }
        else
        {
            Debug.Log("This Year Aint Right >:(");
            failText.SetActive(true);
            yearBool= false;
        }

    }
    //Detects if the Make value changes
    public void OnChangeMake(string input)
    {
        car.Make = input;
        if(input != null)
        {
            makeBool = true;
            cYearMake.text = car.Year.ToString() + " " + car.Make;
        }
    }
    //Code for the start button
    public void StartButton()
    {
        if(canPlay)
        {
            cGameYM.text = car.Year.ToString() + " " + car.Make;
            carRef = Instantiate(carOBJ);
            menuHolder.SetActive(false);
            gameHolder.SetActive(true);
            carRefScript = carRef.GetComponent<CarVars>();
            carRefScript.make = car.Make;
            carRefScript.year = car.Year;
            cSpeed.text = "0 MPH";
        }
        else
        {
            sFail.SetActive(true);
        }
    }


}
