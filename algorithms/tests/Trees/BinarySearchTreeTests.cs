using Algorithms.Trees;
using Xunit;

namespace Algorithms.Tests.Trees
{
    public class BinaryTreeTests
    {
        [Fact]
        public void SearchTest()
        {
            // Arrange
            var tree = new BinarySearchTree()
            {
                Root = new Node(5)
                {
                    Left = new Node(1),
                    Right = new Node(8)
                    {
                        Left = new Node(7)
                        {
                            Left = new Node(6)
                        },
                        Right = new Node(10)
                    }
                }
            };

            const int toFind = 7;
            
            // Act
            var result = tree.Search(toFind);

            // Assert
            Assert.NotNull(result);
            Assert.Equal(toFind, result?.Value);
        }

        [Fact]
        public void InsertTest()
        {
            // Arrange
            var tree = new BinarySearchTree()
            {
                Root = new Node(5)
                {
                    Left = new Node(1),
                    Right = new Node(8)
                    {
                        Left = new Node(7)
                        {
                            Left = new Node(6)
                        },
                        Right = new Node(10)
                    }
                }
            };

            const int toInsert = 9;
            
            // Act
            tree.Insert(toInsert);

            // Assert
            var inserted = tree.Search(toInsert);
            Assert.NotNull(inserted);
            Assert.Equal(toInsert, inserted?.Value);
        }

        [Fact]
        public void TraversalTest()
        {
            // Arrange
            var tree = new BinarySearchTree()
            {
                Root = new Node(5)
                {
                    Left = new Node(1),
                    Right = new Node(8)
                    {
                        Left = new Node(7)
                        {
                            Left = new Node(6)
                        },
                        Right = new Node(10)
                    }
                }
            };
            
            // Act
            var traversal = tree.Traversal();
            
            // Assert
            Assert.Equal(new[] { 1, 5, 6, 7, 8, 10}, traversal);
        }

        [Fact]
        public void RemoveTest()
        {
            // Arrange
            var tree = new BinarySearchTree()
            {
                Root = new Node(5)
                {
                    Left = new Node(1),
                    Right = new Node(8)
                    {
                        Left = new Node(7)
                        {
                            Left = new Node(6)
                        },
                        Right = new Node(10)
                    }
                }
            };

            const int toRemove = 5;
            
            // Act
            tree.Remove(toRemove);
            
            // Assert
            Assert.Null(tree.Search(toRemove));
        }
    }
}