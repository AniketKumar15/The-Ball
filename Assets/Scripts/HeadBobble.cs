using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeadBobble : MonoBehaviour
{
    [Range(0.001f,0.01f)]
    public float amount = 0.002f;

    [Range(1f, 30f)]
    public float frequency = 10.0f;

    [Range(10f, 100f)]
    public float smooth = 10.0f;

    Vector3 startPos;

    private void Start()
    {
        startPos = transform.localPosition;

    }

    // Update is called once per frame
    void Update()
    {
        cameraBobbling();
        stopBobbling();
    }

    void cameraBobbling()
    {
        float inputMag = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical")).magnitude;

        if (inputMag > 0)
        {
            startHeadBobble();
        }
    }

    Vector3 startHeadBobble()
    {
        Vector3 pos = Vector3.zero;

        pos.y += Mathf.Lerp(pos.y, Mathf.Sin(Time.time * frequency) * amount * 1.4f, smooth * Time.deltaTime);
        pos.x += Mathf.Lerp(pos.x, Mathf.Cos(Time.time * frequency / 2f) * amount * 1.6f, smooth * Time.deltaTime);

        transform.localPosition += pos;
        return pos;
    }

    void stopBobbling()
    {
        if (transform.localPosition == startPos) return;

        transform.localPosition = Vector3.Lerp(transform.position, startPos, 1 * Time.deltaTime);
    }
}
