using UnityEngine;
using UnityEngine.SceneManagement;

public class MobCreator : MonoBehaviour
{
    public GameObject[] gameObjects;
    public Transform[] mobCreators;

    public GameObject leftLongMobPivot0;
    public GameObject leftLongMobPivot90;
    public GameObject leftLongMobPivot180;
    public GameObject leftLongMobPivot270;
    public GameObject leftZMobPivot0;
    public GameObject leftZMobPivot90;
    public GameObject longMobPivot0;
    public GameObject longMobPivot90;
    public GameObject rightLongMobPivot0;
    public GameObject rightLongMobPivot90;
    public GameObject rightLongMobPivot180;
    public GameObject rightLongMobPivot270;
    public GameObject rightZMobPivot0;
    public GameObject rightZMobPivot90;
    public GameObject squareMob0;
    public GameObject tMobPivot0;
    public GameObject tMobPivot90;
    public GameObject tMobPivot180;
    public GameObject tMobPivot270;

    public Transform mobCreator0;
    public Transform mobCreator1;
    public Transform mobCreator2;
    public Transform mobCreator3;
    public Transform mobCreator4;
    public Transform mobCreator5;
    public Transform mobCreator6;
    public Transform mobCreator7;
    public Transform mobCreator8;
    public Transform mobCreator9;
    public Transform mobCreator10;
    public Transform mobCreator11;

    private float creatingSpeed;
    private float timeToCreate = 0;
    private float timeToFinishBattle = 0;
    int pointToCreate;
    int previousPointToCreate = -1;
    int objectToCreate;
    GameObject gameObjectToCreate;

    private void Start()
    {
        creatingSpeed = 1f - (DatabaseContainer.level - 1) * 0.0016f;
        Destroy(GameObject.Find("MenuMusic"));
    }

    private void FlagToChangeScene()
    {
        timeToFinishBattle += Time.deltaTime;
        if (timeToFinishBattle >= 60f)
        {
            Debug.Log(testCountMobs);
            SceneManager.LoadScene(0);
        }
    }

    private void CreatePointToCreate()
    {
        if (previousPointToCreate == -1)
        {
            pointToCreate = Random.Range(0, 13);
        }
        else
        {
            while (pointToCreate == previousPointToCreate || pointToCreate == previousPointToCreate - 1)
            {
                pointToCreate = Random.Range(0, 13);
            }
            previousPointToCreate = pointToCreate;
        }
    }

    private void SwitchObjectToCreate(int objectToCreate)
    {
        gameObjectToCreate = gameObjects[objectToCreate];
    }

    private void Switch1PointToCreate(int pointToCreate)
    {
        switch (pointToCreate)
        {
            case 0:
                if (objectToCreate == 0 ||
                    objectToCreate == 2 ||
                    objectToCreate == 5 ||
                    objectToCreate == 6 ||
                    objectToCreate == 8 ||
                    objectToCreate == 10 ||
                    objectToCreate == 13 ||
                    objectToCreate == 16 ||
                    objectToCreate == 18)
                {
                    Instantiate(gameObjectToCreate, mobCreator1.position, mobCreator1.rotation);
                }
                else
                {
                    Instantiate(gameObjectToCreate, mobCreator0.position, mobCreator0.rotation);
                }
                break;
            case 1:
                Instantiate(gameObjectToCreate, mobCreator1.position, mobCreator1.rotation);
                break;
            case 2:
                Instantiate(gameObjectToCreate, mobCreator2.position, mobCreator2.rotation);
                break;
            case 3:
                Instantiate(gameObjectToCreate, mobCreator3.position, mobCreator3.rotation);
                break;
            case 4:
                Instantiate(gameObjectToCreate, mobCreator4.position, mobCreator4.rotation);
                break;
            case 5:
                Instantiate(gameObjectToCreate, mobCreator5.position, mobCreator5.rotation);
                break;
            case 6:
                Instantiate(gameObjectToCreate, mobCreator6.position, mobCreator6.rotation);
                break;
            case 7:
                Instantiate(gameObjectToCreate, mobCreator7.position, mobCreator7.rotation);
                break;
            case 8:
                Instantiate(gameObjectToCreate, mobCreator8.position, mobCreator8.rotation);
                break;
            case 9:
                Instantiate(gameObjectToCreate, mobCreator9.position, mobCreator9.rotation);
                break;
            case 10:
                Instantiate(gameObjectToCreate, mobCreator10.position, mobCreator10.rotation);
                break;
            case 11:
                Instantiate(gameObjectToCreate, mobCreator11.position, mobCreator11.rotation);
                break;
        }
    }

