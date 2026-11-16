using System;
using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    private int count;
    private int maxCount;
    private GameObject[] pickUps;
    private bool timeEnd, stopCount;
    private PlayerControllerScript playerController;
    private AudioSource audioPlayer;
    [SerializeField]
    private TextMeshProUGUI countText, timeText, infoText;
    [SerializeField]
    private string[] infoTexts;
    [SerializeField]
    private AudioClip[] endSounds;

    [SerializeField]
    private float time;
    [SerializeField]
    private GameObject restartButton;
    void Start()
    {
        count=0;
        countText.text = "Count:0";
        pickUps = GameObject.FindGameObjectsWithTag("Pickup");
        maxCount = pickUps.Length;
        Debug.Log(maxCount);
        infoText.text = "";
        playerController = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerControllerScript>();
        audioPlayer = GetComponent<AudioSource>();
        restartButton.SetActive(false);
    }

    void Update()
    {
        if(time >=0f && !timeEnd)
        {
            time-=Time.deltaTime;
        }
        else if(time <=0f && !timeEnd)
        {
            GameEnd(1, false);
        }
        // timeText.text = time.ToString();
        var ts = TimeSpan.FromSeconds(time);
        timeText.text = string.Format("{0:00}m:{1:00}s", ts.Minutes, ts.Seconds);
    }
    public void Count()
     {
        if(!stopCount)
        {
            count ++;
        if (count == maxCount)
        {
            GameEnd(0, true);
        }
        }
        
        countText.text = "Count:" + count.ToString(); 
           
    }

    private void GameEnd (int InfoIndex, bool won)
    {
        infoText.text = infoTexts[InfoIndex].ToString();
        timeEnd = true;
        stopCount = true;
        playerController.enabled = false;
        if (won)
        {
            audioPlayer.clip = endSounds[0];
        }
        else
        {
            audioPlayer.clip = endSounds[1];
        }
        audioPlayer.Play();

        StartCoroutine(ShowRestartButton());
    }

    IEnumerator ShowRestartButton()
    {
        yield return new WaitForSeconds(5f);
        restartButton.SetActive(true);
        infoText.text="";
    }

    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
