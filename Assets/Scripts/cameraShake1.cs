using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cameraShake1 : MonoBehaviour
{
    public IEnumerator Shake (float duration, float magnitude)
    {
        Vector3 originalPos = transform.localPosition;

        float elapsed = 0.0f;

        while (elapsed < duration)
        {
            Debug.Log("CameraShouldBeShaking");
            float x = Random.Range(-12f, 12f) * magnitude;
            float y = Random.Range(-12f, 12f) * magnitude;

            transform.localPosition = new Vector3 (x,y, originalPos.z);

            elapsed += Time.deltaTime;

            yield return null;
        }

        transform.localPosition = originalPos;
    }
}
