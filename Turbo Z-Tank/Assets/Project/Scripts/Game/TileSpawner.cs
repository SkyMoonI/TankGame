using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.ProBuilder;

public class TileSpawner : MonoBehaviour
{
	[SerializeField] List<GameObject> _tilePrefabs;
	[SerializeField] GameObject _finishLinePrefab;

	[SerializeField] Transform _spawnPoint;
	float _tileLength = 10.0f;

	int _tilesSpawned = 0;
	int _tilesToSpawn = 25;
	int _totalTileLength = 0;
	int _currentGameLevel = 1;


	void Start()
	{
		ResetLevel();
		SetupLevel();
	}
	public void SetupLevel()
	{
		for (int i = 0; i < _tilesToSpawn; i++)
		{
			int randomIndex = Random.Range(0, _tilePrefabs.Count);

			Vector3 spawnPosition = _spawnPoint.position + Vector3.forward * _totalTileLength;
			Instantiate(_tilePrefabs[randomIndex], spawnPosition, Quaternion.identity);

			_tileLength = _tilePrefabs[randomIndex].GetComponent<Tile>().TileLength;
			_totalTileLength += (int)_tileLength;

			_tilesSpawned++;

			if (_tilesSpawned == _tilesToSpawn - 1)
			{
				SpawnFinishLine();
				break;
			}
		}
	}
	void SpawnFinishLine()
	{
		Vector3 finishLinePosition = _spawnPoint.position + Vector3.forward * _totalTileLength;
		Instantiate(_finishLinePrefab, finishLinePosition, Quaternion.identity);
	}

	public void ResetLevel()
	{
		_currentGameLevel = LevelComplete.Instance.Level;
		_tilesSpawned = 0;
		_tilesToSpawn = 25 * _currentGameLevel;
	}
}
