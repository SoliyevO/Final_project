using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{

    [Header("Timer")]
    public float countDownTimer = 5f;

    [Header("Things to stop")]
    public PlayerCarController playerCarController;
    public OpponentCar opponentCar1;
    public OpponentCar opponentCar2;

    public Text countDownText;





    void Start()
    {
        StartCoroutine(TimeCount());
    }

    // Update is called once per frame
    void Update()
    {
        if(countDownTimer > 1)
        {
            playerCarController.accelerationForce = 0f;
            opponentCar1.movingSpeed = 0f;
            opponentCar2.movingSpeed = 0f;
        }
        else if(countDownTimer == 0)
        {
            playerCarController.accelerationForce = 300f;
            opponentCar1.movingSpeed = 8f;
            opponentCar2.movingSpeed = 7f;
        }
    }


    IEnumerator TimeCount()
    {
        while(countDownTimer>0)
        {
            countDownText.text = countDownTimer.ToString();
            yield return new WaitForSeconds(1f);
            countDownTimer--;
        }
        countDownText.text = "GO";
        yield return new WaitForSeconds(1f);
        countDownText.gameObject.SetActive(false);
    }
}
