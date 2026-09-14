using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform target;
    public GameObject playerModel;

    public float distancia = 8f;
    public float distanciaPrimeiraPessoa = 0.2f;
    public float sensibilidade = 200f;
    public float suavidade = 0.125f;

    private float rotacaoY = 0f;
    private float rotacaoX = 20f;
    private bool primeiraPessoa = false;

    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }

    void LateUpdate()
    {
        if (Input.GetKeyDown(KeyCode.C))
        {
            primeiraPessoa = !primeiraPessoa;

            Renderer[] renderers = playerModel.GetComponentsInChildren<Renderer>();

            foreach (Renderer renderer in renderers)
            {
                renderer.enabled = !primeiraPessoa;
            }
        }

        float mouseX = Input.GetAxis("Mouse X") * sensibilidade * Time.deltaTime;
        float mouseY = Input.GetAxis("Mouse Y") * sensibilidade * Time.deltaTime;

        rotacaoY += mouseX;
        rotacaoX -= mouseY;

        rotacaoX = Mathf.Clamp(rotacaoX, -35f, 60f);

        Quaternion rotacao = Quaternion.Euler(rotacaoX, rotacaoY, 0);

        float distanciaAtual = primeiraPessoa ? distanciaPrimeiraPessoa : distancia;

        Vector3 posicaoDesejada = target.position - (rotacao * Vector3.forward * distanciaAtual);

        transform.position = Vector3.Lerp(transform.position, posicaoDesejada, suavidade);
        transform.LookAt(target);
    }
}