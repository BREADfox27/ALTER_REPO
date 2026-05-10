using UnityEngine;

public class AnimationController : MonoBehaviour
{
    public float minTime = 5f;
    public float maxTime = 10f;

    private Animator anim;
    private float timer;
    private bool isDoingSpecial = false;



    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        anim = GetComponent<Animator>();
        ResetTimer();
    }

    // Update is called once per frame
    void Update()
    {
        if (isDoingSpecial) return;

        timer -= Time.deltaTime;

        if (timer <= 0f)
        {
            anim.SetBool("DoIdleSpecial", true);
            isDoingSpecial = true;
        }
    }


    // Llamado desde un Animation Event al final del IdleSpecial
    public void OnIdleSpecialFinished()
    {
        anim.SetBool("DoIdleSpecial", false);
        isDoingSpecial = false;
        ResetTimer();
    }

    void ResetTimer()
    {
        timer = Random.Range(minTime, maxTime);
    }
}
