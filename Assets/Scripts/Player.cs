using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private float _speed = 5.0f;
    [SerializeField] private Transform _playerTransform;
    [SerializeField] private GameObject _plantPrefab;
    [SerializeField] private int _numSeeds = 5; 
    [SerializeField] private PlantCountUI _plantCountUI;

    private int _numSeedsLeft;
    private int _numSeedsPlanted;

    private void Start ()
    {
        _numSeedsLeft = _numSeeds;
        //ASSIGNS VALUE TO NUM SEEDS LEFT AT START
        _numSeedsPlanted = 0;
        //ASSIGNS VALUE TO NUM SEEDS PLANTED AT START
        _playerTransform.position = Vector3.zero;
    }

    private void Update()
    {
       if (Input.GetKey(KeyCode.W))
        {
            _playerTransform.Translate(Vector3.up * _speed * Time.deltaTime);
            //move up
        } 

        if (Input.GetKey(KeyCode.A))
        {
            _playerTransform.Translate(Vector3.left * _speed * Time.deltaTime);
            //move left
        }

        if (Input.GetKey(KeyCode.S))
        {
            _playerTransform.Translate(Vector3.down * _speed * Time.deltaTime);
            //move down
        }

        if (Input.GetKey(KeyCode.D))
        {
            _playerTransform.Translate(Vector3.right * _speed * Time.deltaTime);
            //move right
        }
//CONTROLS PLAYER MOVEMENT ^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^


    if(Input.GetKeyDown(KeyCode.Space) && _numSeeds > 0)
        {
            PlantSeed();
            

        }
//PLANTS SEED ON SPACE ^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^

    }

    public void PlantSeed ()
    {
        GameObject _plant = Instantiate(_plantPrefab) as GameObject;
        _plant.transform.position = new Vector3 (_playerTransform.position.x, _playerTransform.position.y, 0);
        _numSeedsLeft --;
        _numSeeds --;
        _numSeedsPlanted ++;
        _plantCountUI.UpdateSeeds(_numSeedsLeft,_numSeedsPlanted);
    }
}  