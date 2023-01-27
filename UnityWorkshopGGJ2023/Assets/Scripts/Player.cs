using TMPro;
using UnityEngine;
using UnityEngine.Serialization;

public class Player : MonoBehaviour
{
    [FormerlySerializedAs("_Speed")] public float _speed;
    public TextMeshProUGUI _textField;

    // FixedUpdate is called once per frame
    void FixedUpdate()
    {
        // Move left and set a barrier
        // Notice that we want the bar to stay within a certain range, thus we only move it if it's above a certain x-position
        if (Input.GetKey(KeyCode.A) && transform.position.x >= -6)
        {
            transform.position -= new Vector3(1.0f, 0.0f, 0.0f) * Time.deltaTime * _speed;
        }
        // Move right and set a barrier
        else if (Input.GetKey(KeyCode.D) && transform.position.x <= 6)
        {
            transform.position += new Vector3(1.0f, 0.0f, 0.0f) * Time.deltaTime * _speed;
        }
    }

    // Activate text field upon call
    public void RevealTextField()
    {
        _textField.gameObject.SetActive(true);
    }
}
