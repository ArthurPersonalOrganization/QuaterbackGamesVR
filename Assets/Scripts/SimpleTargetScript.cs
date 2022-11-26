using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class SimpleTargetScript : MonoBehaviour
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

    [Header("Score System")]
    public UnityEvent targetHit;

    private BoxCollider collider;

    private void Start()
    {
        collider = GetComponent<BoxCollider>();
        collider.enabled = true;
        valueText.text = "" + value;
        DefaultColors();
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

    private IEnumerator HitTargetRoutine()
    {
        collider.enabled = false;
        HitColors();

        x1.Play();

        yield return new WaitForSeconds(2f);
        DefaultColors();
        collider.enabled = true;
    }
}