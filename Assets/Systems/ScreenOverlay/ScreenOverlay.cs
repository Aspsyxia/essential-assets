using System.Collections;
using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;

public class ScreenOverlay : MonoBehaviour
{
    private Image _overlayImage;
    public CanvasGroup canvasGroup { get; private set; }

    private void Awake()
    {
        canvasGroup = GetComponent<CanvasGroup>();
        canvasGroup.alpha = 0;

        if (_overlayImage == null) _overlayImage = GetComponentInChildren<Image>();
    }

    public IEnumerator ScreenFadeOut(float duration)
    {
        SystemsManager.Instance.screenOverlay.BlockInterfaceInteraction(true);
        yield return SystemsManager.Instance.screenOverlay.canvasGroup.DOFade(1, duration).WaitForCompletion();
    }

    public IEnumerator ScreenFadeIn(float duration)
    {
        yield return SystemsManager.Instance.screenOverlay.canvasGroup.DOFade(0, duration).WaitForCompletion();
        SystemsManager.Instance.screenOverlay.BlockInterfaceInteraction(false);
    }

    public void BlockInterfaceInteraction(bool state) => canvasGroup.blocksRaycasts = state;

    public void ReplaceOverlayImage(Sprite newSprite, Color newColor = default)
    {
        _overlayImage.color = newColor;
        _overlayImage.sprite = newSprite;
    }
}
