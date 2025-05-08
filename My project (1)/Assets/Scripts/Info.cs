using System;
using UnityEngine;

public class Info 
{ 
    public int vida=2;
    public int sala=0;
        public Info(int health, int room)
        {
            vida = health;
            sala = room;
        }
    public int getHealth() {  return vida; }
    public int getRoom() {  return sala; }
}
