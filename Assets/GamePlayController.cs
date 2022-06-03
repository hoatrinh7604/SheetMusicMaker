using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GamePlayController : MonoBehaviour
{
    public static GamePlayController Instance { get; private set; }
    private void Awake()
    {
        if(Instance != null && Instance != this)
        {
            Destroy(this.gameObject);
        }
        else
        {
            Instance = this;
        }
    }

    [SerializeField] float score;
    [SerializeField] float highscore;
    public Color[] template = { new Color32(255, 81, 81, 255), new Color32(255, 129, 82, 255), new Color32(255, 233, 82, 255), new Color32(163, 255, 82, 255), new Color32(82, 207, 255, 255), new Color32(170, 82, 255, 255) };

    private UIController uiController;

    private float time;
    [SerializeField] float timeOfGame;

    [SerializeField] List<GameObject> currentListNote;
    [SerializeField] GameObject[] listButtons;
    [SerializeField] int numBaseNote;
    [SerializeField] int rightButtonIndex;

    // Start is called before the first frame update
    void Start()
    {
        uiController = GetComponent<UIController>();
        Reset();
    }

    private void Update()
    {
        time -= Time.deltaTime;
        UpdateSlider();

        if(time < 0)
        {
            GameOver();
        }
    }

    public void AddNewNote(GameObject newNote)
    {
        currentListNote.Add(newNote);
        if(currentListNote.Count == 1)
        {
            SwitchToNewNote();
        }
    }

    public void OnPress(int index)
    {
        if (currentListNote.Count == 0) return;
        if (rightButtonIndex == index)
        {
            UpdateScore(1);
            DeleteTheFirstNote();
            SwitchToNewNote();
        }
        else
        {
            GameOver();
        }
    }

    public void DeleteTheFirstNote()
    {
        if (currentListNote.Count > 0)
        {
            GameObject obj = currentListNote[0];
            currentListNote.RemoveAt(0);
            Destroy(obj);
        }
    }

    public void SwitchToNewNote()
    {
        if(currentListNote.Count == 0)
        {
            for (int i = 0; i < listButtons.Length; i++)
            {
                listButtons[i].GetComponent<ButtonController>().SetInfo();
            }
            return;
        }

        rightButtonIndex = Random.Range(0, listButtons.Length);

        for(int i = 0; i < listButtons.Length; i++)
        {
            int index0 = currentListNote[0].GetComponent<SawController>().GetIndex();
            if (i == rightButtonIndex)
            {
                listButtons[i].GetComponent<ButtonController>().SetInfo(index0);
            }
            else
            {
                int index = Random.Range(0, numBaseNote);
                while(index == index0)
                {
                    index = Random.Range(0, numBaseNote);
                }
                listButtons[i].GetComponent<ButtonController>().SetInfo(index);
            }
        }
    }

    public void UpdateButtonForNote(int index)
    {

    }


    public void UpdateSlider()
    {
        uiController.UpdateSlider(time);
    }

    public void SetSlider()
    {
        uiController.SetSlider(timeOfGame);
    }

    public void IncreaseTime(float value)
    {
        time += value;
        if(time > timeOfGame)
            time = timeOfGame;
    }

    public void DecreaseTime()
    {
        time -= 1;
    }

    public void GameOver()
    {
        Time.timeScale = 0;
        uiController.GameOver();
    }

    public void UpdateScore(int value)
    {
        score += value;
        if(highscore < score)
        {
            highscore = score;
            PlayerPrefs.SetFloat("score", highscore);
            uiController.UpdateHighScore(highscore);
        }
        uiController.UpdateScore(score);
    }


    public void Reset()
    {
        Time.timeScale = 1;
        rightButtonIndex = 0;
        currentListNote = new List<GameObject>();

        time = timeOfGame;
        SetSlider();
        score = 0;
        highscore = PlayerPrefs.GetFloat("score");
        uiController.UpdateHighScore(highscore);
        uiController.UpdateScore(score);

        //NextLevel();
        //uiController.UpdateHighScore(highscore);
    }

}
