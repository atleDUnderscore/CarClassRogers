using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CarScript : MonoBehaviour
{
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


        public void Accel()
        {
            currentSpeed += .1f;

        }

        public void Decel()
        {
            currentSpeed -= .1f;
        }

        public void ReadCar()
        {
            Debug.Log(Year + " " + Make);
        }

        public void Hundred()
        {
            currentSpeed = maxSpeed;
        }

        public void Zero()
        {
            currentSpeed = minSpeed;
        }

    }


    [SerializeField] Car car = new Car();
    [SerializeField] TMP_Text cSpeed;
    [SerializeField] TMP_Text cYearMake;
    [SerializeField] int inputYear;
    [SerializeField] GameObject menuCar;
    [SerializeField] GameObject gameHolder;
    [SerializeField] GameObject menuHolder;
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
    }

    void Update()
    {
        if(Input.GetKey(KeyCode.UpArrow) && car.CurrentSpeed < 100f && canPlay)
        {
            car.Accel();

            

        }
        if(Input.GetKey(KeyCode.DownArrow) && car.CurrentSpeed > 0 && canPlay)
        {
            car.Decel();


        }
        if(car.CurrentSpeed > 100)
        {
            car.Hundred();
        }
        if (car.CurrentSpeed < 0)
        {
            car.Zero();
        }
        if(yearBool && makeBool)
        {
            canPlay = true;
            menuHolder.SetActive(false);
            gameHolder.SetActive(true);
        }
        menuCar.transform.Rotate(0, .1f, 0);
        
        cSpeed.text = car.CurrentSpeed.ToString("0") + " MPH";
    }


    public void OnChangeYear(string input)
    {
        int.TryParse(input, out inputYear);
        if(1886 < inputYear && inputYear < 2025)
        {
            car.Year = inputYear;
            Debug.Log("This Year is Correct");
            Debug.Log(car.Year);
            yearBool = true;
            cYearMake.text = car.Year.ToString() + " " + car.Make;
        }
        else
        {
            Debug.Log("This Year Aint Right >:(");
            yearBool= false;
        }

    }

    public void OnChangeMake(string input)
    {
        car.Make = input;
        if(input != null)
        {
            makeBool = true;
            cYearMake.text = car.Year.ToString() + " " + car.Make;
        }
    }

    public void ChangeYear()
    {
        /*int newYear = Random.Range(1885, 2024);
        car.Year = newYear;
        Debug.Log(newYear);
        car.Make = "Bolksbagen";*/
        Debug.Log(car.Year + " " + car.Make);
        cYearMake.text = car.Year.ToString() + " " + car.Make;
    }

    public void StartButton()
    {
        if(makeBool && yearBool)
        {
            Debug.Log("Game Would have Started");
        }
        else
        {
            Debug.Log("No can do sweetheart");
        }
    }

    /*public IEnumerator DelaySeconds(int i)
    {
        if(i == 1)
        {
            yield return new WaitForSeconds(.25f);
        }
    }*/


}
