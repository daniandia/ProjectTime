using UnityEngine;
using System.Collections;

public class SliderDoor : MonoBehaviour {

	// PUERTAS QUE SE ABREN DESLIZANDOSE HACIA ALGUN LADO (AUTOMATICAS, PERSIANAS ...)
	// El estado por defecto de la animación será de Puerta Cerrada
	// Hay q mejorar la parte de las anms añadiendo los estados open y close y un delay xa q no funcione todo a trompicones

	public enum SlideDestiny{
		Left,
		Right,
		Up,
		Down
	}

	public enum DoorStatus{
		Open,
		Close,
		Opened,
		Closed
	}

	private DoorStatus 		currentStatus;
	public SlideDestiny 	slideDestiny 	= SlideDestiny.Left;		// Dirección hacia la que se abre
	public DoorStatus		startStatus		= DoorStatus.Closed;		// Estado inicial de la puerta
	public string			openItem		= "";						// Nombre del objeto que abre la puerta
	public float			moveTime		= 1f;						// Tiempo de apertura
	public LeanTweenType	moveTween		= LeanTweenType.linear;		// Efecto de apertura (rebote, ...)
	public float			moveDist		= 1f;						// Distancia de desplzamiento del modelo (se cambiará por animación)
	public GameObject		doorObject;

	// Use this for initialization
	void Start () {
		SetInitialStatus();
	}

	public void SetInitialStatus(){
		switch (startStatus){
			case DoorStatus.Close: 	Close(); 	break;
			case DoorStatus.Open:	Open(); 	break;
			case DoorStatus.Opened: ForcePosition(slideDestiny); break;
		}
		currentStatus = startStatus;
	}

	// Update is called once per frame
	void Update () {
	
	}

	void ForcePosition(SlideDestiny _to){

		Vector3 dest = doorObject.transform.position;
		switch (_to){
		case SlideDestiny.Down: 	dest+=Vector3.down*moveDist; 	break;
		case SlideDestiny.Up:		dest+=Vector3.up*moveDist;		break;
		case SlideDestiny.Left: 	dest+=Vector3.left*moveDist; 	break;
		case SlideDestiny.Right:	dest+=Vector3.right*moveDist;	break;
		}
		doorObject.transform.position = dest;
	}

	void Open(){
		print ("DOOR OPENS : "+gameObject.name);
		Vector3 dest = doorObject.transform.position;
		switch (slideDestiny){
		case SlideDestiny.Down: 	dest+=Vector3.down*moveDist; 	break;
		case SlideDestiny.Up:		dest+=Vector3.up*moveDist;		break;
		case SlideDestiny.Left: 	dest+=Vector3.left*moveDist; 	break;
		case SlideDestiny.Right:	dest+=Vector3.right*moveDist;	break;
		}
		LeanTween.move(doorObject,dest,moveTime).setEase(moveTween);
		currentStatus = DoorStatus.Opened;
	}

	void Close(){
		print ("DOOR CLOSES : "+gameObject.name);
		Vector3 dest = doorObject.transform.position;
		switch (slideDestiny){
		case SlideDestiny.Down: 	dest+=Vector3.up*moveDist; 		break;
		case SlideDestiny.Up:		dest+=Vector3.down*moveDist;	break;
		case SlideDestiny.Left: 	dest+=Vector3.right*moveDist; 	break;
		case SlideDestiny.Right:	dest+=Vector3.left*moveDist;	break;
		}
		LeanTween.move(doorObject,dest,moveTime).setEase(moveTween);
		currentStatus = DoorStatus.Closed;
	}

	// PLAYER ENTER FUNCTIONS

	public void PlayerEntered(){
		if (currentStatus == DoorStatus.Closed && openItem == "") Open();
	}

	public void PlayerExit(){
		if (currentStatus == DoorStatus.Opened) Close();
	}
}
