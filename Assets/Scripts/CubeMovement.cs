using UnityEngine;
using UnityEngine.UI;

public class CubeMovement : MonoBehaviour
{
    [SerializeField]
    float _speed;

    public Text phaseDisplayText;
    private Vector2 touchStartPos;

    // Start is called before the first frame update
    void Start()
    {
        _speed = 5f;
        transform.position = new Vector2(0, 0);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.touchCount > 0)
        {
            Touch theTouch = Input.GetTouch(0);

            switch (theTouch.phase)
            {
                case TouchPhase.Began:
                    touchStartPos = theTouch.position;
                    break;

                case TouchPhase.Moved:
                    Vector2 touchDelta = theTouch.position - touchStartPos;
                    Move(touchDelta);
                    touchStartPos = theTouch.position;
                    break;
            }
        }
    }

    void Move(Vector2 touchDelta)
    {
        float adjustedSpeed = _speed * 0.005f;
        transform.Translate(touchDelta * adjustedSpeed);
    }
}
