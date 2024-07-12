using System.Collections.Generic;
using UnityEngine;

public class SnakeBody
{
    SnakeBehaviour snakeHandler;

    List<Vector2Int> _bodyPartsPosition;
    List<SnakeDirection> _bodyPartsDirection;

    List<GameObject> bodyParts;

    Sprite bodySprite, cornerSprite, teilSprite;

    int _bodyLen = 0;
    private int BodyLen { get => _bodyLen; }

    public SnakeBody(SnakeBehaviour snakeHandler)
	{
        this.snakeHandler = snakeHandler;

        _bodyPartsPosition = new List<Vector2Int>();
        bodyParts = new List<GameObject>();
        _bodyPartsDirection = new List<SnakeDirection>();
    }

    public void SetSprites(Sprite bodySprite, Sprite cornerSprite, Sprite teilSprite)
    {
        this.bodySprite = bodySprite;
        this.cornerSprite = cornerSprite;
        this.teilSprite = teilSprite;
    }

    public void Update()
    {
        _bodyPartsPosition.Insert(0, snakeHandler.HeadPosition);
        _bodyPartsDirection.Insert(0, snakeHandler.HeadDirection);

        DrawBodyParts();
    }

    public void AddBodyPart()
    {
        var part = new GameObject($"part {BodyLen}");
        var spriteRenderer = part.AddComponent<SpriteRenderer>();
        spriteRenderer.sortingLayerName = "Snake";
        spriteRenderer.sortingOrder = -BodyLen;
        bodyParts.Add(part);
        snakeHandler.GameField.PlaceOnField(part);
        _bodyLen++;

        
    }
    
    void DrawBodyParts()
    {
        for (int i = 0; i < BodyLen; i++)
        {
            var spriteRenderer = bodyParts[i].GetComponent<SpriteRenderer>();

            bodyParts[i].transform.position = (Vector2)_bodyPartsPosition[i];
            bodyParts[i].transform.eulerAngles = _bodyPartsDirection[i].ToEulerAngles();

            if (i == BodyLen - 1)//teil
            {
                spriteRenderer.sprite = teilSprite;
                return;
            }
            var prevPartDirection = _bodyPartsDirection[i + 1];
            if (prevPartDirection != _bodyPartsDirection[i])//corner
            {
                bodyParts[i].transform.eulerAngles =
                    _bodyPartsDirection[i].GetCornerRotationTo(prevPartDirection);

                spriteRenderer.sprite = cornerSprite;
                continue;
            }

            spriteRenderer.sprite = bodySprite;//default
        }
    }

    public Vector2[] GetAllPartsPosition()
    {
        List<Vector2> partsPosition = new List<Vector2>();
        foreach (var part in bodyParts)
        {
            Vector2 partPos = part.transform.position;
            partsPosition.Add(partPos);
        }

        return partsPosition.ToArray();
    }
}

