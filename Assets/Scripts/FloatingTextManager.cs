using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FloatingTextManager : MonoBehaviour
{
    // Referencias públicas a los GameObjects necesarios
    public GameObject textContainer; // El contenedor para los textos flotantes
    public GameObject textPrefab; // El prefab (modelo) para instanciar nuevos textos flotantes

    // Lista para almacenar las instancias de textos flotantes
    private List<FloatingText> floatingTexts = new List<FloatingText>();

    private void Update(){
        foreach(FloatingText txt in floatingTexts){
            txt.UpdateFloatingText();
        }
    }

    public void Show(string msg, int fontSize, Color color, Vector3 position, Vector3 motion, float duration){
        FloatingText floatingText = GetFloatingText();

        floatingText.txt.text = msg;
        floatingText.txt.fontSize = fontSize;
        floatingText.txt.color = color;
        floatingText.go.transform.position = Camera.main.WorldToScreenPoint(position); //Transfer world space to screen space so we can use it in the UI
        floatingText.motion = motion;
        floatingText.duration = duration;

        floatingText.Show();

    }

    // Función para obtener un texto flotante disponible o crear uno nuevo
    private FloatingText GetFloatingText(){
        // Buscar un texto flotante inactivo en la lista de textos flotantes
        FloatingText txt = floatingTexts.Find(t => !t.active);
        
        // Si no se encontró un texto flotante inactivo, crear uno nuevo
        if (txt == null){
            txt = new FloatingText(); // Crear una nueva instancia de la clase FloatingText
            
            // Instanciar el prefab y asignar el GameObject resultante a la variable "go" de la instancia FloatingText
            txt.go = Instantiate(textPrefab);
            
            // Establecer el GameObject recién creado como hijo del textContainer para organizar visualmente los textos flotantes
            txt.go.transform.SetParent(textContainer.transform);
            
            // Obtener el componente Text del GameObject recién creado y asignarlo a la variable "txt" de la instancia FloatingText
            txt.txt = txt.go.GetComponent<Text>();
            
            // Agregar la nueva instancia FloatingText a la lista de textos flotantes para su uso posterior
            floatingTexts.Add(txt);
        }
        
        // Devolver el texto flotante (instancia de FloatingText) disponible o recién creado
        return txt;
    }
}