using System;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;
using System.Linq;
using System.Text;

public class BSPNode
{
    private BSPNode parent;
    private BSPNode sibling;
    private BSPNode[] children;
    private int level;
    private bool connected;

    private Subset subset;
    private Subset room;

    //Represents a node on BSP Tree - is also connected to its subset of grid and room
    public BSPNode(int assignlevel)
    {
        parent = null;
        sibling = null;
        children = new BSPNode[2]; //Each node can have at most two children
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

    //Set nodes room to all floortile in children nodes
    public void SetRoomFromChildren()
    {
        //Ensure there are children nodes
        if (children != null && children.Length > 0)
        {
            //Get all tiles from all children
            var allTiles = children.SelectMany(child => child.GetRoom().GetTiles());

            //Set the room for the parent node
            room = new Subset(allTiles);
        }
    }

}

//Subset class to represent a subset of the grid, has a list of coordinates i.e. tiles which are in it
public class Subset
{
    private List<(int x, int y)> coordinates;
    public Subset(IEnumerable<(int x, int y)> coordinates)
    {
        this.coordinates = coordinates.ToList();
    }

    public Subset((int x1, int y1) topLeft, (int x2, int y2) bottomRight)
    {
        coordinates = new List<(int, int)>();


        for (int x = topLeft.x1; x <= bottomRight.x2; x++)
        {
            for (int y = topLeft.y1; y >= bottomRight.y2; y--)
            {
                coordinates.Add((x, y));
            }
        }
    }

    public int Length()
    {
        return coordinates.Count;
    }

    //Returns all coordinates
    public IEnumerable<(int x, int y)> GetTiles()
    {
        return coordinates;
    }

    public void AddCoordinates(IEnumerable<(int x, int y)> newCoordinates)
    {
        coordinates.AddRange(newCoordinates);
    }

    public void AddCoordinates(int startX, int startY, int endX, int endY)
    {
        for (int x = startX; x <= endX; x++)
        {
            for (int y = startY; y <= endY; y++)
            {
                coordinates.Add((x, y));
            }
        }
    }
    public override string ToString()
    {
        StringBuilder sb = new StringBuilder();
        sb.Append("Subset coordinates: ");
        foreach (var coord in coordinates)
        {
            sb.Append($"({coord.x}, {coord.y}) ");
        }
        return sb.ToString();
    }

}

public class BSP_rooms
{
    private Random random = new Random();


    public void run(BSPNode node, int maxAcceptedSize, List<BSPNode> nodeList, char[,] grid)
    {
        partition(node, maxAcceptedSize, nodeList);
        randomRoomPlacement(nodeList, grid);
        BSP_corridors(nodeList, grid);
    }
    
    //partitions the nodes subset if its larger than maxAcceptedSize in a random direction, along the x-axis or y-axis
    public void partition(BSPNode node, int maxAcceptedSize, List<BSPNode> nodeList)
    {
        if (node.GetSubset().Length() <= maxAcceptedSize)
        {
            return;
        }
        int directionOfFirstSplit = random.Next(1, 3);

        if (directionOfFirstSplit == 1)
            split(1, node, nodeList, maxAcceptedSize);
        else if (directionOfFirstSplit == 2)
            split(2, node, nodeList, maxAcceptedSize);
    }
    //Split a subset along x- or y-axis
    private void split(int directionOfSplit, BSPNode node, List<BSPNode> nodeList, int maxAcceptedSize)
    {
        //Create children nodes
        BSPNode leftChild = new BSPNode(node.GetLevel()+1);
        BSPNode rightChild = new BSPNode(node.GetLevel()+1);

        //Get nodes subset bottom left corner and top right corner
        int minX = node.GetSubset().GetTiles().Min(tile => tile.x);
        int maxX = node.GetSubset().GetTiles().Max(tile => tile.x);
        int minY = node.GetSubset().GetTiles().Min(tile => tile.y);
        int maxY = node.GetSubset().GetTiles().Max(tile => tile.y);

        //Split along x-axis
        if (directionOfSplit == 1)
        {
            //Find splitvalue within possible x values in subset
            int splitValue = random.Next(minX, maxX);

            //Create split subsets
            
            Subset subset1 = new Subset((minX, maxY), (splitValue, minY));
            Subset subset2 = new Subset((splitValue, maxY), (maxX, minY));

            //Setup child nodes
            leftChild.SetSubset(subset1);
            rightChild.SetSubset(subset2);
            leftChild.SetSibling(rightChild);
            rightChild.SetSibling(leftChild);
            leftChild.SetParent(node);
            rightChild.SetParent(node);
            //Add child nodes to "tree"
            nodeList.Add(leftChild);
            nodeList.Add(rightChild);
            //Setup child-parent relation
            BSPNode[] children = {leftChild, rightChild};
            node.SetChildren(children);         

            //Partition child nodes
            partition(leftChild, maxAcceptedSize, nodeList);
            partition(rightChild, maxAcceptedSize, nodeList);
        }
        //Split along y-axis
        if(directionOfSplit == 2)
        {
            //Find splitvalue within possible y values in subset
            int splitValueY = random.Next(minY, maxY);

            //Create subsets based on the random split value
            Subset subset1 = new Subset((minX, maxY), (maxX, splitValueY));
            Subset subset2 = new Subset((minX, splitValueY), (maxX, minY));
            
            //Setup child nodes
            leftChild.SetSubset(subset1);
            rightChild.SetSubset(subset2);
            leftChild.SetSibling(rightChild);
            rightChild.SetSibling(leftChild);
            leftChild.SetParent(node);
            rightChild.SetParent(node);
            //Add child nodes to "tree"
            nodeList.Add(leftChild);
            nodeList.Add(rightChild);
            //Setup child-parent relation
            BSPNode[] children= {leftChild, rightChild};
            node.SetChildren(children);
            
            //Partition child nodes
            partition(leftChild, maxAcceptedSize, nodeList);
            partition(rightChild, maxAcceptedSize, nodeList);
        }


    }

