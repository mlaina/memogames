﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PhoneBehaviour : MonoBehaviour {

    private AudioSource source;
    public Sequence seq;

    public AudioClip playerCallingSound;
    public AudioClip busyLine;

    //Persona a la que debe llamar
    public GameObject target;

   

    //Si el móvil se debe esconder o no
    public bool visibleAtStart = false;

    private void Awake()
    {
        source = GetComponent<AudioSource>();
    }

    // Use this for initialization
    void Start () {
        if (!visibleAtStart)
            this.gameObject.SetActive(false);

        

    }
	
	// Update is called once per frame
	void Update () {
		
	}


    

    public void startDialog()
    {
        this.source.Stop();
        var ge = new GameEvent();
        ge.Name = "start sequence";
        ge.setParameter("sequence", seq);
        Game.main.enqueueEvent(ge);
    }

    private void childClicked(GameObject go)
    {
         
            if(go == target) {

                source.Stop();
                source.clip = playerCallingSound;
                source.loop = true;
                source.Play();
                StartCoroutine(Wait());
                
            //
        }
            else
            {
                source.Stop();
                source.clip = busyLine;
                source.Play();
                Debug.Log("Wrong target");

            }
        
    }

    //La parte de cógido que quieres que se detenga debe estar dentro del método IEnumerator
    public IEnumerator Wait()
    {
        
        yield return new WaitForSeconds(5.0f);
        source.loop = false;
        source.Stop();
        startDialog();
    }


}