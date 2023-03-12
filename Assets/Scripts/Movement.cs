#nullable enable

using UnityEngine;

public class Movement : MonoBehaviour
{
    // public float speed;

    void Start()
    {

    }

    void Update()
    {
        float h = Input.GetAxisRaw("Horizontal");
        float v = Input.GetAxisRaw("Vertical");
        var delta = new Vector3(v, 0, -h);
        delta *= 10 * Time.deltaTime;

        gameObject.transform.position += delta;
    }

    private void OnSceneGUI()
    {

    }
}
