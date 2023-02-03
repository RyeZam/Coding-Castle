using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LevelMenu : MonoBehaviour
{
    public Animator anim15;
    public Animator anim610;
    public Animator anim1115;

    public GameObject rightBtn;
    public GameObject leftBtn;

    int pageNum;

    private void Start()
    {
        FindObjectOfType<AudioManager>().Play("Level");
        pageNum = 1;
        leftBtn.SetActive(false);
    }

    public void goRight()
    {
        leftBtn.SetActive(true);

        if (pageNum == 1)
        {
            anim15.SetBool("isLeft", true);
            anim15.SetBool("isIn", false);
            anim610.SetBool("isIn", true);
            anim610.SetBool("isRight", false);
            pageNum += 1;
        }
        else if (pageNum == 2)
        {
            anim610.SetBool("isIn", false);
            anim610.SetBool("isLeft", true);
            anim1115.SetBool("isIn", true);
            anim1115.SetBool("isRight", false);
            pageNum += 1;
        }
        if (pageNum == 3) rightBtn.SetActive(false);
    }
    public void goLeft()
    {
        rightBtn.SetActive(true);

        if (pageNum == 3)
        {
            anim1115.SetBool("isIn", false);
            anim1115.SetBool("isRight", true);
            anim610.SetBool("isIn", true);
            anim610.SetBool("isLeft", false);
            pageNum -= 1;
        }
        else if (pageNum == 2)
        {
            anim610.SetBool("isIn", false);
            anim610.SetBool("isRight", true);
            anim15.SetBool("isLeft", false);
            anim15.SetBool("isIn", true);
            pageNum -= 1;
        }
        if (pageNum == 1) leftBtn.SetActive(false);
    }
    
    public void goBack()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex -1);
    }
}