    //Randomly place rooms within subsets with no children i.e. highest level
    //Take a random coordinate as a topleftcorner and a random coordinate with larger x and smaller y as bottomrightcorner
    private void randomRoomPlacement(List<BSPNode> nodeList, char[,] grid)
    {
        foreach (BSPNode node in nodeList)
        {
            if(node.GetChildren()[0] == null)
            {
                Subset subset = node.GetSubset();
                
                //Get nodes subset bottom left corner and top right corner
                int minX = subset.GetTiles().Min(tile => tile.x);
                int maxX = subset.GetTiles().Max(tile => tile.x);
                int minY = subset.GetTiles().Min(tile => tile.y);
                int maxY = subset.GetTiles().Max(tile => tile.y);
                
                //Generate random coordinates for the top-left corner of the room
                int roomTopLeftCornerX = random.Next(minX, maxX);
                int roomTopLeftCornerY = random.Next(minY, maxY);

                //Generate random coordinates for the bottom-right corner of the room
                int roomBottomRightCornerX = random.Next(roomTopLeftCornerX, maxX);
                int roomBottomRightCornerY = random.Next(minY, roomTopLeftCornerY);  

                for(int i = roomTopLeftCornerX; i <= roomBottomRightCornerX; i++)
                {
                    for(int j = roomBottomRightCornerY; j <= roomTopLeftCornerY;j++)
                    {
                        grid[j, i] = 'f';
                    }
                }

                Subset room = new Subset((roomTopLeftCornerX, roomTopLeftCornerY), (roomBottomRightCornerX, roomBottomRightCornerY));
                node.SetRoom(room);
                
            }
        }
    }

    //From highest level and down in BSP tree, connect nodes with siblings that arent connected and also have room
    private void BSP_corridors(List<BSPNode> nodeList, char[,] grid)
    {
        //Group nodes by their level
        var leveledNodes = nodeList.GroupBy(n => n.GetLevel()).OrderByDescending(g => g.Key);
        //Iterate through each level of nodes
        foreach(var level in leveledNodes)
        {
            foreach(var node in level)
            {
                if(node.GetSibling() != null && node.GetConnected() == false && node.GetSibling().GetRoom() != null)
                {
                    connect_rooms(node, node.GetSibling(), grid);
                    node.SetConnected();
                    node.GetSibling().SetConnected();
                    
                    //Set room for the parent node after connecting children
                    if (node.GetParent() != null)
                    {
                        node.GetParent().SetRoomFromChildren();
                    }

                }
            }
            
        }
    }

    //Determines if rooms are aligned along any axis, if yes: connects them with a straight corridor
    //Else finds the tiles with smallest distance between them along one of the axis: connects them with L-corridor
    private void connect_rooms(BSPNode fromRoom, BSPNode toRoom, char[,] grid)
    {
        //Used to move around on grid
        int currentX = 0;
        int currentY = 0;

        //Used if rooms are not aligned along any axis
        int smallestXdistance = grid.GetLength(1);
        int smallestYdistance = grid.GetLength(0);

        //Used to determine where corridor should start and end
        int startX = 0;
        int startY = 0;
        int endX = 0;
        int endY = 0;

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
                        if(currentY < toTile.y)
                        {
                            currentY +=1;
                        }
                        else
                        {
                            currentY -=1;
                        }
                        grid[currentY, currentX] = 'f'; 
                    }
                    return;
                }
                if(fromTile.y == toTile.y)
                {
                    currentX = fromTile.x;
                    currentY = fromTile.y;
                    while(currentX != toTile.x)
                    {
                        if(currentX < toTile.x)
                        {
                            currentX +=1;
                        }
                        else
                        {
                            currentX -=1;
                        }
                        grid[currentY, currentX] = 'f';
                    }
                    return;
                }
                //Update distances
                //.Abs() finds absolute value - 5-10 = 5 fx.
                if(Math.Abs(fromTile.x - toTile.x) < smallestXdistance)
                {
                    smallestXdistance = Math.Abs(fromTile.x - toTile.x);
                    startX = fromTile.x;
                    startY = fromTile.y;
                    endX = toTile.x;
                    endY = toTile.y;
                }
                if(Math.Abs(fromTile.y - toTile.y) < smallestYdistance)
                {
                    smallestYdistance = Math.Abs(fromTile.y - toTile.y);
                    startX = fromTile.x;
                    startY = fromTile.y;
                    endX = toTile.x;
                    endY = toTile.y;
                }
            }
            

        }
        //If no tiles were found to be aligned: create L-corridor
        if(smallestXdistance < smallestYdistance)
        {
            currentX = startX;
            currentY = startY;
            while(currentX != endX)
            {
                if(currentX < endX)
                {
                    currentX +=1;
                }
                else
                {
                    currentX -=1;
                }
                grid[currentY, currentX] = 'f';
            }
            while(currentY != endY)
            {
                if(currentY < endY)
                {
                    currentY +=1;
                }
                else
                {
                    currentY -=1;
                }
                grid[currentY, currentX] = 'f';
            }
            
        }
        else
        {
            currentX = startX;
            currentY = startY;
            while(currentY != endY)
            {
                if(currentY < endY)
                {
                    currentY +=1;
                }
                else
                {
                    currentY -=1;
                }
                grid[currentY, currentX] = 'f';
            }
            while(currentX != endX)
            {
                if(currentX < endX)
                {
                    currentX +=1;
                }
                else
                {
                    currentX -=1;
                }
                grid[currentY, currentX] = 'f';
            }
        }
    }

    
}