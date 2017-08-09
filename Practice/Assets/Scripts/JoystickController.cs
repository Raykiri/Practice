using UnityEngine;

public class JoystickController : MonoBehaviour {

    public  float   joystickSize;
    public  Vector2 rectPosition;
    private Vector3 currentDirection;
    private Vector2 lastDirection;
    private Vector2 stickPosition;
    private float   size;
    private Rect    touchable;
    private Vector2 origin;
    private bool    mousePressed;
    [SerializeField]
    private bool   fingerWasInRect;

    public Vector3 Direction
    {
        get { return currentDirection; }
    }
    void Start ()
    {
        Resize();
        origin = touchable.center;
        transform.GetChild(0).position = origin;
    }	
	void Update ()
    {
        currentDirection = GetDirection();
        SetStick();
    }
    private Vector3 GetDirection()
    {
        Vector2 direction;
        if (mousePressed && !(Input.GetMouseButton(0)))
            mousePressed = false;
        if(Input.touchCount > 0)
        {
            foreach(Touch touch in Input.touches)
            {
                if (touch.phase == TouchPhase.Ended)
                fingerWasInRect = false;
                if (touch.fingerId == 0)
                {
                    if (IsInRect(touch.position))
                    {
                        direction = touch.position - origin;
                        direction.Normalize();
                        fingerWasInRect = true;
                        if (lastDirection != direction)
                            lastDirection = direction;
                        if (stickPosition != touch.position)
                            stickPosition = touch.position;
                        return direction;
                    }
                    if (touch.phase != TouchPhase.Ended && fingerWasInRect)
                    {
                        direction = touch.position - origin;
                        direction.Normalize();
                        Vector2 stickDirection = origin + direction * (size / 2);
                        if (lastDirection != direction)
                            lastDirection = direction;
                        if (stickPosition != stickDirection)
                            stickPosition = stickDirection;
                        return direction;
                    }
                    stickPosition = origin;
                    return new Vector3(0, 0, 0);
                }
            }
        }
        else if (Input.GetMouseButton(0))
        {
            Vector2 position = Input.mousePosition;
            bool leftIsPressed = Input.GetMouseButton(0);
            if (IsInRect(position) && leftIsPressed)
            {
                mousePressed = true;
                direction = position - origin;
                direction.Normalize();
                if (lastDirection != direction)
                    lastDirection = direction;
                if (stickPosition != position)
                    stickPosition = position;
                return direction;
            }
            if (leftIsPressed && mousePressed)
            {
                direction = position - origin;
                direction.Normalize();
                Vector2 stickDirection = origin + direction * (size / 2);
                if (lastDirection != direction)
                    lastDirection = direction;
                if (stickPosition != stickDirection)
                    stickPosition = stickDirection;
                return direction;
            }
            stickPosition = origin;
            return new Vector3(0, 0, 0);
        }
        fingerWasInRect = false;
        stickPosition = origin;
        return new Vector3();
    }
    private void Resize()
    {
        const float backGroundSize = 2.5f;
        size = joystickSize * Screen.height / 480 * Screen.width / 854;
        transform.GetChild(0).localScale = new Vector3(backGroundSize, backGroundSize, backGroundSize);
        touchable = new Rect(rectPosition, new Vector2(size, size));
    }
    private void SetStick()
    {
        transform.GetChild(1).position = stickPosition;
    }
    private bool IsInRect(Vector2 position)
    {
        return (position.x >= touchable.position.x && position.x <= touchable.position.x + size &&
                position.y >= touchable.position.y && position.y <= touchable.position.y + size );
    }
}
