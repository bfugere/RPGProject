using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using RPG.Movement;

namespace RPG.Control
{
    public class PlayerController : MonoBehaviour
    {
        Move move;

        void Start()
        {
            move = GetComponent<Move>();
        }

        void Update()
        {
            if (Input.GetMouseButton(0))
                MoveToCursor();
        }

        void MoveToCursor()
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            bool hasHit = Physics.Raycast(ray, out RaycastHit hitInfo);

            if (hasHit)
                move.MoveTo(hitInfo.point);
        }
    }
}
