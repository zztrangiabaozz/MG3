using UnityEngine;

public class KickWeapon : MonoBehaviour
{
    [SerializeField] private float _lifetimeSeconds;
    [SerializeField] private Timer _lifeTimer;

    // ------------------------------------------------------------------------
    public void ActivateKick()
    {
        gameObject.SetActive(true);

        // STEP 6 -------------------------------------------------------------
        // In addition to accessing member variables from an object with '.',
        //      we can also call methods.
        // Uncomment the below line and pass _lifetimeSeconds as an ARGUMENT
        //      to the method in order to start our timer with the number
        //      of seconds that _lifetimeSeconds is set to.

        _lifeTimer.BeginTimer(_lifetimeSeconds);

        // STEP 6 -------------------------------------------------------------
    }

    // STEP 7 -----------------------------------------------------------------
    // Finally, we need to check EVERY FRAME for when the timer has run up.
    //
    // Uncomment the below method and replace the ???s with the method name.
    // This is a built-in method from Unity that runs EVERY FRAME.
    //
    private void Update()
    {
        
        // In the body of this method, we want to check if the timer has run out,
        //      and disable the KickWeapon when it's done.
        // Simply uncomment the lines once you've written the method.

        if (_lifeTimer.IsFinished())
        {
            gameObject.SetActive(false);
        }

    }
    // STEP 7 -----------------------------------------------------------------
}