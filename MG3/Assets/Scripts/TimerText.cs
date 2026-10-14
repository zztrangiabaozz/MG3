using UnityEngine;
using TMPro;

public class TimerText : MonoBehaviour
{
    [SerializeField] private GameObject _gameOverText;
    [SerializeField] private Player _player;
    [SerializeField] private float _maxGameTime = 30.0f;
    [SerializeField] private TMP_Text _timerDisplay;
    [SerializeField] private Timer _gameTimer;

    // STEP 8 -----------------------------------------------------------------
    // This method runs ONCE, when the GAME BEGINS. It is called by Unity.
    // Uncomment this method and fill in the method name.
    //
    private void Start()
    {
        _gameTimer.BeginTimer(_maxGameTime);
            // Inside this method, CALL the BeginTimer method on _gameTimer.
            // Pass in _maxGameTime as the ARGUMENT.
    }
    // STEP 8 -----------------------------------------------------------------

    // ------------------------------------------------------------------------
    private void Update()
    {
        // STEP 9 -------------------------------------------------------------
        // Inside this Update method, we're going to CHECK IF OUR TIMER RAN OUT.
        // IF it's done, CALL the GameOver method.
        // 
        // If you need a hint, check how the KickWeapon class did this.
        // But remember the timer object in this class is _gameTimer.
        //
        // Write your if statement below.
        if (_gameTimer.IsFinished())
        {
            GameOver();
        }

        // STEP 9 -------------------------------------------------------------

        _timerDisplay.text = _gameTimer.GetTimeLeft().ToString();
    }
    
    // ------------------------------------------------------------------------
    private void GameOver ()
    {
        _player.SetGameOver();
        _gameOverText.SetActive(true);
    }
}