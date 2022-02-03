using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationController : MonoBehaviour
{
    [SerializeField] private Animator stickAnimator;
    [SerializeField] private Animator playerAnimator;
    [SerializeField] private AbstractInputData tapHoldInputData;

    private void Start()
    {
        DragInputData.OnPlayerDrag += BendStick;
        DragInputData.OnPlayerLaunch += ReleaseStick;

        TapHoldInputData.OnHoldStart += PlayerSpreadWings;
        TapHoldInputData.OnHoldEnd += PlayerCloseWings;
    }

    private void OnDisable()
    {
        DragInputData.OnPlayerDrag -= BendStick;
        DragInputData.OnPlayerLaunch -= ReleaseStick;

        TapHoldInputData.OnHoldStart -= PlayerSpreadWings;
        TapHoldInputData.OnHoldEnd -= PlayerCloseWings;
    }

    private void BendStick(float bendValue)
    {
        stickAnimator.SetBool("IsBending", true);
    }

    private void ReleaseStick(float bendValue)
    {
        stickAnimator.SetBool("IsBending", false);
        stickAnimator.SetBool("IsReleasing", true);
    }

    private void PlayerSpreadWings()
    {
        playerAnimator.SetBool("IsWingsOpen", true);
        playerAnimator.SetBool("IsWingClose", false);
    }

    private void PlayerCloseWings()
    {
        playerAnimator.SetBool("IsWingsOpen", false);
        playerAnimator.SetBool("IsWingClose", true);
    }
}
