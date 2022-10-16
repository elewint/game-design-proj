using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameController : MonoBehaviour
{
    public TextMeshProUGUI scoreText;
    public GameObject sunObject;
    public Camera mainCamera;
    public GameObject SpawnParent;

    private int score = 0;
    private Light sun;
    
    private float time = 0f;
    private float dayLength = 5f;
    private float nightLength = 5f;
    private bool nightTime = false;
    
    private void Start()
    {
        sun = sunObject.GetComponent<Light>();
    }
    
    private void Update()
    {
        if (time > dayLength && !nightTime)
        {
            nightTime = true;
            nightTransition();
        }
        else if (time > dayLength + nightLength)
        {
            nightTime = false;
            dayTransition();
            time = 0f;
        }
        else
        {
            time += Time.deltaTime;
            Quaternion sunRotation = Quaternion.Euler(360 * (time / (dayLength + nightLength)), 0, 0);
            // sunObject.transform.(Vector3.left * (360f / dayLength + nightLength));
            sunObject.transform.rotation = sunRotation;
        }

        // Move the sun
        // Check for nighttime
        // If nighttime, don't move sun
    }
    
    public void incrementScore()
    {
        score++;
        scoreText.text = "Score: " + score.ToString();
    }

    private void nightTransition()
    {
        Debug.Log("It's nighttime!");
        sun.color = Color.red;
        
    }
    
    private void dayTransition()
    {
        Debug.Log("It's daytime!");
        sun.color = new Color(1, 0.9568627f, 0.8392157f);
    }
}
