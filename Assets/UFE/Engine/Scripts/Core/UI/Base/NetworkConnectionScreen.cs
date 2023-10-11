using System.Net;

namespace UFE3D
{
	public class NetworkConnectionScreen : UFEScreen
	{
		public override void OnShow()
		{
			base.OnShow();

			UFE.multiplayerMode = UFE.MultiplayerMode.Online;
		}

		public virtual void ConnectToServer()
		{
			UFE.multiplayerAPI.OnInitializationSuccessful += this.OnInitializationSuccessful;
			UFE.multiplayerAPI.OnInitializationError += this.OnInitializationError;

			UFE.multiplayerAPI.Connect();
        }

		public virtual void OnInitializationSuccessful()
		{
			UFE.multiplayerAPI.OnInitializationSuccessful -= this.OnInitializationSuccessful;
			UFE.multiplayerAPI.OnInitializationError -= this.OnInitializationError;
		}

		public virtual void OnInitializationError()
		{
			UFE.multiplayerAPI.OnInitializationSuccessful -= this.OnInitializationSuccessful;
			UFE.multiplayerAPI.OnInitializationError -= this.OnInitializationError;
		}

		public virtual void GoToDirectMatchScreen()
		{
			// TODO: Add direct IP connection
		}

		public virtual void GoToBluetoothScreen()
		{
			UFE.StartBluetoothGameScreen();
		}

		public virtual void GoToMainMenu()
        {
			UFE.StartMainMenuScreen();
        }
	}
}