    private void Switch2PointsToCreate(int pointToCreate)
    {
        switch (pointToCreate)
        {
            case 0:
                if (objectToCreate == 0 ||
                    objectToCreate == 2 ||
                    objectToCreate == 5 ||
                    objectToCreate == 6 ||
                    objectToCreate == 8 ||
                    objectToCreate == 10 ||
                    objectToCreate == 13 ||
                    objectToCreate == 16 ||
                    objectToCreate == 18)
                {
                    Instantiate(gameObjectToCreate, mobCreator1.position, mobCreator1.rotation);
                    Instantiate(gameObjectToCreate, mobCreator3.position, mobCreator3.rotation);
                }
                else
                {
                    Instantiate(gameObjectToCreate, mobCreator0.position, mobCreator0.rotation);
                    Instantiate(gameObjectToCreate, mobCreator2.position, mobCreator2.rotation);
                }
                break;
            case 1:
                Instantiate(gameObjectToCreate, mobCreator1.position, mobCreator1.rotation);
                Instantiate(gameObjectToCreate, mobCreator3.position, mobCreator3.rotation);
                break;
            case 2:
                Instantiate(gameObjectToCreate, mobCreator2.position, mobCreator2.rotation);
                Instantiate(gameObjectToCreate, mobCreator4.position, mobCreator4.rotation);
                break;
            case 3:
                Instantiate(gameObjectToCreate, mobCreator3.position, mobCreator3.rotation);
                Instantiate(gameObjectToCreate, mobCreator5.position, mobCreator5.rotation);
                break;
            case 4:
                Instantiate(gameObjectToCreate, mobCreator4.position, mobCreator4.rotation);
                Instantiate(gameObjectToCreate, mobCreator6.position, mobCreator6.rotation);
                break;
            case 5:
                Instantiate(gameObjectToCreate, mobCreator5.position, mobCreator5.rotation);
                Instantiate(gameObjectToCreate, mobCreator7.position, mobCreator7.rotation);
                break;
            case 6:
                Instantiate(gameObjectToCreate, mobCreator6.position, mobCreator6.rotation);
                Instantiate(gameObjectToCreate, mobCreator8.position, mobCreator8.rotation);
                break;
            case 7:
                Instantiate(gameObjectToCreate, mobCreator7.position, mobCreator7.rotation);
                Instantiate(gameObjectToCreate, mobCreator9.position, mobCreator9.rotation);
                break;
            case 8:
                Instantiate(gameObjectToCreate, mobCreator8.position, mobCreator8.rotation);
                Instantiate(gameObjectToCreate, mobCreator10.position, mobCreator10.rotation);
                break;
            case 9:
                Instantiate(gameObjectToCreate, mobCreator9.position, mobCreator9.rotation);
                Instantiate(gameObjectToCreate, mobCreator11.position, mobCreator11.rotation);
                break;
            case 10:
                Instantiate(gameObjectToCreate, mobCreator10.position, mobCreator10.rotation);
                break;
            case 11:
                Instantiate(gameObjectToCreate, mobCreator11.position, mobCreator11.rotation);
                break;
        }
    }

