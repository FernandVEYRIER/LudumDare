using UnityEngine;
using System.Collections;

public class PixelEffector : MonoBehaviour {

	GameObject emptyObj;

	public int sizeX = 300;
	public int sizeY = 300;
	int [,] pixelArray;

	void Start () 
	{
		pixelArray = new int [sizeY, sizeX];
		clearTab();
		pixelFX();
	}
	
	void pixelFX()
	{
		int quadCount = 0;
		emptyObj = new GameObject();
		emptyObj.name = "PixelParent";
		while (quadCount < sizeX * sizeY)
		{
			int randX = Random.Range(0, sizeX);
			int randY = Random.Range(0, sizeY);

			if (pixelArray[randY, randX] == 0)
			{
				StartCoroutine(delaySpawn(randX, randY, quadCount));
				pixelArray[randY, randX] = 1;
			}
			else
			{
				bool mustBreak = false;

				for (int j = randY; j < sizeY; j++)
				{
					for (int i = randX; i < sizeX; i++)
					{
						if (pixelArray[j, i] == 0)
						{
							StartCoroutine(delaySpawn(i, j, quadCount));
							pixelArray[j, i] = 1;
							mustBreak = true;
							break;
						}
					}
					if (mustBreak)
						break;
				}
				if (!mustBreak)
				{
					for (int j = 0; j < sizeY; j++)
					{
						for (int i = 0; i < sizeX; i++)
						{
							if (pixelArray[j, i] == 0)
							{
								StartCoroutine(delaySpawn(i, j, quadCount));
								pixelArray[j, i] = 1;
								mustBreak = true;
								break;
							}
						}
						if (mustBreak)
							break;
					}
				}
			}
			++quadCount;
		}
	}

	IEnumerator delaySpawn(int i, int j, int delay)
	{
		yield return new WaitForSeconds(0.5f + delay * 0.002f);
		GameObject tmp;
		tmp = GameObject.CreatePrimitive(PrimitiveType.Quad);
		tmp.transform.position = new Vector3(i + this.transform.position.x, j + this.transform.position.y);
		tmp.transform.parent = emptyObj.transform;
	}

	void clearTab()
	{
		for (int j = 0; j < sizeY; j++)
		{
			for (int i = 0; i < sizeX; i++)
			{
				pixelArray[j,i] = 0;
			}
		}
	}
}
