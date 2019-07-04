Nombre del desarollador: Erik Farid Gutiérrez Hernández 
Materia: Metodologia orientada a objetos 
Profesor:Josue Rivas 




using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move : MonoBehaviour
{
    Animator anim;


    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        //COntrol al ejecutar animación run fordward
        if (Input.GetKey(KeyCode.UpArrow))
        {
            
            //Sirve para enviar valores flotantes para activar las transiciones que afectan ciertas animaciones 
            anim.SetFloat("Velocidad", 0.5f);
        }
        
         //condicionante que cumple si se detecta la activacion de la tecla  
        else if (Input.GetKey(KeyCode.DownArrow))
        {
            anim.SetFloat("Velocidad", -0.5f);
        }
        
         //si no se cumple la condicionante no se activa 
         else
        {
            anim.SetFloat("Velocidad", 0.0f);
        }
        
    
     }
}
