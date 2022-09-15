using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarController : MonoBehaviour
{
    [SerializeField] float carSpeed;
    [SerializeField] float maxSpeed;
    [SerializeField] float steerAngle;
    public Transform lw, rw;
    private float dragAmount = 0.91f;
    Vector3 rotVec;
    Vector3 moveVec;


    
    void Start()
    {
        
    }

    
    void FixedUpdate()
    {
        moveVec += transform.forward * carSpeed * Time.deltaTime;
        transform.position += moveVec * Time.deltaTime; // "transform.translate +=" de kullanılabilir.

        rotVec += new Vector3(0, Input.GetAxis("Horizontal"), 0);

        transform.Rotate(Vector3.up * Input.GetAxis("Horizontal") * steerAngle * moveVec.magnitude * Time.deltaTime);

        moveVec *= dragAmount;
        moveVec = Vector3.ClampMagnitude(moveVec, maxSpeed);
        rotVec = Vector3.ClampMagnitude(rotVec, steerAngle);

        lw.localRotation = Quaternion.Euler(rotVec);
        rw.localRotation = Quaternion.Euler(rotVec);
    }


    private void OnTriggerEnter(Collider collider)
    {
        if(collider.gameObject.tag == "Coin") //Coin toplama kodu
        {
            PuanText.coinMiktar += 1;
            Destroy(collider.gameObject);
        }

        if(collider.gameObject.tag == "Engel") //Engele çarpma kodu oyunu durdurur
        {
            Time.timeScale = 0f;
        }
    }
}
