using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;



public class HealthControler : MonoBehaviour
{
    Lab4_2 health;
    VisualElement puertaSuma;
    // Start is called before the first frame update
    void resetHealth() 
    {
    health.setHealth(3);
    }
    void Start()
    {

    }

    // Update is called once per frame
    
    private void OnEnable()
    {
        UIDocument uidoc = GetComponent<UIDocument>();
        VisualElement rootve = uidoc.rootVisualElement;
        VisualElement bot = rootve.Q("Bot");
        Debug.Log(bot);
        //Label texto = rootve.Q<Label>("Title");
       
        Debug.Log(health);
        puertaSuma = rootve.Q("Mid");
        Debug.Log(puertaSuma);
        puertaSuma.RegisterCallback<MouseDownEvent>(evt => 
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
