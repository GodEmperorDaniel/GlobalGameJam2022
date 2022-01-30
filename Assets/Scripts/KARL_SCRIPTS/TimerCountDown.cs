using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class TimerCountDown : MonoBehaviour
{
    public PresentWinner presentWinner;
    [Header("Countdown Starter: ")]
    public int countDownTime;
    public Text countDownDisplay;

    private float currentTime = 0f;
    private bool startTimer;

    [Header("Countdown Timer: ")]
    public float startingTime = 10f;
    [SerializeField] Text counterText;

    private void Start()
    {
        StartCoroutine(CountTimeToStart());
        currentTime = startingTime;
    }
    private void Update()
    {
        if (startTimer)
        {
            currentTime -= 1 * Time.deltaTime;
            counterText.text = currentTime.ToString();
            if (currentTime <= 0)
            {
                currentTime = 0;
                //KAlla på den som vann
                presentWinner.CheckForWinner();
            }
        }
        
    }

    IEnumerator CountTimeToStart()
    {
        while (countDownTime > 0)
        {
            countDownDisplay.text = countDownTime.ToString();

            yield return new WaitForSeconds(1f);

            countDownTime--;
        }

        countDownDisplay.text = "GO!";

        //Pausa spelet

        yield return new WaitForSeconds(1f);

        countDownDisplay.gameObject.SetActive(false);

        UIManager.UI.ChangeActionMapCharacterInput();

        startTimer = true;
    }

}
