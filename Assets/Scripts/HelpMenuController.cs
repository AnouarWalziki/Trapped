using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class HelpMenuController : MonoBehaviour
{
    public GameObject[] pages;
    public TextMeshProUGUI actualPageNumberText;
    
    [SerializeField] int actualPageNumber;
    private int maxPagesCount;
    private bool aPageIsActive;

    // Start is called before the first frame update
    void Start()
    {
        maxPagesCount = pages.Length;
    }

    private void OnEnable()
    {
        actualPageNumber = 0;
    }

    private void OnDisable()
    {
        actualPageNumber = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if(!aPageIsActive)
        {        
            pages[actualPageNumber].SetActive(true);  // Activate page to be shown
            updateActualPageNumberText();
            aPageIsActive = true;
        }
        
    }

    void updateActualPageNumberText()
    {
        actualPageNumberText.text = (actualPageNumber + 1) + "/" + maxPagesCount; 
    }

    public void loadNextPage()
    {
        if(actualPageNumber == maxPagesCount - 1)
        {
            //Do nothing
        }
        else
        {
            pages[actualPageNumber].SetActive(false); // Desactivate previous page shown
            actualPageNumber++;
            aPageIsActive = false;
        }
    }

    public void loadPreviousPage()
    {
        if (actualPageNumber == 0)
        {
            //Do nothing
        }
        else
        {
            pages[actualPageNumber].SetActive(false); // Desactivate previous page shown

            actualPageNumber--;
            aPageIsActive = false;
        }
    }
}
