using System;

namespace Algorithms.Trees
{
    public class AVLTree : BinarySearchTree
    {
        public int GetBalanceFactor() => GetBalanceFactor(Root);
        
        protected override Node Insert(Node? node, int value)
        {
            var current = base.Insert(node, value);
            current = Balance(current);
            return current;
        }

        protected override Node Remove(Node node, Node deleteNode)
        {
            var current = base.Remove(node, deleteNode);
            current = Balance(current);
            return current;
        }

        private static Node Balance(Node current)
        {
            var balanceFactor = GetBalanceFactor(current);
            if (balanceFactor > 1)
            {
                current = GetBalanceFactor(current.Left) > 0 ? RotateRR(current) : RotateLR(current);
            }
            else if (balanceFactor < -1)
            {
                current = GetBalanceFactor(current.Right) > 0 ? RotateRL(current) : RotateLL(current);
            }
            return current;
        }
        
        private static int GetHeight(Node? node)
        {
            if (node == null)
                return default;
            
            var l = GetHeight(node.Left); 
            var r = GetHeight(node.Right); 
            return Math.Max(l, r) + 1;
        }
        private static int GetBalanceFactor(Node? node)
        {
            if (node == null)
                return default;
            
            var l = GetHeight(node.Left);
            var r = GetHeight(node.Right);
            return l - r;
        }
        private static Node RotateLL(Node parent)
        {
            var pivot = parent.Right;
            parent.Right = pivot.Left;
            pivot.Left = parent;
            return pivot;
        }
        private static Node RotateRR(Node parent)
        {
            var pivot = parent.Left;
            parent.Left = pivot.Right;
            pivot.Right = parent;
            return pivot;
        }
        private static Node RotateLR(Node parent)
        {
            var pivot = parent.Left;
            parent.Left = RotateLL(pivot);
            return RotateRR(parent);
        }
        private static Node RotateRL(Node parent)
        {
            var pivot = parent.Right;
            parent.Right = RotateRR(pivot);
            return RotateLL(parent);
        }
    }
}