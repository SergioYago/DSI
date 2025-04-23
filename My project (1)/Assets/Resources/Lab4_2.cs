using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.UIElements;



public class Lab4_2 : VisualElement
{
    VisualElement Health = new VisualElement();
    VisualElement Health1 = new VisualElement();
    VisualElement Health2 = new VisualElement();
    VisualElement Health3 = new VisualElement();
    private  int estado=1;
    public int Estado
    {
        get => estado;
        set { estado = value;
            changeEstado();}
    }
    public void setHealth(int i) 
    {
        Debug.Log("anda");
    estado = i;
    }
    public void addHealth(int i ) {estado+=i;}
    void changeEstado() 
    {
        Sprite spr = Resources.Load<Sprite>("heart");
        Health.style.backgroundImage = new StyleBackground(spr);
        Health1.style.backgroundImage = new StyleBackground(spr);
        Health2.style.backgroundImage = new StyleBackground(spr);
        Health3.style.backgroundImage = new StyleBackground(spr);
        Health.style.unityBackgroundImageTintColor = new Color(1.0f, 1f, 1f, 0.5f);
        Health1.style.unityBackgroundImageTintColor = new Color(1.0f, 1f, 1f, 0.5f);
        Health2.style.unityBackgroundImageTintColor = new Color(1.0f, 1f, 1f, 0.5f);
        Health3.style.unityBackgroundImageTintColor = new Color(1.0f, 1f, 1f, 0.5f);
        
        if (estado >= 1)
        {
            Health.style.unityBackgroundImageTintColor = Color.white;
        }
        if (estado >= 2)
        {
            Health1.style.unityBackgroundImageTintColor= Color.white;
        }
        if (estado >= 3)
        {
            Health2.style.unityBackgroundImageTintColor = Color.white;
        }
        if (estado == 4)
        {
            Health3.style.unityBackgroundImageTintColor = Color.white;
        }
    }
    public new class UxmlFactory : UxmlFactory<Lab4_2,UxmlTraits> { };
    public new class UxmlTraits : VisualElement.UxmlTraits 
    {
        UxmlIntAttributeDescription myState = new UxmlIntAttributeDescription { name = "estado", defaultValue = 1 };
        public override void Init(VisualElement ve, IUxmlAttributes bag, CreationContext cc)
        {
            base.Init(ve, bag, cc);
            var health = ve as Lab4_2;
            health.Estado = myState.GetValueFromBag(bag, cc);
            
        }
    }
    public Lab4_2()
    {
        changeEstado();
        Health.style.width = 100;
        Health.style.height = 100;
        Health2.style.width = 100;
        Health2.style.height = 100;
        Health3.style.width = 100;
        Health3.style.height = 100;
        Health1.style.width = 100;
        Health1.style.height = 100;
        hierarchy.Add(Health);
        hierarchy.Add(Health1);
        hierarchy.Add(Health2);
        hierarchy.Add(Health3);
    }
}
