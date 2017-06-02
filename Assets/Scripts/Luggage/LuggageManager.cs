﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LuggageManager : MonoBehaviour {

    // This images shows the target
    public GameObject popUpPanel;
    // Time to complete the level
    public float time = 60.0f;

    public GameObject luggagePanel;
    public GameObject buttonCloseDrawer;
    public GameObject floorPanel;

    // Image inside the popUpPanel which shows the actual target
    private Image targetImage;
    private int actualTarget;
    private GameObject panelShow;
    private bool interactable;

    // Clothes that the user has to move into the luggage
    private int numTargets;
    private Sprite[] targets;

    // Use this for initialization
    void Start () {
        this.actualTarget = 0;
        this.panelShow = null;
        this.buttonCloseDrawer.SetActive(false);
        intializeTargets();
        this.luggagePanel.SetActive(false);
        this.floorPanel.SetActive(false);
        this.targetImage = this.popUpPanel.transform.GetChild(0).GetComponent<Image>();
        ShowCurrentTarget();
        // Tracker: sprites, time, lifes?
    }

    // This function initialize the target sprites getting the sprite of the image of luggagePanel
    private void intializeTargets()
    {
        this.numTargets = this.luggagePanel.transform.childCount;
        this.targets = new Sprite[numTargets];
        for (int i = 0; i < numTargets; i++)
        {
            GameObject child = this.luggagePanel.transform.GetChild(i).gameObject;
            this.targets[i] = child.GetComponent<Image>().sprite;
        }
    }

    public void TargetCompleted()
    {
        this.actualTarget++;

        // Close drawer (target can be completed without oppening a drawer, opening the wardrove)
        CloseDrawer();

        if (this.actualTarget >= this.numTargets)
        {
            Debug.Log("You win");
            this.interactable = false;
        } else
        {
            ShowCurrentTarget();
        }
    }

    private void ShowCurrentTarget()
    {
        this.popUpPanel.SetActive(true);
        this.targetImage.sprite = this.targets[this.actualTarget];
        this.targetImage.type = Image.Type.Simple;
        this.targetImage.preserveAspect = true;
        this.interactable = false;
        //Tracker: sprite found at time X
    }
	
    public void ClickOnDrawer(GameObject go)
    {
        go.SetActive(true);
        this.panelShow = go;
        this.luggagePanel.SetActive(true);
        this.buttonCloseDrawer.SetActive(true);
        this.floorPanel.SetActive(true);
        this.interactable = false;
        // Tracker: what objects were shown
    }

    public void CloseDrawer()
    {
        if (this.panelShow != null) this.panelShow.SetActive(false);
        this.panelShow = null;
        this.buttonCloseDrawer.SetActive(false);
        this.luggagePanel.SetActive(false);
        this.floorPanel.SetActive(false);
        this.interactable = true;
    }

    public void ClosePopUp()
    {
        this.popUpPanel.SetActive(false);
        this.interactable = true;
    }

    public bool isInteractable
    {
        get { return this.interactable; }

    }

    public int actualTargetNum
    {
        get { return this.actualTarget; }
    }
}