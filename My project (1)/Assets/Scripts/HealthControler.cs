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
    private void ResetCallbacks(ref VisualElement e, int n) 
    {
        if (n == -1)
        {
            e.UnregisterCallback<MouseDownEvent>(evt =>
            {

                health.addHealth(-1);
            }, TrickleDown.NoTrickleDown);
        }
        else if(n==1)
        {
            e.UnregisterCallback<MouseDownEvent>(evt =>
            {

                health.addHealth(1);
            }, TrickleDown.NoTrickleDown);
        }
    }
    private void ResetButtons()
    {
        ResetCallbacks(ref puerta1, door1);
    }
    void comprobaciones() 
    {
        if (health.getHealth() > 0&&nSala<5)
        {

        }
        else if(health.getHealth() < 0 )
        {
        //pierdes
        }
        else 
        {
        //ganas
        }
    }
    // Update is called once per frame
    //puede haber 5 casos distintos
    //creamos funcion que saque numero random, cremos funcion que añada el MouseDownEnvent
    //a la funcion se le pasará el visualElement y un número. El número se pondrá en changeHealth 
    void SetDoorEffects() 
    {
        int rnd =Random.Range(0,6);
        if (rnd == 0) 
        {
            SetEvent(ref puerta1, 1);
            SetEvent(ref puerta2, 0);
            SetEvent(ref puerta3, -1);
        }
        if (rnd == 1) 
        {
            SetEvent(ref puerta1, 1);
            SetEvent(ref puerta2, -1);
            SetEvent(ref puerta3, 0);
        }
        if (rnd == 2) 
        {
            SetEvent(ref puerta1, -1);
            SetEvent(ref puerta3, 1);
            SetEvent(ref puerta2, 0);
        }
        if (rnd == 3) 
        {
            SetEvent(ref puerta1, -1);
            SetEvent(ref puerta2, 1);
            SetEvent(ref puerta3, 0);
        }
        if (rnd == 4) 
        {
            SetEvent(ref puerta2, 1);
            SetEvent(ref puerta3, -1);
            SetEvent(ref puerta1, 0);
        }
        if (rnd == 5) 
        {
            SetEvent(ref puerta2, -1);
            SetEvent(ref puerta3, 1);
            SetEvent(ref puerta1, 0);
        }
    }
    void SetEvent(ref VisualElement e, int n)
    {
        e.RegisterCallback<MouseDownEvent>(evt =>
        {
            health.addHealth(n);
            comprobaciones();
        });
    }
    private void OnEnable()
    {
        nSala = 1;
        UIDocument uidoc = GetComponent<UIDocument>();
        VisualElement rootve = uidoc.rootVisualElement;
        VisualElement bot = rootve.Q("Bot");
        Debug.Log(bot);
        //Label texto = rootve.Q<Label>("Title");
        health =(Lab4_2)bot.Q("Lab4_2");
        Debug.Log(health);
        puerta1 = rootve.Q("Mid");
        Debug.Log(puerta1);
        puerta1.RegisterCallback<MouseDownEvent>(evt => 
        {

        health.addHealth(1);
        });
        
        /*
        ventana_amarillo.RegisterCallback<MouseDownEvent>(evt =>
        {
            Debug.Log("ventana amarilla.");
            NoContent();
            contenido_amarillo.style.display = DisplayStyle.Flex;
        });
        ventana_rojo.RegisterCallback<MouseDownEvent>(evt =>
        {
            Debug.Log("ventana roja.");
            NoContent();
            contenido_rojo.style.display = DisplayStyle.Flex;
        });
        ventana_naranja.RegisterCallback<MouseDownEvent>(evt =>
        {
            Debug.Log("ventana naranja.");
            NoContent();
            contenido_naranja.style.display = DisplayStyle.Flex;
        });*/
    }
}
