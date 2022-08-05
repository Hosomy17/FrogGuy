using UnityEngine;
using System.Collections;

public class Inimigo : MonoBehaviour {


	public GameObject objeto;
	private bool isEsquerda = true;
	public float velocidade = 2f;
	public float mxDelay ;
	private float timeMovimento = 0f;

	public Transform verticeInicial;
	public Transform verticeFinal;
	public bool isAlvo;

	private float mxDelayObjeto = 0.001f;
	private float timeObjeto =10f;


	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

		Movimentar ();
		RayCasting ();
		Behaviours ();
	
	}

	void RayCasting()
	{
		Debug.DrawLine (verticeInicial.position, verticeFinal.position, Color.red);
		isAlvo = Physics2D.Linecast (verticeInicial.position, verticeFinal.position,
		                            1 << LayerMask.NameToLayer ("Player"));
	}


	void Behaviours(){

		if (isAlvo) {
				
						if (timeObjeto <= mxDelayObjeto) {


								timeObjeto += Time.deltaTime;

								Instantiate (objeto, verticeInicial.position, objeto.transform.rotation);

						}
		
				} else {
				
			timeObjeto = 0;
		
		}
	}


	void Movimentar()
	{
		timeMovimento += Time.deltaTime;
		
		if (timeMovimento <= mxDelay) {
			
			//Vector3 movement = new Vector3(Vector2.left, 0f, 0f);
			//Transform position so aceita Vector3
			
			
			if (isEsquerda) {
				
				//transform.Translate (-Vector2.right * velocidade * Time.deltaTime);
				transform.Translate(Vector2.right * velocidade * Time.deltaTime);
				transform.eulerAngles = new Vector3 (0, 0, 0);
			} else {
				
				//transform.Translate (-Vector2.right * velocidade * Time.deltaTime);
				transform.Translate(Vector2.right * velocidade * Time.deltaTime);
				transform.eulerAngles = new Vector3 (0, 180,0);
			}
		}
		else {
			
			isEsquerda = !isEsquerda;
			timeMovimento = 0;
		}
		
	}

}
