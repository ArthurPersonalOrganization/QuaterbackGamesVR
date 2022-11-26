using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.Events;

public class TargetScript : MonoBehaviour
{
    [SerializeField]
    private int value;

    [SerializeField]
    private int multiplier;

    [Header("UI Elements")]
    [SerializeField]
    private Image outCircle;

    [SerializeField]
    private Image innerCircle;

    [SerializeField]
    private TMP_Text valueText;

    public Color defaultColor;
    public Color hitColor;

    [Header("Particle Systems")]
    public ParticleSystem x1;
    public ParticleSystem x2;
    public ParticleSystem x3;
    public ParticleSystem x4;

    [Header("Score System")]
    public UnityEvent targetHit;

    BoxCollider collider;

    private void Start()
    {
        collider = GetComponent<BoxCollider>();
        collider.enabled = true;
        valueText.text = "" + value;
        DefaultColors();
    }

     

    private void Update()
    {
        multiplier = (int)(Mathf.Abs(this.transform.localPosition.z) / 10);
    }

    private void OnCollisionEnter(Collision collision)
    { 
        if (collision.gameObject.tag == "Ball")
        {
            Debug.Log("Hit target at " + value);
            targetHit.Invoke();
            HitTarget();
        }
    }

    private void HitTarget()
    {
        StartCoroutine(HitTargetRoutine());
    }

    private void DefaultColors()
    {
     
        valueText.color = defaultColor;
        outCircle.color = defaultColor;
        innerCircle.color = defaultColor;
    }

    private void HitColors()
    {
        valueText.color = hitColor;
        outCircle.color = hitColor;
        innerCircle.color = hitColor;
    }

    IEnumerator HitTargetRoutine()
    {
        collider.enabled = false;
        HitColors();
        switch (multiplier)
        {
            case 1:
                x1.Play();
                break;

            case 2:
                x2.Play();
                break;

            case 3:
                x3.Play();
                break;

            case 4:
                x4.Play();
                break;
        }

        yield return new WaitForSeconds(2f);
        DefaultColors();
        collider.enabled = true;
    }

}
