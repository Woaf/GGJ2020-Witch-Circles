using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CutSceneManager : MonoBehaviour
{
    public GameObject raccoon;
    public GameObject trash;
    public GameObject trashInit;
    public GameObject moonBg;
    public GameObject sunBg;
    public GameObject hedgehog;
    public GameObject shroomCircle;

    private GameObject _newTrash;
    private Vector3 _trashOffset = new Vector3(-1, 0.5f, 0);
    private bool _threwTrash = false;
    private bool _raccoonShouldMove = true;
    private bool _raccoonDone = false;
    private bool _trashReached = false;
    private bool _circleReached = false;
    private bool _shouldDropTrash = false;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (!_raccoonDone)
            StartCoroutine(RaccoonScene());

        if (_raccoonDone)
            StartCoroutine(HedgehogScene());

        StartCoroutine(MoveBg());
    }

    IEnumerator RaccoonScene()
    {        
        yield return new WaitForSeconds(2);

        if (!_threwTrash && raccoon.transform.position.x > trashInit.transform.position.x)
        {
            _raccoonShouldMove = false;
            _threwTrash = true;
            raccoon.GetComponent<Animator>().SetFloat("Horizontal", 0);
            StartCoroutine(ThinkAngry());
        }
        else if(_raccoonShouldMove)
        {
            StartCoroutine(MoveToRight());
        }
        if (raccoon.transform.position.x > 5f)
            _raccoonDone = true;
    }

    IEnumerator MoveToRight()
    {
        yield return null;

        raccoon.transform.position += Vector3.right * Time.deltaTime * 7f;
        raccoon.GetComponent<Animator>().SetFloat("Horizontal", 1);
    }

    IEnumerator ThinkAngry()
    {
        yield return new WaitForSeconds(2);

        StartCoroutine(Drink());
    }

    IEnumerator Drink()
    {
        raccoon.GetComponent<Animator>().SetBool("IsDrinking", true);
        yield return new WaitForSeconds(2.8f);

        StartCoroutine(ThrowTrash());
    }

    IEnumerator ThrowTrash()
    {
        yield return null;
        _newTrash = Instantiate(trash, new Vector3(-2.0f, -1.6f, 0), Quaternion.identity);
        _newTrash.GetComponent<Rigidbody2D>().AddForce(new Vector2(0f, 5f), ForceMode2D.Impulse);
        raccoon.GetComponent<Animator>().SetBool("HasBottle", false);

        _raccoonShouldMove = true;
    }

    IEnumerator HedgehogScene()
    {
        yield return new WaitForSeconds(3f);

        if (!_trashReached)
        {
            hedgehog.transform.position = Vector2.MoveTowards(hedgehog.transform.position, _newTrash.transform.position, Time.deltaTime * 5f);
            hedgehog.GetComponent<Animator>().SetFloat("Horizontal", 1);

            if (Vector3.Distance(hedgehog.transform.position, _newTrash.transform.position) < 1f)
            {
                hedgehog.GetComponent<Animator>().SetFloat("Horizontal", 0);
                _trashReached = true;
            }
        }
        else
        {
            StartCoroutine(PickUpTrash());
        }
    }

    IEnumerator PickUpTrash()
    {
        yield return new WaitForSeconds(2f);

        if(!_shouldDropTrash)
            _newTrash.transform.position = hedgehog.transform.position + _trashOffset;

        StartCoroutine(MoveToCircle());
    }

    IEnumerator MoveToCircle()
    {
        yield return new WaitForSeconds(1f);

        if (!_circleReached)
        {
            hedgehog.transform.position = Vector2.MoveTowards(hedgehog.transform.position, shroomCircle.transform.position, Time.deltaTime * 7f);
            hedgehog.GetComponent<Animator>().SetFloat("Horizontal", 1);

            if (Vector3.Distance(hedgehog.transform.position, shroomCircle.transform.position) < 0.1f)
            {
                hedgehog.GetComponent<Animator>().SetFloat("Horizontal", 0);
                _circleReached = true;

                StartCoroutine(DropTrash());
            }
        }
        else
        {
            StartCoroutine(MoveAway());
        }

        Camera.main.transform.position = Vector3.MoveTowards(Camera.main.transform.position, new Vector3(2, -2, -10), Time.deltaTime);
    }

    IEnumerator DropTrash()
    {
        yield return new WaitForSeconds(0.5f);

        _shouldDropTrash = true;
    }

    IEnumerator MoveAway()
    {
        yield return new WaitForSeconds(1.5f);

        hedgehog.transform.position = Vector2.MoveTowards(hedgehog.transform.position, new Vector3(40, 5, 0), Time.deltaTime * 7f);

        StartCoroutine(RemoveTrash());
    }

    IEnumerator RemoveTrash()
    {
        yield return new WaitForSeconds(1.5f);

        Destroy(_newTrash);

        if (Vector3.Distance(hedgehog.transform.position, new Vector3(40, 5, 0)) < 1f)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }
    }

    IEnumerator MoveBg()
    {
        yield return null;

        moonBg.transform.position -= new Vector3(0.5f, 1, 0) * 0.0002f;
    }
}
