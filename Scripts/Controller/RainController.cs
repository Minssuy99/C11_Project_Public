using System.Collections;
using UnityEngine;
using DigitalRuby.RainMaker;

public class RainController : MonoBehaviour
{
    public GameObject rainPrefab; // 비 프리팹 오브젝트
    public float activationProbability = 0.1f; // 비가 올 확률
    public float activeDuration = 180f; // 비 지속시간
    public float checkInterval = 60f; // 몇초마다 비오는걸 체크할건지. ex) 300초마다 비가 올지 안올지를 결정하는 숫자.
    public float fadeOutDuration = 10f; // 비가 서서히 그치는 데 걸리는 시간

    public Animator RainStart;
    public Animator RainEnd;

    private BaseRainScript rainScript;

    private void Start()
    {
        rainScript = rainPrefab.GetComponent<BaseRainScript>();
        StartCoroutine(RainControlRoutine());
    }

    private IEnumerator RainControlRoutine()
    {
        while (true)
        {
            // 일정 확률로 활성화 여부 결정
            if (!rainPrefab.activeSelf && Random.value < activationProbability)
            {
                // 비 활성화
                rainPrefab.SetActive(true);
                RainStart.SetTrigger("RainingStart");
                rainScript.RainIntensity = 0.4f; // 비가 시작될 때의 최댓값
                yield return new WaitForSeconds(activeDuration);

                StartCoroutine(FadeOutRain()); // 비가 서서히 그치는 코루틴
                RainEnd.SetTrigger("RainingEnd");
            }

            // 다음 체크까지 대기
            yield return new WaitForSeconds(checkInterval);
        }
    }

    private IEnumerator FadeOutRain()
    {
        float startIntensity = rainScript.RainIntensity;
        float elapsed = 0f;

        while (elapsed < fadeOutDuration)
        {
            elapsed += Time.deltaTime;
            rainScript.RainIntensity = Mathf.Lerp(startIntensity, 0f, elapsed / fadeOutDuration);
            yield return null;
        }

        rainScript.RainIntensity = 0f;
        rainPrefab.SetActive(false);
    }

}
