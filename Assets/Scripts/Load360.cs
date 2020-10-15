using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Load360 : MonoBehaviour
{
    public Material[] image360;
    public Animator animator;

    [SerializeField]
    private GameObject previousButton;
    [SerializeField]
    private GameObject nextButton;

    private int currentImage;

    // Start is called before the first frame update
    void Start()
    {
        currentImage = 0;
        RenderSettings.skybox = image360[currentImage];
    }

    // Update is called once per frame
    void Update()
    {
        if(currentImage == 0)
        {
            previousButton.SetActive(false);
            nextButton.SetActive(true);
        }else if(currentImage == 1)
        {
            previousButton.SetActive(true);
            nextButton.SetActive(true);
        }
        else
        {
            previousButton.SetActive(true);
            nextButton.SetActive(false);
        }
    }

    public void LoadPrevious()
    {
        animator.SetTrigger("Switch");
        currentImage--;
        StartCoroutine(LoadSkyBox());
    }

    public void LoadNext()
    {
        animator.SetTrigger("Switch");
        currentImage++;
        StartCoroutine(LoadSkyBox());
    }

    IEnumerator LoadSkyBox()
    {
        yield return new WaitForSeconds(0.9f);
        RenderSettings.skybox = image360[currentImage];
    }
}
