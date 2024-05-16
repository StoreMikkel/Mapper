using System;
using System.ComponentModel.DataAnnotations;

public class BSPNode
{
    private BSPNode parent;
    private BSPNode sibling;
    private BSPNode[] children;
    private int level;
    private bool connected;

    private Subset subset;
    private Subset room;

    public BSPNode(int assignlevel)
    {
        parent = null;
        sibling = null;
        children = new BSPNode[2]; // Assuming each node can have at most two children
        subset = null;
        this.level = assignlevel;
        connected = false;
        room = null;
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

    public int GetLevel()
    {
        return this.level;
    }

    public void SetConnected()
    {
        this.connected = true;
    }
    public bool GetConnected()
    {
        return connected;
    }

    public void SetRoom(Subset subset)
    {
        this.room = subset;
    }

    public Subset GetRoom()
    {
        return this.room;
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

    public IEnumerable<(int x, int y)> GetTiles()
    {
        for (int y = startY; y <= endY; y++)
        {
            for (int x = startX; x <= endX; x++)
            {
                yield return (x, y);
            }
        }
    }

}

public class BSP_rooms
{
    private Random random = new Random();


    public void run(Subset subset, BSPNode node, int maxAcceptedSize, List<BSPNode> nodeList, char[,] grid)
    {
        partition(subset, node, maxAcceptedSize, nodeList);
        randomRoomPlacement(nodeList, grid);
        for (int row = 0; row < grid.GetLength(0); row++)
{
        // Iterate over each column in the current row
        for (int col = 0; col < grid.GetLength(1); col++)
        {
            // Print the value of the current element
            Console.Write(grid[row, col] + " ");
        }
        // Move to the next line after printing all columns in the current row
        Console.WriteLine();
        }
        Console.WriteLine();
        Console.WriteLine();
        BSP_corridors(nodeList, grid);
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
        BSPNode leftChild = new BSPNode(node.GetLevel()+1);
        BSPNode rightChild = new BSPNode(node.GetLevel()+1);

        if (directionOfSplit == 1)
        {
            int splitValue = random.Next(subset.startX, subset.endX);
            
            Subset subset1 = new Subset(subset.startX, subset.startY, splitValue, subset.endY);
            Subset subset2 = new Subset(splitValue, subset.startY, subset.endX, subset.endY);

            leftChild.SetSubset(subset1);
            rightChild.SetSubset(subset2);
            leftChild.SetSibling(rightChild);
            rightChild.SetSibling(leftChild);

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
            leftChild.SetSibling(rightChild);
            rightChild.SetSibling(leftChild);
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
                int roomTopLeftCornerX = random.Next(subset.startX, subset.endX);
                int roomTopLeftCornerY = random.Next(subset.startY, subset.endY);
                int roomBottomRightCornerX = random.Next(roomTopLeftCornerX, subset.endX);
                int roomBottomRightCornerY = random.Next(subset.startY, roomTopLeftCornerY);

                for(int i = roomTopLeftCornerX; i <= roomBottomRightCornerX; i++)
                {
                    for(int j = roomBottomRightCornerY; j <= roomTopLeftCornerY;j++)
                    {
                        grid[i,j] = 'f';
                    }
                }

                Subset room = new Subset(roomTopLeftCornerX, roomTopLeftCornerY, roomBottomRightCornerX, roomBottomRightCornerY);
                node.SetRoom(room);
            }
        }
    }

    private void BSP_corridors(List<BSPNode> nodeList, char[,] grid)
    {
        // Group nodes by their level
        var groupedNodes = nodeList.GroupBy(n => n.GetLevel()).OrderByDescending(g => g.Key);
        //Iterate through each group of nodes
        foreach(var group in groupedNodes)
        {
            foreach(var node in group)
            {
                if(node.GetSibling() != null && node.GetConnected() == false && node.GetRoom() != null && node.GetSibling().GetRoom() != null)
                {
                    connect_rooms(node, node.GetSibling(), grid);
                    node.SetConnected();
                    node.GetSibling().SetConnected();
                }
            }
            
        }
    }

    private void connect_rooms(BSPNode fromRoom, BSPNode toRoom, char[,] grid)
    {
        int currentX = 0;
        int currentY = 0;
        int smallestXdifference = grid.GetLength(1);
        int smallestYdifference = grid.GetLength(0);
        int startX = 0;
        int startY = 0;
        int endX = 0;
        int endY = 0;

        Console.WriteLine("Connecting new rooms");
        foreach(var fromTile in fromRoom.GetRoom().GetTiles())
        {
            foreach(var toTile in toRoom.GetRoom().GetTiles())
            {
                
                if(fromTile.x == toTile.x)
                {
                    currentX = fromTile.x;
                    currentY = fromTile.y;
                    while(currentY != toTile.y)
                    {
                        grid[currentY, currentX] = 'c';
                        Console.WriteLine("c in first: (" + currentX + ", " + currentY + ")");
                        currentY +=1;
                        
                    }
                    return;
                }
                if(fromTile.y == toTile.y)
                {
                    currentX = fromTile.x;
                    currentY = fromTile.y;
                    while(currentX != toTile.x)
                    {
                        grid[currentY, currentX] = 'c';
                        Console.WriteLine("c in second: (" + currentX + ", " + currentY + ")");
                        currentX +=1;
                        
                    }
                    return;
                }
                if(Math.Abs(fromTile.x - toTile.x) < smallestXdifference)
                {
                    smallestXdifference = Math.Abs(fromTile.x - toTile.x);
                    startX = fromTile.x;
                    startY = fromTile.y;
                    endX = toTile.x;
                    endY = toTile.y;
                }
                if(Math.Abs(fromTile.y - toTile.y) < smallestXdifference)
                {
                    smallestYdifference = Math.Abs(fromTile.y - toTile.y);
                    startX = fromTile.x;
                    startY = fromTile.y;
                    endX = toTile.x;
                    endY = toTile.y;
                }
                
            }

        }
        if(smallestXdifference < smallestYdifference)
        {
            currentX = startX;
            currentY = startY;
            while(currentX != endX)
            {
                grid[currentY, currentX] = 'c';
                Console.WriteLine("c in third: (" + currentX + ", " + currentY + ")");
                currentX +=1;
                
            }
            while(currentY != endY)
            {
                grid[currentY, currentX] = 'c';
                Console.WriteLine("c in fourth: (" + currentX + ", " + currentY + ")");
                currentY += 1;
                
            }
            
        }
        else
        {
            currentX = startX;
            currentY = startY;
            while(currentY != endY)
            {
                grid[currentY, currentX] = 'c';
                Console.WriteLine("c in fifth: (" + currentX + ", " + currentY + ")");
                currentY += 1;
                
            }
            while(currentX != endX)
            {
                grid[currentY, currentX] = 'c';
                Console.WriteLine("c in sixth: (" + currentX + ", " + currentY + ")");
                currentX +=1;
                
            }
        }


        

    }

    
}