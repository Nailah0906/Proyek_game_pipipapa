using UnityEngine;

public class EnemyAnimator : MonoBehaviour
{
    [Header("Animation Settings")]
    [SerializeField] private float wobbleSpeed = 10f;
    [SerializeField] private float wobbleAmount = 0.1f;
    [SerializeField] private Transform visualTransform;

    private Vector3 initialScale;

    private void Start()
    {
        if (visualTransform == null) visualTransform = transform;
        initialScale = visualTransform.localScale;
    }

    private void Update()
    {
        AnimateWobble();
    }

    private void AnimateWobble()
    {
        float wobble = Mathf.Sin(Time.time * wobbleSpeed) * wobbleAmount;
        
        visualTransform.localScale = initialScale + new Vector3(wobble, -wobble, 0);
    }
}