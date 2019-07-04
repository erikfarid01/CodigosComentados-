Nombre del desarollador: Erik Farid Gutiérrez Hernández 
Materia: Metodologia orientada a objetos 
Profesor:Josue Rivas 



using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseMove : MonoBehaviour
{
    public float velocidad;
    protected Rigidbody rb;
    protected Animator anim;
    protected float hor;
    protected float vert;

    protected void AccesoComponentes()
    {
       //Le permite a los objetos actuar bajo el control de fisicas pueden recibir fuerza y torque para movimientos de una manera realista 
        rb = GetComponent<Rigidbody>();
       

       // Permite mantener un conjunto de animaciones para un personaje u objeto.
       anim = GetComponent<Animator>();

    }

    protected void Aceleracion (float v)
    {
        //Entrada basada en el eje horizontal 
        hor = Input.GetAxis("Horizontal") * v * Time.deltaTime;
        
        //Entrada basada en el eje Vertical 
        vert=Input.GetAxis("Vertical")* v * Time.deltaTime;

        
        //Sirve para modificar posiciones y direcciones en 3D tambien contienen funciones para hacer operaciones vectoriales comunes 
        rb.velocity = new Vector3(hor, rb.velocity.y, vert);

        
        //Establece un valor flotante con nombre en este caso la velocidad Vertical 
        anim.SetFloat("Velocidad", vert);
       

        
        //Establece un valor flotante con nombre en este caso la velocidad Horizontal 
        anim.SetFloat("veloLateral", hor);
   
       }
       
       //se usa para filtrar selectivamrente los objetos del juego por ejemplo cuando se dispara 
       public LayerMask mask;
       
        // Booleano para estar seguro que tocamos el suelo
        protected bool isGrounded()
       {
       
        //Emite un rayo, desde un punto origin, en dirección de longitud, contra todos los colliders en la escena.
         Vector3 rayOrigin = GetComponent<Collider>().bounds.center;
        
        float rayDistance = GetComponent<Collider>().bounds.extents.y + 0.01f;
        
        //Significa que en la variable ray que guarda la información del rayo que estamos proyectando actual, se crea un nuevo rayo que parte desde la posición del objeto actual y va hacia delante
        Ray ray = new Ray();

        ray.origin = rayOrigin;

        //Mvemos la psicion del rayo para que coincida con el collider 
        ray.direction = Vector3.down;
        
       //Dibuja un rayo que empieza desde from hasta from más direction
       Debug.DrawRay(ray.origin, ray.direction, Color.red);

        //Detecta la colision de un objeto de un objeto hacia el terreno para generar alguna acción 
        if (Physics.Raycast(ray.origin, ray.direction, rayDistance, mask))
        {
          
        //Registra el mensaje en la consola de Unity.

        Debug.Log("Esta chocando");
            
         //Esta función debería devolver true si deseas que continúe la operación
         return true;
        }
        else
            
        //finaliza la ejecución de una función y especifica el valor a ser devuelto por ésta.
        return false;

    }

}
