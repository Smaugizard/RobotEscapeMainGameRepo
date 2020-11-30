using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class hasCurrentTool : MonoBehaviour
{
    public GameObject wrench;
    public GameObject hammer;
    public GameObject shear;
    public GameObject screwdriver;

    public GameObject wrenchSelect;
    public GameObject hammerSelect;
    public GameObject shearSelect;
    public GameObject screwdriverSelect;

    public GameObject selectedText;
    public bool showSelectText;

    public string currentlySelected;
    // Start is called before the first frame update
    void Start()
    {
        wrench = GameObject.Find("WrenchUI");
        hammer = GameObject.Find("HammerUI");
        shear = GameObject.Find("ShearUI");
        screwdriver = GameObject.Find("ScrewdriverUI");

        wrenchSelect = GameObject.Find("SelectionWrench");
        hammerSelect = GameObject.Find("SelectionHammer");
        shearSelect = GameObject.Find("SelectionShear");
        screwdriverSelect = GameObject.Find("SelectionScrewdriver");

        wrench.SetActive(false);
        hammer.SetActive(false);
        shear.SetActive(false);
        screwdriver.SetActive(false);

        wrenchSelect.SetActive(false);
        hammerSelect.SetActive(false);
        shearSelect.SetActive(false);
        screwdriverSelect.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (GameObject.Find("Migration").GetComponent<Integration>().hasHammer)
        {
            hammer.SetActive(true);
        }
        if (GameObject.Find("Migration").GetComponent<Integration>().hasScrewdriver)
        {
            screwdriver.SetActive(true);
        }
        if (GameObject.Find("Migration").GetComponent<Integration>().hasShears)
        {
            shear.SetActive(true);
        }
        if (GameObject.Find("Migration").GetComponent<Integration>().hasWrench)
        {
            wrench.SetActive(true);
        }

        if (Input.GetKeyDown(KeyCode.Alpha1) && wrench.activeInHierarchy == true)
        {
            resetSelection();
            wrenchSelect.SetActive(true);
            GameObject.Find("Player").GetComponent<playerTool>().currentItem = "Wrench";
        }
        else if (Input.GetKeyDown(KeyCode.Alpha2) && shear.activeInHierarchy == true)
        {
            resetSelection();
            shearSelect.SetActive(true);
            GameObject.Find("Player").GetComponent<playerTool>().currentItem = "Shears";
        }
        else if (Input.GetKeyDown(KeyCode.Alpha3) && screwdriver.activeInHierarchy == true)
        {
            resetSelection();
            screwdriverSelect.SetActive(true);
            GameObject.Find("Player").GetComponent<playerTool>().currentItem = "Screwdriver";
        }
        else if (Input.GetKeyDown(KeyCode.Alpha4) && hammer.activeInHierarchy == true)
        {
            resetSelection();
            hammerSelect.SetActive(true);
            GameObject.Find("Player").GetComponent<playerTool>().currentItem = "Hammer";
        }
    }

    private void resetSelection()
    {
        wrenchSelect.SetActive(false);
        hammerSelect.SetActive(false);
        shearSelect.SetActive(false);
        screwdriverSelect.SetActive(false);
    }
}
