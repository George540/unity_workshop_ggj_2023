using TMPro;
using UnityEngine;

public class Player : MonoBehaviour
{
    public Rigidbody2D _Rigidbody2D;
    public float _Speed;
    public TextMeshProUGUI _textField;

    // FixedUpdate is called once per frame
    void FixedUpdate()
    {
        // Move left and set a barrier
        if (Input.GetKey(KeyCode.A) && _Rigidbody2D.position.x >= -6)
        {
            _Rigidbody2D.MovePosition(_Rigidbody2D.position - new Vector2(1.0f, 0.0f) * Time.deltaTime * _Speed);
        }
        // Move right and set a barrier
        else if (Input.GetKey(KeyCode.D) && _Rigidbody2D.position.x <= 6)
        {
            _Rigidbody2D.MovePosition(_Rigidbody2D.position + new Vector2(1.0f, 0.0f) * Time.deltaTime * _Speed);
        }
    }

    // Activate text field uppon call
    public void RevealTextField()
    {
        _textField.gameObject.SetActive(true);
    }
}
