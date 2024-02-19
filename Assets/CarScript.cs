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
                return 2004;
            }
            set{
                year = value;
            }
        }

        public string Make
        {
            get { 
                return "one of the cars of all time";
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
            currentSpeed = 100;
        }

        public void Zero()
        {
            currentSpeed = 0;
        }

    }


    [SerializeField] Car car = new Car();
    [SerializeField] TMP_Text cSpeed;

    void Start()
    {
        car.ReadCar();
    }

    void Update()
    {
        if(Input.GetKey(KeyCode.UpArrow) && car.CurrentSpeed < 100f)
        {
            car.Accel();

            

        }
        if(Input.GetKey(KeyCode.DownArrow) && car.CurrentSpeed > 0)
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
        
        cSpeed.text = car.CurrentSpeed.ToString("0");
    }


    public void OnChangeYear(int inputYear)
    {
        if(1886 < inputYear && inputYear < 2024)
        {
            car.Year = inputYear;
            Debug.Log("This Year is Correct");
        }
        else
        {
            Debug.Log("This Year Aint Right >:(");
        }

    }

    public void ChangeYear()
    {
        car.Year = 2007;
        car.Make = "Bolksbagen";
        Debug.Log(car.Year + " " + car.Make);
    }

    /*public IEnumerator DelaySeconds(int i)
    {
        if(i == 1)
        {
            yield return new WaitForSeconds(.25f);
        }
    }*/


}
