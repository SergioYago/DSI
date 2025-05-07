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
    VisualElement startmenu;
    VisualElement gamezone;
    VisualElement WinZone;
    VisualElement LooseZone;
    int nSala=0;
    Label lblSala;
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
        if (health.getHealth() > 0&&nSala<10)
        {  
            nSala++;
        }
        else if(health.getHealth() <= 0 )
        {
            Debug.Log("Perdiste");
            ResetAll();
            Loose();
        }
        else 
        {
            Debug.Log("ganaste");
            ResetAll();
            Win();
        }
        lblSala.text = "Sala " + nSala;
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
    private void ResetAll() 
    {
    nSala= 0;
    health.setHealth(2);
    }
    void SetEvent(ref VisualElement e, int n)
    {
        e.RegisterCallback<ClickEvent,int>(ChangeEffectDoor,n);
    }
    private void OnEnable()
    {
        UIDocument uidoc = GetComponent<UIDocument>();
        VisualElement rootve = uidoc.rootVisualElement;
        gamezone = rootve.Q("GameZone");
       
        VisualElement top = gamezone.Q("Top");
        VisualElement bot = gamezone.Q("Bot");
        VisualElement mid = gamezone.Q("Mid");
        //Label texto = rootve.Q<Label>("Title");
        health =(Lab4_2)bot.Q("Script");
        lblSala = (Label)bot.Q("NumberRoom");
        puerta1 = mid.Q("Door1");
        puerta2 = mid.Q("Door2");
        puerta3 = mid.Q("Door3");
        SetDoorEffects();
        lblSala.text = "Sala " + nSala;
        startmenu= rootve.Q("startzone");
        LooseZone = rootve.Q("LostZone");
        WinZone = rootve.Q("WinZone");
        VisualElement botpart = startmenu.Q("BotPart");
        Button Backbutton = (Button)top.Q("BackButton");
        Button Sbutton = (Button)botpart.Q("Start");
        Button Wbutton = (Button)WinZone.Q("WinBack");
        Button Lbutton = (Button)LooseZone.Q("LostBack");
        Sbutton.RegisterCallback<ClickEvent>(StartGame);
        Backbutton.RegisterCallback<ClickEvent>(GoBack);
        Wbutton.RegisterCallback<ClickEvent>(GoBack);
        Lbutton.RegisterCallback<ClickEvent>(GoBack);
        AllNotVisible();
        startmenu.style.display = DisplayStyle.Flex;
    }
    private void ChangeEffectDoor(ClickEvent cev, int n) 
    {
        health.addHealth(n);
        comprobaciones();
    }
    private void StartGame(ClickEvent cev) 
    {
        AllNotVisible();
    gamezone.style.display = DisplayStyle.Flex;
    
    }
    private void AllNotVisible() 
    {
        gamezone.style.display = DisplayStyle.None;
        startmenu.style.display = DisplayStyle.None;
        WinZone.style.display = DisplayStyle.None;
        LooseZone.style.display = DisplayStyle.None;
    }
    private void GoBack(ClickEvent cev) 
    {
        AllNotVisible();
        startmenu.style.display = DisplayStyle.Flex;
    }
    private void Win() 
    {
        AllNotVisible();
        WinZone.style.display = DisplayStyle.Flex;
    }
    private void Loose() 
    {
        AllNotVisible();
        LooseZone.style.display=DisplayStyle.Flex;
    }
}
