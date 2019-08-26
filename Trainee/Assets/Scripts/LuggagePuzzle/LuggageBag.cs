using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LuggageBag : MonoBehaviour
{
    public float InteractionTimeTreshold = 0.3f;
    public bool CanBeRotated = true;

    public bool IsInShelf { get; private set; }

    public LuggageShelf Shelf;
    public Collider2D[] BagBlocks;
    public LuggagePuzzle LuggagePuzzle;

    private bool _pickedUp = false;
    private bool _isRotated = false;
    private Vector2 _sourcePosition;
    private float _lastInteractionTime = 0;

    private void Start()
    {
        IsInShelf = false;
        _sourcePosition = transform.position;
    }

    private void Update()
    {
        if (Input.GetMouseButtonUp(1) && _pickedUp)
        {
            _pickedUp = false;
            MoveOnSourcePosition();
        }

        if (_pickedUp)
        {
            Vector2 cursorPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);

            transform.position = new Vector2(cursorPosition.x, cursorPosition.y);

            if (CanBeRotated && Time.time - _lastInteractionTime > InteractionTimeTreshold)
            {
                if (Input.GetButton("Jump"))
                {
                    Rotate(_isRotated);
                    _isRotated = !_isRotated;
                    _lastInteractionTime = Time.time;
                }
            }
        }

    }

    private void OnMouseDown()
    {
        if (Time.time - _lastInteractionTime < InteractionTimeTreshold)
        {
            return;
        }

        if (!_pickedUp)
        {
            _pickedUp = true;
        } else
        {
            if (IfCanBePlaced())
            {
                _pickedUp = false;
                IsInShelf = true;

                LuggagePuzzle.CheckIfBagsOnShelf();
            } else
            {
                // @todo toggle red color
            }
        }

        _lastInteractionTime = Time.time;
    }

    private void MoveOnSourcePosition()
    {
        transform.position = _sourcePosition;
        if (_isRotated)
        {
            Rotate(true);
        }
    }

    private bool IfCanBePlaced()
    {
        return Shelf.CheckIfCanBePlaced(BagBlocks);
    }

    private void Rotate(bool rotateForth)
    {
        transform.Rotate(0, 0, 90f * (rotateForth ? 1 : -1));
    }
}
