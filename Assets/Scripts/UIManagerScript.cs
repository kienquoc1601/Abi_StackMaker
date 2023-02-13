using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using TMPro;
public class UIManagerScript : MonoBehaviour
{
    public static UIManagerScript Instance;
    public GameObject canvas;
    public GameObject nextButton;
    public GameObject retryButton;
    public GameObject text;

    public TMP_Text _text;

    private void Awake()
    {
        Instance = this;
    }
    void Start()
    {
        canvas = this.gameObject.transform.GetChild(0).gameObject;
        canvas.SetActive(false);
        nextButton = canvas.gameObject.transform.GetChild(0).gameObject;
        retryButton = canvas.gameObject.transform.GetChild(1).gameObject;
        text = canvas.gameObject.transform.GetChild(2).gameObject;
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void ShowFinishMenu(int score)
    {
        canvas.SetActive(true);
        nextButton.SetActive(true);

    }
    public void ShowLoseMenu()
    {
        canvas.SetActive(true);
        nextButton.SetActive(false);

    }

    public void NextLevel()
    {
        GameManager.Instance.NextLevel();
    }
    public void Retry()
    {
        GameManager.Instance.RetryLevel();
    }
}
