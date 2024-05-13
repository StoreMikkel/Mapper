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
        int counter = 0;
        for (int i = this.startX; i <= this.endX; i++)
        {
            for(int j = this.startY; j <= this.endY; j++)
            {
                counter++;
            }
        }
        return counter;
    }

    public int getWidth()
    {
        return this.endX - this.startX;
    }

    public int getHeight()
    {
        return this.endY - this.startY;
    }
}

public class BSP_Partitioning
{
    private Random random = new Random();

    public void run(Subset subset, BSPNode node, int maxAcceptedSize, List<Subset> subsetList, char[,] grid)
    {
        partition(subset, node, maxAcceptedSize, subsetList);
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
            split(1, subset, node, subsetList);
        else if (directionOfFirstSplit == 2)
            split(2, subset, node, subsetList);
    }
    private void split(int directionOfSplit, Subset subset, BSPNode node, List<Subset> subsetList)
    {
        int subsetWidth = subset.getWidth();
        int subsetHeight = subset.getHeight();
        if (directionOfSplit == 1)
        {
            int splitValue = random.Next(subset.startX, subsetWidth);
            subsetList.Add(new Subset(subset.startX, subset.startY, splitValue, subset.endY));
            subsetList.Add(new Subset(splitValue, subset.startY, subset.endX, subset.endY));
        }
        if(directionOfSplit == 2)
        {
            int splitValue = random.Next(subset.startY, subsetHeight);
            subsetList.Add(new Subset(subset.startX, subset.startY, subset.endX, splitValue));
            subsetList.Add(new Subset(subset.startX, splitValue, subset.endX, subset.endY));
        }

    }

    private void randomRoomPlacement(List<Subset> subsetList, char[,] grid)
    {
        foreach (Subset subset in subsetList)
        {
            int roomTopLeftCornerX = random.Next(subset.startX, subset.endX);
            int roomTopLeftCornerY = random.Next(subset.startY, subset.endY);
            int roomBottomRightCornerX = random.Next(roomTopLeftCornerX, subset.endX);
            int roomBottomRightCornerY = random.Next(roomTopLeftCornerY, subset.endY);

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