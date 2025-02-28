using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class VehicleController : MonoBehaviour
{

    [SerializeField] private float carSpeed;
    [SerializeField] private float turnSpeed;
    private float baseTurnSpeed;
    private float horizontalInput;
    private float verticalInput;
    public Camera mainCamera;
    public Camera firstpersonCamera;
    public KeyCode switchKey;
    
    private EndGame endGame;
    private bool stopGame = false;
    
    public GameOver gameOver;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        endGame = FindObjectOfType<EndGame>();
        baseTurnSpeed = turnSpeed;
    }

    // Update is called once per frame
    void Update()
    {
        if (stopGame) return;

        horizontalInput = Input.GetAxis("Horizontal");
        verticalInput = Input.GetAxis("Vertical");

        float currentTurnSpeed = Input.GetKey("space") ? baseTurnSpeed * 3 : baseTurnSpeed;

        //Move the vehicle forward
        transform.Translate(Vector3.forward * Time.deltaTime * carSpeed * verticalInput);
        //Rotates the car
        transform.Rotate(Vector3.up, currentTurnSpeed * horizontalInput * Time.deltaTime);

        if (Input.GetKeyDown(switchKey)){
            mainCamera.enabled = !mainCamera.enabled;
            firstpersonCamera.enabled = !firstpersonCamera.enabled;
        }
    }

    private void OnTriggerEnter(Collider other){
        if (other.CompareTag("Obstacle")){
            endGame.loseGame();
            stopGame = true;
            gameOverScreen();
        }

        else if (other.CompareTag("FinishLine")){
            endGame.winGame();
            stopGame = true;
            gameOverScreen();
        }
    }

    public void gameOverScreen(){
        gameOver.setUp();
    }
}
