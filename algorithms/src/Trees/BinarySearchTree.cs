using System.Collections.Generic;

namespace Algorithms.Trees
{
    public class BinarySearchTree
    {
        public Node? Root { get; set; }

        public void Insert(int value)
        {
            Root = Insert(Root, value);
        }

        private static Node? Insert(Node? node, int value)
        {
            if (node == null)
                return new Node(value);

            if (value <= node.Value)
                node.Left = Insert(node.Left, value);
            else
                node.Right = Insert(node.Right, value);

            return node;
        }
        
        public void Remove(int value)
        {
            Root = Remove(Root, new Node(value));
        }

        private static Node? Remove(Node? node, Node deleteNode) 
        {
            if (node == null)
                return null;
            
            if (deleteNode.Value < node.Value)
                node.Left = Remove(node.Left, deleteNode);
            else if (deleteNode.Value > node.Value)
                node.Right = Remove(node.Right, deleteNode);
            else
            {
                if (node.Left == null && node.Left == null)
                    return null;

                if (node.Left == null)
                {
                    node = node.Right;
                }
                else if (node.Right == null)
                {
                    node = node.Left;
                }
                else
                {
                    var minLeft = node.Right;
                    while (minLeft.Left != null)
                        minLeft = minLeft.Left;
                    
                    node.Value = minLeft.Value;
                    node.Right =  Remove(node.Right, minLeft);
                }
            }
            return node;
        }
        
        public Node? Search(int value)
        {
            return Search(Root, value);
        }

        private static Node? Search(Node? node, int value)
        {
            if (node == null)
                return default;
            
            return node.Value == value 
                ? node 
                : Search(value < node.Value ? node.Left : node.Right, value);
        }
        
        public int[] Traversal()
        {
            var traversal = new List<int>();
            Traversal(Root, traversal);

            return traversal.ToArray();
        }

        private static void Traversal(Node? node, List<int> traversal)
        {
            if (node == null)
                return;
            
            if (node.Left != null)
                Traversal(node.Left, traversal);
            
            traversal.Add(node.Value);
            
            if (node.Right != null)
                Traversal(node.Right, traversal);
        }
    }
}