using System;
using Algorithms.Trees;
using Xunit;

namespace Algorithms.Tests.Trees
{
    public class AVLTreeTests
    {
        [Fact]
        public void InsertTest()
        {
            // Arrange
            var avl = new AVLTree();
            
            // Act
            avl.Insert(2);
            avl.Insert(5);
            avl.Insert(4);
            
            // Assert
            Assert.True(Math.Abs(avl.GetBalanceFactor()) <= 1);
        }

        [Fact]
        public void RemoveTest()
        {
            // Arrange
            var avl = new AVLTree();
            avl.Insert(1);
            avl.Insert(2);
            avl.Insert(5);
            avl.Insert(4);
            
            avl.Remove(1);
            
            // Assert
            Assert.True(Math.Abs(avl.GetBalanceFactor()) <= 1);
        }
    }
}