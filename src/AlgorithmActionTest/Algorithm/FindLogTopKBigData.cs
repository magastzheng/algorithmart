using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlgorithmAction.Algorithm
{
    public enum RbColor
    {
        Red,
        Black
    }

    public class RbNode
    {
        public int Key { get; set; }
        public int Data { get; set; }
        public RbColor Color { get; set; }
        public RbNode Left { get; set; }
        public RbNode Right { get; set; }
        public RbNode Parent { get; set; }
    }

    public class FindLogTopKBigData
    {
        private RbNode CreateNode(int key, int data)
        {
            RbNode node = new RbNode
                {
                    Key = key,
                    Data = data,
                    Color = RbColor.Red
                };

            return node;
        }

        /// <summary>
        /// left rotate:     ==>
        ///   node                   right
        ///    /\                     /\
        ///   a  right             node y
        ///        /\               /\
        ///       b  y             a  b 
        /// </summary>
        /// <param name="node"></param>
        /// <param name="root"></param>
        /// <returns></returns>
        private RbNode RotateLeft(RbNode node, RbNode root)
        {
            RbNode right = node.Right;

            if (node.Right == right.Left)
            {
                right.Left.Parent = node;
            }

            right.Left = node;
            if (right.Parent == node.Parent)
            {
                if (node == node.Parent.Right)
                {
                    node.Parent.Right = right;
                }
                else
                {
                    node.Parent.Left = right;
                }
            }
            else
            {
                root = right;
            }

            node.Parent = right;

            return root;
        }

        /// <summary>
        /// right rotate ==>   left
        ///     node            /\
        ///      /\            a  node
        ///   left y               /\
        ///    /\                 b  y
        ///   a  b
        /// </summary>
        /// <param name="node"></param>
        /// <param name="root"></param>
        /// <returns></returns>
        private RbNode RotateRight(RbNode node, RbNode root)
        {
            RbNode left = node.Left;

            if (node.Left == left.Right)
            {
                left.Right.Parent = node;
            }
            left.Right = node;
            if (left.Parent == node.Parent)
            {
                if (node == node.Parent.Right)
                {
                    node.Parent.Right = left;
                }
                else
                {
                    node.Parent.Left = left;
                }
            }
            else
            {
                root = left;
            }

            node.Parent = left;

            return root;
        }
    }
}
