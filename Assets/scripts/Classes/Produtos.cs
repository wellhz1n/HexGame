using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[Serializable]
public class Produtos
{
    public string Cor;
    public int value;
    public bool Comprado = false;
    public bool Selecionado = false;
    public Produtos(string cor,int valor,bool comprado,bool selecionado)
    {
        Cor = cor;
        value = valor;
        Comprado = comprado;
        Selecionado = selecionado;

    }
}
