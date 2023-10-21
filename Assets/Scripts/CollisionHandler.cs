using System.Collections;
using UnityEngine;

public class CollisionHandler : MonoBehaviour
{
    public Material accentColorMaterial;
    public Material primitivesBlueMaterial;
    private Renderer targetRenderer;

    private void Start()
    {
        targetRenderer = GetComponent<Renderer>();
        targetRenderer.material = primitivesBlueMaterial;
    }

    void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "Ball"){
            PlayerThrowable throwable = collision.gameObject.GetComponent<PlayerThrowable>();

            if (throwable)
            {
                float distance = Vector3.Distance(throwable.releasePosition, targetRenderer.transform.position);
                float bonus = (600-throwable.throwForce)* 0.1f;

                ScoreBoard.Score += (int) (distance*10 + bonus);
                ScoreBoard.Bonus = (int) bonus;

                StartCoroutine(ChangeMaterialTemporarily());
            }
        }
        
    }

    IEnumerator ChangeMaterialTemporarily()
    {
        targetRenderer.material = accentColorMaterial;
        yield return new WaitForSeconds(2);
        targetRenderer.material = primitivesBlueMaterial;
    }
}
