using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum TransitionParameter
{
    Move,
    Jump,
    DoubleJump,
    ForceTransition,
    Grounded,
    TransitionIndex,
}

public class CharacterControl : MonoBehaviour
{
    public Animator SkinnedMeshAnimator;
    public bool MoveRight;
    public bool MoveLeft;
    public bool MoveUp;
    public bool MoveDown;
    public bool Jump;
    public bool DoubleJump;
    public bool CharacterSwitchRight;
    public bool CharacterSwitchLeft;
    public GameObject ColliderEdgePrefab;
    public List<GameObject> BottomSpheres = new List<GameObject>();
    public List<GameObject> FrontSpheres = new List<GameObject>();
    public float GravityMultiplier;
    public float PullMultiplier;

    private Dictionary<string, GameObject> ChildObjects = new Dictionary<string, GameObject>();

    private Rigidbody rigid;
    public Rigidbody RIGID_BODY
    {
        get
        {
            if (rigid == null)
            {
                rigid = GetComponent<Rigidbody>();
            }
            return rigid;
        }
    }
    
    private void Awake()
    {
        bool SwitchBack = false;

        if (!IsFacingForward())
        {
            SwitchBack = true;
        }

        FaceForward(true);

        SetColliderSpheres();

        if (SwitchBack)
        {
            FaceForward(false);
        }
    }


    // ground detection and collision
    private void SetColliderSpheres()
    {
        CapsuleCollider box = GetComponent<CapsuleCollider>();

        float bottom = box.bounds.center.y - box.bounds.extents.y;
        float top = box.bounds.center.y + box.bounds.extents.y;
        float front = box.bounds.center.z + box.bounds.extents.z;
        float back = box.bounds.center.z - box.bounds.extents.z;

        GameObject bottomFrontHor = CreateEdgeSphere(new Vector3(front, bottom, 0f));
        GameObject bottomFrontVer = CreateEdgeSphere(new Vector3(front, 0.05f, 0f));
        GameObject bottomBack = CreateEdgeSphere(new Vector3(back, bottom, 0f));
        GameObject topFront = CreateEdgeSphere(new Vector3(front, top, 0f));

        bottomFrontHor.transform.parent = this.transform;
        bottomFrontVer.transform.parent = this.transform;
        bottomBack.transform.parent = this.transform;
        topFront.transform.parent = this.transform;

        BottomSpheres.Add(bottomFrontHor);
        BottomSpheres.Add(bottomBack);

        FrontSpheres.Add(bottomFrontVer);
        FrontSpheres.Add(topFront);

        float horSec = (bottomFrontHor.transform.position - bottomBack.transform.position).magnitude / 5f;
        CreateMiddleSpheres(bottomFrontHor, -this.transform.right, horSec, 4, BottomSpheres);

        float verSec = (bottomFrontVer.transform.position - topFront.transform.position).magnitude / 10f;
        CreateMiddleSpheres(bottomFrontVer, this.transform.up, verSec, 9, FrontSpheres);
    }

    private void FixedUpdate()
    {
        if (RIGID_BODY.velocity.y < 0f)
        {
            RIGID_BODY.velocity += (-Vector3.up * GravityMultiplier);
        }

        if (RIGID_BODY.velocity.y > 0f && !Jump)
        {
            RIGID_BODY.velocity += (-Vector3.up * PullMultiplier);
        }
    }

    public void CreateMiddleSpheres(GameObject start, Vector3 dir, float sec, int interations, List<GameObject> spheresList)
    {
        for (int i = 0; i < interations; i++)
        {
            Vector3 pos = start.transform.position + (dir * sec * (i + 1));

            GameObject newObj = CreateEdgeSphere(pos);
            newObj.transform.parent = this.transform;
            spheresList.Add(newObj);
        }
    }

    public GameObject CreateEdgeSphere(Vector3 pos)
    {
        GameObject obj = Instantiate(ColliderEdgePrefab, pos, Quaternion.identity);
        return obj;
    }

    // move forward
    public void MoveForward(float Speed, float SpeedGraph)
    {
        transform.Translate(Vector3.right * Speed * SpeedGraph * Time.deltaTime);
    }

    public void FaceForward(bool forward)
    {
        if (forward)
        {
            transform.rotation = Quaternion.Euler(0f, 0f, 0f);
        }

        else
        {
            transform.rotation = Quaternion.Euler(0f, 180f, 0f);
        }
    }

    public bool IsFacingForward()
    {
        if (transform.forward.z > 0f)
        {
            return true;
        }

        else
        {
            return false;
        }
    }

    public GameObject GetChildObj(string name)
    {
        if (ChildObjects.ContainsKey(name))
        {
            return ChildObjects[name];
        }

        Transform[] arr = this.gameObject.GetComponentsInChildren<Transform>();

        foreach (Transform t in arr)
        {
            if (t.gameObject.name.Equals(name))
            {
                ChildObjects.Add(name, t.gameObject);
                return t.gameObject;
            }
        }

        return null;
    }
}
 
