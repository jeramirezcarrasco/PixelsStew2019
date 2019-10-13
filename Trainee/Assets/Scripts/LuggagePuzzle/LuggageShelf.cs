using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LuggageShelf : MonoBehaviour
{
    public Collider2D[] ShelfBlocks;

    public bool CheckIfCanBePlaced(Collider2D[] bagBlocks)
    {
        foreach (Collider2D bagBlock in bagBlocks)
        {
            bool canBagBlockBePlaced = false;

            foreach (Collider2D shelfBlock in ShelfBlocks)
            {
                if (LuggageShelf.CanBagBlockOccupyShelfBlock(shelfBlock, bagBlock))
                {
                    canBagBlockBePlaced = true;
                    break;
                }
            }

            if (!canBagBlockBePlaced)
            {
                Debug.Log(bagBlock.name + " can't be placed");
                return false;
            }

        }

        return true;
    }

    private static bool CanBagBlockOccupyShelfBlock(Collider2D shelfBlock, Collider2D bagBlock)
    {
        Collider2D[] overlappingColliders = new Collider2D[2];

        ContactFilter2D contactFilter = (new ContactFilter2D()).NoFilter();
        contactFilter.SetLayerMask(LayerMask.GetMask("Bags"));

        int overlappingCollidersCount = shelfBlock.OverlapCollider(contactFilter, overlappingColliders);

        return overlappingCollidersCount == 1 && bagBlock.IsTouching(shelfBlock);
    }

}
