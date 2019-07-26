using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[Serializable]
public class Produtos
{
    public string Cor;
    public int value;
    public Produtos(string cor,int valor)
    {
        Cor = cor;
        value = valor;
    }
}
