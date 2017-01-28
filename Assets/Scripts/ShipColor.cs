using System.Collections.Generic;
using UnityEngine;

public class ShipColor : MonoBehaviour {
	public int playerNumber;

	public float cooldownTimeAmount = 3.0f;
	public float cooldownTimer = 0.0f;

	public bool isInvulnerable = false;

	public GameObject Prims;

	public Material GreenPrism;
	public Material RedPrism;
	public Material BluePrism;
	public Material YellowPrism;

	public ParticleSystem[]orbiterParticles;
	public ParticleSystem wakeParticles;
	public ParticleSystem wakeParticleBurst;
	private bool particlesOn;

    private Dictionary<GameManager.PlayerColor, Material> _materialsByPlayerColor;

    GameManager.PlayerColor GetInputPlayerColor(int playerNumber) {
        switch (playerNumber) {
            case 1:
                if (InputManager.IsP1GreenDown) {
                    return GameManager.PlayerColor.Green;
                } else if (InputManager.IsP1RedDown) {
                    return GameManager.PlayerColor.Red;
                } else if (InputManager.IsP1BlueDown) {
                    return GameManager.PlayerColor.Blue;
                } else if (InputManager.IsP1YellowDown) {
                    return GameManager.PlayerColor.Yellow;
                }
                break;

            case 2:
                if (InputManager.IsP2GreenDown) {
                    return GameManager.PlayerColor.Green;
                } else if (InputManager.IsP2RedDown) {
                    return GameManager.PlayerColor.Red;
                } else if (InputManager.IsP2BlueDown) {
                    return GameManager.PlayerColor.Blue;
                } else if (InputManager.IsP2YellowDown) {
                    return GameManager.PlayerColor.Yellow;
                }
                break;

            case 3:
                if (InputManager.IsP3GreenDown) {
                    return GameManager.PlayerColor.Green;
                } else if (InputManager.IsP3RedDown) {
                    return GameManager.PlayerColor.Red;
                } else if (InputManager.IsP3BlueDown) {
                    return GameManager.PlayerColor.Blue;
                } else if (InputManager.IsP3YellowDown) {
                    return GameManager.PlayerColor.Yellow;
                }
                break;

            case 4:
                if (InputManager.IsP4GreenDown) {
                    return GameManager.PlayerColor.Green;
                } else if (InputManager.IsP4RedDown) {
                    return GameManager.PlayerColor.Red;
                } else if (InputManager.IsP4BlueDown) {
                    return GameManager.PlayerColor.Blue;
                } else if (InputManager.IsP4YellowDown) {
                    return GameManager.PlayerColor.Yellow;
                }
                break;
        }

        return GameManager.PlayerColor.Dead;
    }

    bool CheckColorChanged(int playerNumber, out GameManager.PlayerColor newPlayerColor) {
        newPlayerColor = GetInputPlayerColor(playerNumber);

        if ((newPlayerColor != GameManager.PlayerColor.Dead) && (newPlayerColor != GameManager._GAMEMANAGER.GetPlayerColor(playerNumber))) {
            return true;
        }

        return false;
    }

	// Use this for initialization
	void Start()
	{
        _materialsByPlayerColor = new Dictionary<GameManager.PlayerColor, Material>() {
            { GameManager.PlayerColor.Red, RedPrism },
            { GameManager.PlayerColor.Blue, BluePrism },
            { GameManager.PlayerColor.Green, GreenPrism },
            { GameManager.PlayerColor.Yellow, YellowPrism },
        };

		if (playerNumber == 1) {
			ParticleColors (Color.yellow);
			WakeParticles (Color.yellow);
            Prims.GetComponent<MeshRenderer>().material = YellowPrism;
		} else if (playerNumber == 2) {
			ParticleColors (Color.red);
			WakeParticles (Color.red);
            Prims.GetComponent<MeshRenderer>().material = RedPrism;
		} else if (playerNumber == 3) {
			ParticleColors (Color.blue);
			WakeParticles (Color.blue);
            Prims.GetComponent<MeshRenderer>().material = BluePrism;
		} else if (playerNumber == 4) {
			ParticleColors (Color.green);
			WakeParticles (Color.green);
            Prims.GetComponent<MeshRenderer>().material = GreenPrism;
		}
	}

	// Update is called once per frame
	void Update() {
		if (cooldownTimer <= Time.time) {
			EnableParticles ();
		}

        if (GameManager._GAMEMANAGER.gameState != GameManager.GameState.CoinGameMode) {
            return;
        }

        if (cooldownTimer > Time.time) {
            return;
        }

        GameManager.PlayerColor newPlayerColor;
        if (CheckColorChanged(playerNumber, out newPlayerColor)) {
            Prims.GetComponent<MeshRenderer>().material = _materialsByPlayerColor[newPlayerColor];
            cooldownTimer = (Time.time + cooldownTimeAmount);
            GameManager._GAMEMANAGER.SetPlayerColor(playerNumber, newPlayerColor);
            Color newColor = GameManager.PlayerColorToColor(newPlayerColor);
            GetComponent<ShipGridManager>().colorWake.m_Color = newColor;
            GameManager._GAMEMANAGER.UIObject.GetComponent<GameUI>().UpdateColor(playerNumber, newPlayerColor);
            DisableParticles();
            ParticleColors(newColor);
            WakeParticles(newColor);
            AudioManager._AUDIOMANAGER.playSound("SwapColor");
        }
	}

	public void ParticleColors(Color allButThisColor)
	{
		var color1 = orbiterParticles[0].main;
		var color2 = orbiterParticles[1].main;
		var color3 = orbiterParticles[2].main;
		if (allButThisColor == Color.green) {
			color1.startColor = Color.red;
			color2.startColor = Color.yellow;
			color3.startColor = Color.blue;
		}else if(allButThisColor == Color.red){
			color1.startColor = Color.green;
			color2.startColor = Color.yellow;
			color3.startColor = Color.blue;
		}else if(allButThisColor == Color.yellow){
			color1.startColor = Color.blue;
			color2.startColor = Color.green;
			color3.startColor = Color.red;
		}else if(allButThisColor == Color.blue){
			color1.startColor = Color.red;
			color2.startColor = Color.green;
			color3.startColor = Color.yellow;
		}
	}

	public void WakeParticles(Color switchToMe)
	{
		var color1 = wakeParticles.main;
		var color2 = wakeParticleBurst.main;
		if (switchToMe == Color.green) {
			color1.startColor = Color.green;
			color2.startColor = Color.green;
			wakeParticleBurst.Emit (100);
		}else if(switchToMe == Color.red){
			color1.startColor = Color.red;
			color2.startColor = Color.red;
			wakeParticleBurst.Emit (100);
		}else if(switchToMe == Color.yellow){
			color1.startColor = Color.yellow;
			color2.startColor = Color.yellow;
			wakeParticleBurst.Emit (100);
		}else if(switchToMe == Color.blue){
			color1.startColor = Color.blue;
			color2.startColor = Color.blue;
			wakeParticleBurst.Emit (100);
		}
	}

	public void EnableParticles()
	{
		if (particlesOn == false) {
			foreach (ParticleSystem temp in orbiterParticles) {
				temp.Play ();
			}
			particlesOn = true;
		}
	}

	public void DisableParticles()
	{
		if (particlesOn == true) {
			foreach (ParticleSystem temp in orbiterParticles) {
				temp.Stop ();
			}
			particlesOn = false;
		}
	}
}
