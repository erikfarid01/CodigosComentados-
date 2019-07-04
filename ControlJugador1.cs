Nombre del desarollador: Erik Farid Gutiérrez Hernández 
Materia: Metodologia orientada a objetos 
Profesor:Josue Rivas 
Descripcion:Codigo para que el personaje pueda saltar agregandole una fuerza y que reconozca el suelo y no salte indefinidamente 


using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlJugador1 : BaseMove

{
    //sirve para agregarle una fuerza al momento de saltar al objeto que se puede modificar dependiedo de la masa   
    public float fuerzaSalto;
 
    
    // Start is called before the first frame update
    void Start()
    {
        AccesoComponentes();
    }

    private void Update()
    {
        //Sirve para detectar el clic del mouse y crear el salto 
        if (Input.GetMouseButton(0))
        {
            
        //Mientras se detecte la presion en el boton del mouse se activa la animación de disparo  
            anim.SetBool("ShootB",true);

        }
        else
        {

        //si no detecta la presion del boton, la animación de disparo no se activa 
            anim.SetBool("ShootB", false);
        }

    }




    // Update is called once per frame
    
    // funcion que se llama a determinados intervalos y que normalmente usaremos para actualizar información del objeto
    void FixedUpdate()
    {
       

        //sirve para que el objeto salte una sola vez, verificando cada que toque el suelo para volver a saltar.
        if (isGrounded()==true)//empezamos tocando el suelo 
        {
            
        //Verifica que el objeto esta tocando el suelo o saltaria en cualquier momento 
         if (Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.Space) && Input.GetKey(KeyCode.D) || Input.GetKeyDown(KeyCode.Space) && Input.GetKey(KeyCode.A))
                
           //agrega una fuerza de salto en el objeto para poder impulsarse 
          rb.AddForce(Vector3.up * fuerzaSalto, ForceMode.Impulse);

            Aceleracion(velocidad);

        }



    }

}

