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

        /// <summary>
        /// The 3 cases of red-black tree insertion
        /// z stands for current node, p[z] is parent, p[p[z]] is grandparent, y is uncle
        /// </summary>
        /// <param name="node"></param>
        /// <param name="root"></param>
        /// <returns></returns>
        private RbNode InsertRebalance(RbNode node, RbNode root)
        {
            RbNode parent, gparent, uncle, temp;

            while ((parent = node.Parent) != null && parent.Color == RbColor.Red)
            {
                gparent = parent.Parent;

                if (parent == gparent.Left)
                {
                    uncle = gparent.Right;
                    if (uncle != null && uncle.Color == RbColor.Red)
                    {
                        uncle.Color = RbColor.Black;
                        parent.Color = RbColor.Black;
                        gparent.Color = RbColor.Red;
                        node = gparent;
                    }
                    else
                    {
                        if (parent.Right == node)
                        {
                            root = RotateLeft(parent, root);
                            temp = parent;
                            parent = node;
                            node = temp;
                        }

                        parent.Color = RbColor.Black;
                        gparent.Color = RbColor.Red;
                        root = RotateRight(gparent, root);
                    }
                }
                else
                {
                    uncle = gparent.Left;
                    if (uncle != null && uncle.Color == RbColor.Red)
                    {
                        uncle.Color = RbColor.Black;
                        parent.Color = RbColor.Black;
                        gparent.Color = RbColor.Red;
                        node = gparent;
                    }
                    else
                    {
                        if (parent.Left == node)
                        {
                            root = RotateRight(parent, root);
                            temp = parent;
                            parent = node;
                            node = temp;
                        }

                        parent.Color = RbColor.Black;
                        gparent.Color = RbColor.Red;
                        root = RotateLeft(gparent, root);
                    }
                }
            }

            root.Color = RbColor.Black;
            return root;
        }

        private RbNode SearchAuxiliary(int key, RbNode root, ref RbNode save)
        {
            RbNode node = root;
            RbNode parent = null;
            int ret;

            while (node != null)
            {
                parent = node;
                ret = node.Key - key;
                if (ret > 0)
                {
                    node = node.Left;
                }
                else if (ret < 0)
                {
                    node = node.Right;
                }
                else
                {
                    return node;
                }
            }

            if (parent != null)
            {
                save = parent;
            }

            return null;
        }

        private RbNode Search(int key, RbNode root)
        {
            RbNode parent = root;
            return SearchAuxiliary(key, root, ref parent);
        }

        private RbNode Insert(int key, int data, RbNode root)
        {
            RbNode parent = null;
            RbNode node = null;

            node = SearchAuxiliary(key, root, ref parent);
            if (node != null)
            {
                node.Data++;
                return root;
            }

            node = CreateNode(key, data);
            node.Parent = parent;
            if (parent != null)
            {
                if (parent.Key > key)
                {
                    parent.Left = node;
                }
                else
                {
                    parent.Right = node;
                }
            }
            else
            {
                root = node;
            }

            return InsertRebalance(node, root);
        }
    }
}
