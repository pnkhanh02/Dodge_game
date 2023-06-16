using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{

    public GameObject pnlEndGame;
    public Button btnRestart;
    public Sprite btnIdle;
    public Sprite btnHover;
    public Sprite btnClick;
    public Text txtPoint;
    private int gamePoint;
    AudioSource audio;

    // Start is called before the first frame update
    void Start()
    {
        Time.timeScale = 1;
        pnlEndGame.SetActive(false);
        audio = gameObject.GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void GetPoint()
    {
        //tang diem va hien thi trong txtPoint
        gamePoint++;
        txtPoint.text = "Point: " + gamePoint.ToString();
    }

    //trang thai di chuot
    public void ButtonHover()
    {
        btnRestart.GetComponent<Image>().sprite = btnHover;
    }

    //trang thai khong hoat dong
    public void ButtonIdle()
    {
        btnRestart.GetComponent<Image>().sprite = btnIdle;
    }

    //trang thai click chuot
    public void ButtonClick()
    {
        btnRestart.GetComponent<Image>().sprite = btnClick;
    }

    //bat dau tro choi
    public void StartGame()
    {
        SceneManager.LoadScene(0);
    }

    //ket thuc tro choi
    public void EndGame()
    {
        audio.Play();
        Time.timeScale = 0;
        //hien thi ket thuc tro choi
        pnlEndGame.SetActive(true);
    }

}
