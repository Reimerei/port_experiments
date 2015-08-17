using Entitas;
using Entitas.CodeGenerator;

[MetaGameAttribute]
[SingleEntity]
public class IslandSectorsComponent : IComponent 
{
	public bool[,] sectors;
}

public static class IslandSectorsComponentExtension
{
	public static int GetSectorRows(this Pool repo)
	{
		return repo.islandSectors.sectors.GetLength(0);
	}
	
	public static int GetSectorColumns(this Pool repo)
	{
		return repo.islandSectors.sectors.GetLength(1);
	}

	public static bool IsSectorUnlocked(this Pool repo, int row, int column)
	{
		return repo.islandSectors.sectors[row, column];
	}

	public static void UnlockSector(this Pool repo, int row, int column)
	{
		bool[,] sectors = repo.islandSectors.sectors.Copy();
		sectors[row, column] = true;

		repo.ReplaceIslandSectors(sectors);
	}
}