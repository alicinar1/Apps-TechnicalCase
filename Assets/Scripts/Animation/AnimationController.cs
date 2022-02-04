using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationController : MonoBehaviour
{
    [SerializeField] private Animator _stickAnimator;
    [SerializeField] private Animator _playerAnimator;
    [SerializeField] private AbstractInputData _tapHoldInputData;

    private void OnEnable()
    {
        DragInputData.OnPlayerDrag += BendStick;
        DragInputData.OnPlayerLaunch += ReleaseStick;
        DragInputData.OnPlayerLaunch += PlayerLaunchRolling;

        TapHoldInputData.OnHoldStart += PlayerSpreadWings;
        TapHoldInputData.OnHoldEnd += PlayerCloseWings;
    }

    private void OnDisable()
    {
        DragInputData.OnPlayerDrag -= BendStick;
        DragInputData.OnPlayerLaunch -= ReleaseStick;
        DragInputData.OnPlayerLaunch -= PlayerLaunchRolling;

        TapHoldInputData.OnHoldStart -= PlayerSpreadWings;
        TapHoldInputData.OnHoldEnd -= PlayerCloseWings;
    }

    private void BendStick(float bendValue)
    {
        _stickAnimator.SetBool("IsBending", true);
    }

    private void ReleaseStick(float bendValue)
    {
        _stickAnimator.SetBool("IsBending", false);
        _stickAnimator.SetBool("IsReleasing", true);
    }

    private void PlayerLaunchRolling(float bendValue)
    {
        _playerAnimator.SetBool("IsLaunched", true);
    }

    private void PlayerSpreadWings()
    {
        _playerAnimator.SetBool("IsWingsOpen", true);
        _playerAnimator.SetBool("IsWingClose", false);
    }

    private void PlayerCloseWings()
    {
        _playerAnimator.SetBool("IsWingsOpen", false);
        _playerAnimator.SetBool("IsWingClose", true);
    }
}
