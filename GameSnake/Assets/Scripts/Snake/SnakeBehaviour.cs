using UnityEngine;
using System.Collections;

public class SnakeBehaviour : MonoBehaviour
{
	SnakeHead snakeHead;
	void Start()
	{
		snakeHead = new SnakeHead(this.gameObject);
    }


	float moveTimer, moveTimerMax = 1;
	void Update()
	{
		//if (Input.GetKeyDown(KeyCode.D))
		//{
		//	snakeHead.TryChangeDirection(new Vector2Int(0,1));
		//}

		if (moveTimer >= moveTimerMax)
		{
			moveTimer = 0;
			//transform.position += new Vector3(1,0,0);
			snakeHead.Move();

        }
		moveTimer += Time.deltaTime;


    }
}

