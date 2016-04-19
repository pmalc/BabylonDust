using UnityEngine;

public class cameraControl : MonoBehaviour
{
	public float DampTime = 0.2f;                 // Tiempo de reaccion de la camara para cambiar el zoom
	public float ScreenEdgeBuffer = 4f;           // Espacio entre el filo de la camara y el personaje
	public float MinSize =2.0f;                  // Tamaño mínimo de la camara
	public Transform[] Targets; 					// Todos los objetivos que la gamara tiene que captar
	public bool rotation = true;						//Para que la camara rote con los personajes
	public float rotateVel=1;

	private Camera Camera;                        // Referencia a la camara
	private float ZoomSpeed;                      // Velocidad del zoom.
	private Vector3 MoveVelocity;                 // Velocidad de movimiento de la camara
	private Vector3 DesiredPosition;              // Posicion media de los personajes donde se situará la camara


	private void Awake ()
	{
		Camera = GetComponentInChildren<Camera> ();
	}


	private void FixedUpdate ()
	{	
		if (rotation) {
			//Rotamos la camara si es necesario
			Rotate ();
		}
		// movemos la camara a laposicion media
		Move ();

		// Cambia el tamaño de la camara base
		Zoom ();

	}


	private void Move ()
	{
		// Busca el punto medio de los objetivos
		FindAveragePosition ();

		// Mueve la camara de la posicion donde está a la calculada con la velocidad introducida
		transform.position = Vector3.SmoothDamp(transform.position, DesiredPosition, ref MoveVelocity, DampTime);
	}


	private void FindAveragePosition ()
	{
		Vector3 averagePos = new Vector3 ();
		int numTargets = 0;

		// Rrecorre el vector con todas las posicones y las almacena juntas
		for (int i = 0; i < Targets.Length; i++)
		{
			// Si el objetivo no está activo va a al siguiente
			if (!Targets[i].gameObject.activeSelf)
				continue;

			// Añade la posicion al total y aumenta el numero de objetivos en uno.
			averagePos += Targets[i].position;
			numTargets++;
		}

		// Si hay objetivo divide la suma de todos ellos entre el numero de ellos para calcular el punto medio
		if (numTargets > 0)
			averagePos /= numTargets;

		// Mantenemos la posición y ya que la y es la altura de la camara
		averagePos.y = transform.position.y;

		// La posición a la que debe moverse la camara es la que acabamos de calcular
		DesiredPosition = averagePos;
	}


	private void Zoom ()
	{	//Buscamos el tamaño requerido para la posicion de la camara y los personajes y hacemos una transicion al tamaño
		float requiredSize = FindRequiredSize();
		Camera.fieldOfView = Mathf.SmoothDamp (Camera.fieldOfView, requiredSize, ref ZoomSpeed, DampTime);
	}


	private float FindRequiredSize ()
	{
		// Encuentra la posicion de la camara respecto al punto medio
		Vector3 desiredLocalPos = transform.InverseTransformPoint(DesiredPosition);

		// Empezamos a calcular el tamaño de la camara desde 0
		float size = 0f;

		// recorremos todos los objetivos
		for (int i = 0; i < Targets.Length; i++)
		{
			// Si no están activos pasamos al siguiente
			if (!Targets[i].gameObject.activeSelf)
				continue;

			// Si esta activo buscamos su posicion en el espacio local de la camara
			Vector3 targetLocalPos = transform.InverseTransformPoint(Targets[i].position);

			// Buscamos la posicion del objetivo con respecto a la posicion de la camara deseada
			Vector3 desiredPosToTarget = targetLocalPos - desiredLocalPos;

			// Elije la posición mas alejada de el rango de la camara
			size = Mathf.Max(size, Mathf.Abs(desiredPosToTarget.y));

			// lo mismo pero con el ancho
			size = Mathf.Max(size, Mathf.Abs(desiredPosToTarget.x) / Camera.aspect);
		}

		// le añadimos el margen que le hemos dado al ancho
		size += ScreenEdgeBuffer;

		//nos aseguramos de que sea mayor que el mínimo establecido
		size = Mathf.Max (size, MinSize);

		return size;
	}

	void Rotate(){
		Vector3 averageDir = new Vector3 ();
		int numTargets = 0;

		// Rrecorre la direccion de lso personajes y las va sumando
		for (int i = 0; i < Targets.Length; i++)
		{
			// Si el objetivo no está activo va a al siguiente
			if (!Targets[i].gameObject.activeSelf)
				continue;

			// Añade la posicion al total y aumenta el numero de objetivos en uno.
				averageDir += Targets [i].transform.forward;
				numTargets++;

		}
		averageDir = averageDir / numTargets;
		transform.forward = Vector3.SmoothDamp(transform.forward, averageDir, ref MoveVelocity, DampTime);
	} 

	public void rotate(){
		rotation = !rotation;
	}

}
