using System;
using System.ComponentModel.DataAnnotations;

public class BSPNode
{
    private BSPNode parent;
    private BSPNode sibling;
    private BSPNode[] children;

    public BSPNode()
    {
        parent = null;
        sibling = null;
        children = new BSPNode[2]; // Assuming each node can have at most two children
    }

    public BSPNode Parent
    {
        get { return parent; }
        set { parent = value; }
    }

    public BSPNode Sibling
    {
        get { return sibling; }
        set { sibling = value; }
    }

    public BSPNode[] Children
    {
        get { return children; }
        set { children = value; }
    }

}

public class Subset
{
    public int startX;
    public int startY;
    public int endX;
    public int endY;

    public Subset(int startX, int startY, int endX, int endY)
    {
        this.startX = startX;
        this.startY = startY;
        this.endX = endX;
        this.endY = endY;
    }

    public int Length()
    {
        Console.WriteLine("Length: " + (this.endX-this.startX * this.endY-this.startY));
        return (this.endX-this.startX * this.endY-this.startY);
    }

}

public class BSP_Partitioning
{
    private Random random = new Random();


    public void run(Subset subset, BSPNode node, int maxAcceptedSize, List<Subset> subsetList, char[,] grid)
    {
        partition(subset, node, maxAcceptedSize, subsetList);
        Console.WriteLine("Number of rooms: " + subsetList.Count());
        randomRoomPlacement(subsetList, grid);
    }
    
    public void partition(Subset subset, BSPNode node, int maxAcceptedSize, List<Subset> subsetList)
    {
        if (subset.Length() <= maxAcceptedSize)
        {
            return;
        }
        int directionOfFirstSplit = random.Next(1, 3);

        if (directionOfFirstSplit == 1)
            split(1, subset, node, subsetList, maxAcceptedSize);
        else if (directionOfFirstSplit == 2)
            split(2, subset, node, subsetList, maxAcceptedSize);
    }
    private void split(int directionOfSplit, Subset subset, BSPNode node, List<Subset> subsetList, int maxAcceptedSize)
    {
        if (directionOfSplit == 1)
        {
            int splitValue = random.Next(subset.startX, subset.endX);
            
            Subset subset1 = new Subset(subset.startX, subset.startY, splitValue, subset.endY);
            subsetList.Add(subset1);
            Subset subset2 = new Subset(splitValue, subset.startY, subset.endX, subset.endY);
            subsetList.Add(subset2);

            partition(subset1, node, maxAcceptedSize, subsetList);
            partition(subset2, node, maxAcceptedSize, subsetList);
        }
        if(directionOfSplit == 2)
        {
            int splitValue = random.Next(subset.startY, subset.endY);

            Subset subset1 = new Subset(subset.startX, subset.startY, subset.endX, splitValue); 
            subsetList.Add(subset1);
            Subset subset2 = new Subset(subset.startX, splitValue, subset.endX, subset.endY);
            subsetList.Add(subset2);

            partition(subset1, node, maxAcceptedSize, subsetList);
            partition(subset2, node, maxAcceptedSize, subsetList);
        }


    }

    private void randomRoomPlacement(List<Subset> subsetList, char[,] grid)
    {
        foreach (Subset subset in subsetList)
        {
            int roomTopLeftCornerX = random.Next(subset.startX, subset.endX-2);
            int roomTopLeftCornerY = random.Next(subset.startY, subset.endY-2);
            int roomBottomRightCornerX = random.Next(roomTopLeftCornerX+1, subset.endX);
            int roomBottomRightCornerY = random.Next(subset.startY, roomTopLeftCornerY-1);
            Console.WriteLine(roomTopLeftCornerX + " " + roomTopLeftCornerY + " and end: " + roomBottomRightCornerX + " " + roomBottomRightCornerY);

            for(int i = roomTopLeftCornerX; i < roomBottomRightCornerX; i++)
            {
                for(int j = roomBottomRightCornerY; j < roomTopLeftCornerY;j++)
                {
                    grid[i,j] = 'f';
                }
            }
        }
    }
}