    private void Switch3PointsToCreate(int pointToCreate)
    {
        switch (pointToCreate)
        {
            case 0:
                if (objectToCreate == 0 ||
                    objectToCreate == 2 ||
                    objectToCreate == 5 ||
                    objectToCreate == 6 ||
                    objectToCreate == 8 ||
                    objectToCreate == 10 ||
                    objectToCreate == 13 ||
                    objectToCreate == 16 ||
                    objectToCreate == 18)
                {
                    Instantiate(gameObjectToCreate, mobCreator1.position, mobCreator1.rotation);
                    Instantiate(gameObjectToCreate, mobCreator3.position, mobCreator3.rotation);
                    Instantiate(gameObjectToCreate, mobCreator5.position, mobCreator5.rotation);
                }
                else
                {
                    Instantiate(gameObjectToCreate, mobCreator0.position, mobCreator0.rotation);
                    Instantiate(gameObjectToCreate, mobCreator2.position, mobCreator2.rotation);
                    Instantiate(gameObjectToCreate, mobCreator4.position, mobCreator4.rotation);
                }
                break;
            case 1:
                Instantiate(gameObjectToCreate, mobCreator1.position, mobCreator1.rotation);
                Instantiate(gameObjectToCreate, mobCreator3.position, mobCreator3.rotation);
                Instantiate(gameObjectToCreate, mobCreator5.position, mobCreator5.rotation);
                break;
            case 2:
                Instantiate(gameObjectToCreate, mobCreator2.position, mobCreator2.rotation);
                Instantiate(gameObjectToCreate, mobCreator4.position, mobCreator4.rotation);
                Instantiate(gameObjectToCreate, mobCreator6.position, mobCreator6.rotation);
                break;
            case 3:
                Instantiate(gameObjectToCreate, mobCreator3.position, mobCreator3.rotation);
                Instantiate(gameObjectToCreate, mobCreator5.position, mobCreator5.rotation);
                Instantiate(gameObjectToCreate, mobCreator7.position, mobCreator7.rotation);
                break;
            case 4:
                Instantiate(gameObjectToCreate, mobCreator4.position, mobCreator4.rotation);
                Instantiate(gameObjectToCreate, mobCreator6.position, mobCreator6.rotation);
                Instantiate(gameObjectToCreate, mobCreator8.position, mobCreator8.rotation);
                break;
            case 5:
                Instantiate(gameObjectToCreate, mobCreator5.position, mobCreator5.rotation);
                Instantiate(gameObjectToCreate, mobCreator7.position, mobCreator7.rotation);
                Instantiate(gameObjectToCreate, mobCreator9.position, mobCreator9.rotation);
                break;
            case 6:
                Instantiate(gameObjectToCreate, mobCreator6.position, mobCreator6.rotation);
                Instantiate(gameObjectToCreate, mobCreator8.position, mobCreator8.rotation);
                Instantiate(gameObjectToCreate, mobCreator10.position, mobCreator10.rotation);
                break;
            case 7:
                Instantiate(gameObjectToCreate, mobCreator7.position, mobCreator7.rotation);
                Instantiate(gameObjectToCreate, mobCreator9.position, mobCreator9.rotation);
                Instantiate(gameObjectToCreate, mobCreator11.position, mobCreator11.rotation);
                break;
            case 8:
                Instantiate(gameObjectToCreate, mobCreator8.position, mobCreator8.rotation);
                Instantiate(gameObjectToCreate, mobCreator10.position, mobCreator10.rotation);
                break;
            case 9:
                Instantiate(gameObjectToCreate, mobCreator9.position, mobCreator9.rotation);
                Instantiate(gameObjectToCreate, mobCreator11.position, mobCreator11.rotation);
                break;
            case 10:
                Instantiate(gameObjectToCreate, mobCreator10.position, mobCreator10.rotation);
                break;
            case 11:
                Instantiate(gameObjectToCreate, mobCreator11.position, mobCreator11.rotation);
                break;
        }
    }

    private int testCountMobs = 0;

    private void TestCountingMobs()
    {
        testCountMobs++;
    }

    private void FixedUpdate()
    {
        FlagToChangeScene();
        timeToCreate += Time.deltaTime;
        CreatePointToCreate();
        objectToCreate = Random.Range(0, 20);
        if (timeToCreate > creatingSpeed)
        {
            TestCountingMobs();
            timeToCreate = 0;
            SwitchObjectToCreate(objectToCreate);
            Debug.Log(DatabaseContainer.level);
            if (DatabaseContainer.level < 200)
            {
                Switch1PointToCreate(pointToCreate);
            }
            else if (DatabaseContainer.level >= 400)
            {
                Switch3PointsToCreate(pointToCreate);
            }
            else
            {
                Switch2PointsToCreate(pointToCreate);
            }
        }
    }
}
