using System;
using System.Collections;
using System.Collections.Generic;
using System.Xml.Serialization;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;



public class HealthControler : MonoBehaviour
{
    Lab4_2 health;
    VisualElement puerta1;
    VisualElement puerta2;
    VisualElement puerta3;
    int nSala;
    //3 nu meros 1 para cada boton para saber que evento tienen.
    //si es 1 es sumar vida, si es 0 no tiene nada y si es -1 resta vida
    int door1;
    int door2;
    int door3;
    // Start is called before the first frame update
    void resetHealth() 
    {
    health.setHealth(3);
    }
    void Start()
    {

    }
    void nextDoor() 
    {
        //metodo de reiniciar
        nSala++;
        ResetButtons();

    }
    private void ResetCallbacks(ref VisualElement e) 
    {
        e.UnregisterCallback<ClickEvent,int>(ChangeEffectDoor);
    }
    private void ResetButtons()
    {
        ResetCallbacks(ref puerta1);
        ResetCallbacks(ref puerta2);
        ResetCallbacks(ref puerta3);
        SetDoorEffects();
    }
    void comprobaciones() 
    {
        if (health.getHealth() > 0&&nSala<5)
        {
            
            nSala++;
        }
        else if(health.getHealth() < 0 )
        {
            Debug.Log("Perdiste");
        }
        else 
        {
            Debug.Log("ganeste");
        }
        ResetButtons();
    }
    //puede haber 5 casos distintos
    //creamos funcion que saque numero random, cremos funcion que añada el MouseDownEnvent
    //a la funcion se le pasará el visualElement y un número. El número se pondrá en changeHealth 
    void SetDoorEffects() 
    {
        int rnd =UnityEngine.Random.Range(0,6);
        if (rnd == 0) 
        {
            door1 = 1;
            door2 = 0;
            door3=-1;
            
        }
       else if (rnd == 1) 
        {
            door1 = 1;
            door2 = -1;
            door3 = 0;
            
        }
      else  if (rnd == 2) 
        {
            door1 = -1;
            door2 = 0;
            door3 = 1;
            
        }
       else if (rnd == 3) 
        {
            door1 = -1;
            door2 = 1;
            door3 = 0;
            
        }
       else if (rnd == 4) 
        {
            door1 = 0;
            door2 = 1;
            door3 = -1;
            
        }
      else  if (rnd == 5) 
        {
            door1 = 0;
            door2 = -1;
            door3 = 1;
            
        }
        SetEvent(ref puerta1, door1);
        SetEvent(ref puerta2, door2);
        SetEvent(ref puerta3, door3);
    }
    void SetEvent(ref VisualElement e, int n)
    {
        e.RegisterCallback<ClickEvent,int>(ChangeEffectDoor,n);
    }
    private void OnEnable()
    {
        nSala = 1;
        UIDocument uidoc = GetComponent<UIDocument>();
        VisualElement rootve = uidoc.rootVisualElement;
        VisualElement bot = rootve.Q("Bot");
        VisualElement mid = rootve.Q("Mid");
        //Label texto = rootve.Q<Label>("Title");
        health =(Lab4_2)bot.Q("Script");

        puerta1 = mid.Q("Door1");
        puerta2 = mid.Q("Door2");
        puerta3 = mid.Q("Door3");
        Debug.Log(puerta1);
        SetDoorEffects();
       
        
       
    }
    private void ChangeEffectDoor(ClickEvent cev, int n) 
    {
        health.addHealth(n);
        comprobaciones();
    }
}
