using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ladder : MonoBehaviour
{
    enum LadderPart { Complete, Top, Bottom };
    [SerializeField] LadderPart ladderPart = LadderPart.Complete;

    void OnTriggerEnter2D(Collider2D other) {
        if (other.GetComponent<PlayerMovement>()) {
            PlayerMovement player = other.GetComponent<PlayerMovement>();

            switch (ladderPart) {
                case LadderPart.Complete:
                    player.canClimb = true;
                    player.ladder = this;
                    break;
                case LadderPart.Bottom:
                    player.bottomLadder = true;
                    break;
                case LadderPart.Top:
                    player.topLadder = true;
                    break;
                default:
                    break;
            }
        }
    }

    void OnTriggerExit2D(Collider2D other) {
        if (other.GetComponent<PlayerMovement>()) {
            PlayerMovement player = other.GetComponent<PlayerMovement>();

            switch (ladderPart) {
                case LadderPart.Complete:
                    player.canClimb = false;
                    player.ladder = null;
                    break;
                case LadderPart.Bottom:
                    player.bottomLadder = false;
                    break;
                case LadderPart.Top:
                    player.topLadder = false;
                    break;
                default:
                    break;
            }
        }
    }
}
