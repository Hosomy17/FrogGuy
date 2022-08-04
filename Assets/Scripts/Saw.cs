using UnityEngine;

public class Saw : MonoBehaviour
{
    public float speed;
    public float moveTime;

    private bool dirLeft = true;
    private float timer;

    private void Update()
    {
        if(dirLeft)
        {
            //se verdadeiro a serra vai para a direita
            transform.Translate(Vector2.left * speed * Time.deltaTime);
        }
        else
        {
            //se falso a serra vai para a esquerda
            transform.Translate(Vector2.right * speed * Time.deltaTime);
        }

        timer += Time.deltaTime;
        
        if (timer >= moveTime)
        {
            //temporizador em tempo real que muda a direcao do obstaculo
            dirLeft = !dirLeft;
            timer = 0f;
        }
    }
}
