using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using RPG.Movement;
using RPG.Combat;

namespace RPG.Control
{
    public class PlayerController : MonoBehaviour
    {
        Mover mover;

        void Start()
        {
            mover = GetComponent<Mover>();
        }

        void Update()
        {
            InteractWithCombat();
            InteractWithMovement();
        }

        void InteractWithCombat()
        {
            RaycastHit[] hits = Physics.RaycastAll(GetMouseRay());

            foreach (RaycastHit hit in hits)
            {
                CombatTarget target = hit.transform.GetComponent<CombatTarget>();

                if (target == null)
                    continue;

                if (Input.GetMouseButtonDown(0))
                    GetComponent<Fighter>().Attack(target);
            }
        }

        void InteractWithMovement()
        {
            if (Input.GetMouseButton(0))
                MoveToCursor();
        }

        void MoveToCursor()
        {
            bool hasHit = Physics.Raycast(GetMouseRay(), out RaycastHit hitInfo);

            if (hasHit)
                mover.MoveTo(hitInfo.point);

            Debug.DrawRay(GetMouseRay().origin, GetMouseRay().direction * 100, Color.red);
        }

        static Ray GetMouseRay()
        {
            return Camera.main.ScreenPointToRay(Input.mousePosition);
        }
    }
}
