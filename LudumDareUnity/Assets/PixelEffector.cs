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
		StartCoroutine(pixelFX());
		//pixelFX();
	}
	
	IEnumerator pixelFX()
	{
		int quadCount = 0;
		GameObject tmp;
		emptyObj = new GameObject();
		emptyObj.name = "PixelParent";
		while (quadCount < sizeX * sizeY)
		{
			int randX = Random.Range(0, sizeX);
			int randY = Random.Range(0, sizeY);

			if (pixelArray[randY, randX] == 0)
			{
				tmp = GameObject.CreatePrimitive(PrimitiveType.Quad);
				tmp.transform.position = new Vector3(randX + this.transform.position.x, randY + this.transform.position.y);
				pixelArray[randY, randX] = 1;
				tmp.transform.parent = emptyObj.transform;
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
							tmp = GameObject.CreatePrimitive(PrimitiveType.Quad);
							tmp.transform.position = new Vector3(i + this.transform.position.x, j + this.transform.position.y);
							pixelArray[j, i] = 1;
							tmp.transform.parent = emptyObj.transform;
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
								tmp = GameObject.CreatePrimitive(PrimitiveType.Quad);
								tmp.transform.position = new Vector3(i + this.transform.position.x, j + this.transform.position.y);
								pixelArray[j, i] = 1;
								tmp.transform.parent = emptyObj.transform;
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
			yield return new WaitForSeconds(0.000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000001f);
		}
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
