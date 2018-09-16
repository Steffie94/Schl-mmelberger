using UnityEngine;
using System.Collections;

public class TimeSlow : MonoBehaviour {

    public float verlangsamung = 0.05f;
    public float verlangsamungZeit = 1f;

    private void Update()
    {
        //Korregiert DeltaTime
        Time.fixedDeltaTime = Time.timeScale * .02f;
        Time.timeScale += (1f / verlangsamungZeit) * Time.deltaTime;
        //Verhindert das das Spiel immer schneller wird
        Time.timeScale = Mathf.Clamp(Time.timeScale, 0f, 1f);
    }
    public void BulletTime()
    {
         Time.timeScale = verlangsamung;
    }
}
