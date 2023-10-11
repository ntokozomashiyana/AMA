using UnityEngine;
using System.Collections.Generic;
using UnityEngine.UI;
using UFE3D;

public class DefaultNetworkConnectionScreen : NetworkConnectionScreen {
	#region public instance fields
	public AudioClip onLoadSound;
	public AudioClip music;
	public AudioClip selectSound;
	public AudioClip cancelSound;
	public AudioClip moveCursorSound;
	public float delayBeforePlayingMusic = 0.1f;
    public Button buttonConnect;
	public Button buttonBluetooth;
	public Text connectionInfo;
    #endregion

    #region public override methods
    public override void DoFixedUpdate(
		IDictionary<InputReferences, InputEvents> player1PreviousInputs,
		IDictionary<InputReferences, InputEvents> player1CurrentInputs,
		IDictionary<InputReferences, InputEvents> player2PreviousInputs,
		IDictionary<InputReferences, InputEvents> player2CurrentInputs
	){
		base.DoFixedUpdate(player1PreviousInputs, player1CurrentInputs, player2PreviousInputs, player2CurrentInputs);

		this.DefaultNavigationSystem(
			player1PreviousInputs,
			player1CurrentInputs,
			player2PreviousInputs,
			player2CurrentInputs,
			this.moveCursorSound,
			this.selectSound,
			this.cancelSound,
			this.GoToMainMenu
		);
	}

	public override void OnShow()
	{
		base.OnShow();

		connectionInfo.text = "";

		this.HighlightOption(this.FindFirstSelectable());

		if (this.music != null)
		{
			UFE.DelayLocalAction(delegate () { UFE.PlayMusic(this.music); }, this.delayBeforePlayingMusic);
		}

		if (this.onLoadSound != null)
		{
			UFE.DelayLocalAction(delegate () { UFE.PlaySound(this.onLoadSound); }, this.delayBeforePlayingMusic);
		}

		if (buttonConnect != null)
		{
			buttonConnect.interactable = UFE.isNetworkAddonInstalled;
		}

		if (buttonBluetooth != null)
		{
			buttonBluetooth.interactable = UFE.isBluetoothAddonInstalled;
		}
	}

    public override void ConnectToServer()
    {
        base.ConnectToServer();
		buttonConnect.interactable = false;
		connectionInfo.text = "Connecting...";
	}
    public override void OnInitializationSuccessful()
    {
        base.OnInitializationSuccessful();
		connectionInfo.text = "Connected";
		UFE.StartNetworkOptionsScreen();
	}

    public override void OnInitializationError()
	{
		base.OnInitializationError();
		connectionInfo.text = "Connection Error";
    }
    #endregion
}
