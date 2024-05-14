using System;
using System.ComponentModel.DataAnnotations;

public class BSPNode
{
    private BSPNode parent;
    private BSPNode sibling;
    private BSPNode[] children;

    private Subset subset;

    public BSPNode()
    {
        parent = null;
        sibling = null;
        children = new BSPNode[2]; // Assuming each node can have at most two children
        subset = null;
    }

    public void SetParent(BSPNode parentNode)
    {
        parent = parentNode;
    }

    public BSPNode GetParent()
    {
        return parent;
    }

    public void SetSibling(BSPNode siblingNode)
    {
        sibling = siblingNode;
    }

    public BSPNode GetSibling()
    {
        return sibling;
    }

    public void SetChildren(BSPNode[] childNodes)
    {
        children = childNodes;
    }

    public BSPNode[] GetChildren()
    {
        return children;
    }

    public void SetSubset(Subset subset)
    {
        this.subset = subset;
    }

    public Subset GetSubset()
    {
        return this.subset;
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
        return ((this.endX-this.startX) * (this.endY-this.startY));
    }

}

public class BSP_rooms
{
    private Random random = new Random();


    public void run(Subset subset, BSPNode node, int maxAcceptedSize, List<BSPNode> nodeList, char[,] grid)
    {
        partition(subset, node, maxAcceptedSize, nodeList);
        randomRoomPlacement(nodeList, grid);
    }
    
    public void partition(Subset subset, BSPNode node, int maxAcceptedSize, List<BSPNode> nodeList)
    {
        if (subset.Length() <= maxAcceptedSize)
        {
            return;
        }
        int directionOfFirstSplit = random.Next(1, 3);

        if (directionOfFirstSplit == 1)
            split(1, subset, node, nodeList, maxAcceptedSize);
        else if (directionOfFirstSplit == 2)
            split(2, subset, node, nodeList, maxAcceptedSize);
    }
    private void split(int directionOfSplit, Subset subset, BSPNode node, List<BSPNode> nodeList, int maxAcceptedSize)
    {
        BSPNode leftChild = new BSPNode();
        BSPNode rightChild = new BSPNode();

        if (directionOfSplit == 1)
        {
            int splitValue = random.Next(subset.startX, subset.endX);
            
            Subset subset1 = new Subset(subset.startX, subset.startY, splitValue, subset.endY);
            Subset subset2 = new Subset(splitValue, subset.startY, subset.endX, subset.endY);

            leftChild.SetSubset(subset1);
            rightChild.SetSubset(subset2);
            nodeList.Add(leftChild);
            nodeList.Add(rightChild);

            BSPNode[] children= {leftChild, rightChild};
            node.SetChildren(children);         

        
            partition(subset1, leftChild, maxAcceptedSize, nodeList);
            partition(subset2, rightChild, maxAcceptedSize, nodeList);
        }
        if(directionOfSplit == 2)
        {
            int splitValue = random.Next(subset.startY, subset.endY);

            Subset subset1 = new Subset(subset.startX, subset.startY, subset.endX, splitValue); 
            Subset subset2 = new Subset(subset.startX, splitValue, subset.endX, subset.endY);

            leftChild.SetSubset(subset1);
            rightChild.SetSubset(subset2);
            nodeList.Add(leftChild);
            nodeList.Add(rightChild);

            BSPNode[] children= {leftChild, rightChild};
            node.SetChildren(children);
            
            partition(subset1, leftChild, maxAcceptedSize, nodeList);
            partition(subset2, rightChild, maxAcceptedSize, nodeList);
        }


    }

    private void randomRoomPlacement(List<BSPNode> nodeList, char[,] grid)
    {
        foreach (BSPNode node in nodeList)
        {
            if(node.GetChildren()[0] == null)
            {
                Subset subset = node.GetSubset();
                Console.WriteLine("(" + subset.startX + ", " + subset.startY + ")" + " (" + subset.endX + ", " + subset.endY + ")");
                int roomTopLeftCornerX = random.Next(subset.startX, subset.endX);
                int roomTopLeftCornerY = random.Next(subset.startY, subset.endY);
                int roomBottomRightCornerX = random.Next(roomTopLeftCornerX, subset.endX+1);
                int roomBottomRightCornerY = random.Next(subset.startY, roomTopLeftCornerY+1);

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

    
}