using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    //get children
    public GameObject parent;
    public GameObject people;
    public GameObject brickPoint;
    public GameObject sstack;

    //get rigidbody
    private Rigidbody rb;

    //movement
    public float speed = 5.0f;
    public bool isMoving = false;
    public Vector3 dir = new Vector3(0, 0, 0);
    public int stack = 0;

    // Start is called before the first frame update
    void Start()
    {
        parent = this.gameObject;
        people = parent.transform.GetChild(0).gameObject;
        brickPoint = parent.transform.GetChild(1).gameObject;
        rb = GetComponent<Rigidbody>();
        rb.freezeRotation = true;

    }

    // Update is called once per frame
    void Update()
    {
        check(dir);
        
        if (Input.GetKeyDown("w") && !isMoving)
        {
            dir = new Vector3(0, 0, 1);
            isMoving = true;

        }
        else if (Input.GetKeyDown("s") && !isMoving)
        {
            dir = new Vector3(0, 0, -1);
            isMoving = true;
        }
        else if (Input.GetKeyDown("a") && !isMoving)
        {
            dir = new Vector3(-1, 0, 0);
            isMoving = true;
        }
        else if (Input.GetKeyDown("d") && !isMoving)
        {
            dir = new Vector3(1, 0, 0);
            isMoving = true;
        }

        if (Input.GetKeyDown("space"))
        {
            AddBrick();
        }

        if (isMoving)
        {
            move(dir);
        }

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Bridge")
        {
            RemoveBrick();
            Debug.Log(stack);

        }
        if (other.gameObject.tag == "Stack")
        {
            AddBrick();
            Debug.Log(stack);

        }
        if (other.gameObject.tag == "Chest")
        {
            Finish();
            Debug.Log("Yay");

        }
    }

    void check(Vector3 dir)
    {

        if (Physics.Raycast(transform.position, dir, 0.5f))
        {
            //Debug.Log("Hit");
            dir = new Vector3(0, 0, 0);
            //rb.velocity = Vector3.zero;
            //rb.angularVelocity = Vector3.zero;
            //transform.Translate(new Vector3(1, 0, 0) * 30 * Time.deltaTime);
            isMoving = false;
        }

    }
    void move(Vector3 dir)
    {
        
        transform.Translate(dir *5* Time.deltaTime);

    }
    void getStack()
    {
        parent.transform.Translate(Vector3.up);
        Instantiate(sstack, brickPoint.transform.position, Quaternion.LookRotation(Vector3.up, Vector3.up), parent.transform);
        stack++;

    }
    void placeStack()
    {
        people.transform.localPosition = Vector3.down;
        stack--;
    }
    void clearStack()
    {

    }
    void Finish()
    {
        UIManagerScript.Instance.ShowFinishMenu(10);
    }

    public Brick brickPrefab;
    public Transform brickParent;
    public List<Brick> bricks = new List<Brick>();

    public void AddBrick()
    {
        //tao brick trong brick parent
        Brick brick = Instantiate(brickPrefab, brickParent);
        //dat lai vi tri chieu cao brick
        brick.transform.localPosition = new Vector3(0, stack * 0.25f, 0);
        // cho nhan vat cao len
        people.transform.localPosition = new Vector3(0,(stack + 1)* 0.5f , 0);
        //character.localPosition.
        bricks.Add(brick);
        stack++;
    }

    public void RemoveBrick()
    {
        if (bricks.Count > 0)
        {
            Brick brick = bricks[bricks.Count - 1];
            bricks.RemoveAt(bricks.Count - 1);
            Destroy(brick.gameObject);
            stack--;
            people.transform.localPosition = new Vector3(0, (stack + 1) * 0.5f, 0);

        }
        else
        {
            UIManagerScript.Instance.ShowLoseMenu() ;
        }
    }

    public void ClearBrick()
    {

    }
}
