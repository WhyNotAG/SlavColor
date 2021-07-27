using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private int speed;
    
    void Start()
    {
        speed = 8;
    }

    // Update is called once per frame
    void Update()
    {
        float inputX = Input.GetAxis("Horizontal");
        float inputY = Input.GetAxis("Vertical");

        Vector3 movement = new Vector3(inputX * speed, inputY * speed, 0.0f);
        movement = Vector3.ClampMagnitude(movement, speed); //ограничение скорости по диагонали
        movement = transform.TransformDirection(movement); //преобразование к глобальным координатам
        movement *= Time.deltaTime;
        
        transform.Translate(movement);
    }
}
