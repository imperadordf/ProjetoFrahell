using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VisionIA : MonoBehaviour
{
    public LayerMask layerRay;
    public InimigoMachine inimigoScript;
    public Transform objectVision;
    public float distanciaDeVisao = 10;
    [Header("Raycast")]
    public string tagDosInimigos = "Player";
    [Range(2, 180)]
    public float raiosExtraPorCamada = 20;
    [Range(5, 180)]
    public float anguloDeVisao = 120;
    [Range(1, 10)]
    public int numeroDeCamadas = 3;
    [Range(0.02f, 0.15f)]
    public float distanciaEntreCamadas = 0.1f;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(VisionInimigo());
    }

    // Update is called once per frame



    IEnumerator VisionInimigo()
    {
        while (true)
        {

        
        float limiteCamadas = numeroDeCamadas * 0.5f;
        for (int x = 0; x <= raiosExtraPorCamada; x++)
        {
            for (float y = -limiteCamadas + 0.5f; y <= limiteCamadas; y++)
            {
                float angleToRay = x * (anguloDeVisao / raiosExtraPorCamada) + ((180.0f - anguloDeVisao) * 0.5f);
                Vector3 directionMultipl = (-objectVision.right) + (objectVision.up * y * distanciaEntreCamadas);
                Vector3 rayDirection = Quaternion.AngleAxis(angleToRay, objectVision.up) * directionMultipl;
                //
                RaycastHit hitRaycast;
                if (Physics.Raycast(objectVision.position, rayDirection, out hitRaycast, distanciaDeVisao))
                {
                    if (!hitRaycast.transform.IsChildOf(transform.root) && !hitRaycast.collider.isTrigger)
                    {
                        if (hitRaycast.collider.gameObject.CompareTag(tagDosInimigos))
                        {
                            inimigoScript.MudarState(EnemyState.SEEK);
                                Debug.DrawRay(objectVision.position, rayDirection * distanciaDeVisao, Color.red);
                            }
                        
                            Debug.DrawRay(objectVision.position, rayDirection * distanciaDeVisao, Color.blue);
                        }
                }
                else
                {
                    Debug.DrawRay(objectVision.position, rayDirection * distanciaDeVisao, Color.green);
                }
            }
        }

        yield return new WaitForSeconds(0.5f);
        }
    }

    private void OnDrawGizmos()
    {

        float limiteCamadas = numeroDeCamadas * 0.5f;
        for (int x = 0; x <= raiosExtraPorCamada; x++)
        {
            for (float y = -limiteCamadas + 0.5f; y <= limiteCamadas; y++)
            {
                float angleToRay = x * (anguloDeVisao / raiosExtraPorCamada) + ((180.0f - anguloDeVisao) * 0.5f);
                Vector3 directionMultipl = (-objectVision.right) + (objectVision.up * y * distanciaEntreCamadas);
                Vector3 rayDirection = Quaternion.AngleAxis(angleToRay, objectVision.up) * directionMultipl;
                //
                RaycastHit hitRaycast;
                if (Physics.Raycast(objectVision.position, rayDirection, out hitRaycast, distanciaDeVisao))
                {
                    if (!hitRaycast.transform.IsChildOf(transform.root) && !hitRaycast.collider.isTrigger)
                    {
                        if (hitRaycast.collider.gameObject.CompareTag(tagDosInimigos))
                        {
                            inimigoScript.MudarState(EnemyState.SEEK);
                            Debug.DrawRay(objectVision.position, rayDirection * distanciaDeVisao, Color.red);
                        }

                        Debug.DrawRay(objectVision.position, rayDirection * distanciaDeVisao, Color.blue);
                    }
                }
                else
                {
                    Debug.DrawRay(objectVision.position, rayDirection * distanciaDeVisao, Color.green);
                }
            }
        }
    }
}
