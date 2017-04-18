using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;

// TODO: Fix this class.

namespace Syroot.NintenTools.MarioKart8.Courses
{
    /// <summary>
    /// Represents a list of points forming a path.
    /// </summary>
    /// <typeparam name="TPath">The type of the path holding the points.</typeparam>
    /// <typeparam name="TPoint">The type of the points.</typeparam>
    [DebuggerDisplay("PathPointCollection ({_list.Count} points)")]
    public class PathPointCollection<TPath, TPoint> : IList<TPoint>, IList
        where TPath : PathBase<TPath, TPoint>
        where TPoint : PathPointBase<TPath, TPoint>, ICourseReferencable, new()
    {
        // ---- MEMBERS ------------------------------------------------------------------------------------------------

        private List<TPoint> _list;

        // ---- CONSTRUCTORS & DESTRUCTOR ------------------------------------------------------------------------------
        
        private PathPointCollection()
        {
            _list = new List<TPoint>();
        }
        
        // ---- PROPERTIES ---------------------------------------------------------------------------------------------

        /// <summary>
        /// Gets the path consisting of the points in this collection.
        /// </summary>
        public TPath Parent
        {
            get;
            private set;
        }

        /// <summary>
        /// Gets the number of elements contained in the <see cref="PathPointCollection{TPath, TPoint}"/>.
        /// </summary>
        public int Count
        {
            get
            {
                return _list.Count;
            }
        }

        /// <summary>
        /// Gets a value indicating whether the <see cref="PathPointCollection{TPath, TPoint}"/> has a fixed size.
        /// </summary>
        public bool IsFixedSize
        {
            get { return false; }
        }

        /// <summary>
        /// Gets a value indicating whether the <see cref="PathPointCollection{TPath, TPoint}"/> is read-only.
        /// </summary>
        public bool IsReadOnly
        {
            get
            {
                return false;
            }
        }

        /// <summary>
        /// Gets a value indicating whether access to the <see cref="PathPointCollection{TPath, TPoint}"/> is
        /// synchronized (thread safe).
        /// </summary>
        public bool IsSynchronized
        {
            get { return false; }
        }

        /// <summary>
        /// Not supported by this class.
        /// </summary>
        public object SyncRoot
        {
            get { throw new NotImplementedException(); }
        }

        // ---- OPERATORS ----------------------------------------------------------------------------------------------

        /// <summary>
        /// Gets or sets the element at the given <paramref name="index"/>.
        /// </summary>
        /// <param name="index">The index of the element..</param>
        /// <returns>The element at the given index.</returns>
        object IList.this[int index]
        {
            get { return _list[index]; }
            set { _list[index] = (TPoint)value; }
        }

        /// <summary>
        /// Gets or sets the point at the specified index.
        /// </summary>
        /// <param name="index">The zero-based index of the point to get or set.</param>
        /// <returns>The point at the specified index.</returns>
        public TPoint this[int index]
        {
            get
            {
                return _list[index];
            }
            set
            {
                // Remove the current point.
                TPoint currentPoint = _list[index];
                if (currentPoint != null)
                {
                    currentPoint.PathInternal = null;
                }

                // Set the new point.
                if (value != null)
                {
                    value.PathInternal = Parent;
                    _list[index] = value;
                }
            }
        }

        // ---- METHODS (PUBLIC) ---------------------------------------------------------------------------------------

        /// <summary>
        /// Adds a point to the <see cref="PathPointCollection{TPath, TPoint}"/>.
        /// </summary>
        /// <param name="item">The point to add to the <see cref="PathPointCollection{TPath, TPoint}"/>.</param>
        public void Add(TPoint item)
        {
            _list.Add(item);
            if (item != null)
            {
                item.PathInternal = Parent;
            }
        }

        /// <summary>
        /// Adds a point to the <see cref="PathPointCollection{TPath, TPoint}"/> and returns the index at which it was
        /// added.
        /// </summary>
        /// <param name="value">The point to add to the <see cref="PathPointCollection{TPath, TPoint}"/>.</param>
        /// <returns>The index at which the point was added.</returns>
        public int Add(object value)
        {
            Add((TPoint)value);
            return _list.Count - 1;
        }

        /// <summary>
        /// Adds the point instances of the specified collection to the end of the
        /// <see cref="PathPointCollection{TPath, TPoint}"/>.
        /// </summary>
        /// <param name="instances">The collection whose elements should be added to the end of the
        /// <see cref="PathPointCollection{TPath, TPoint}"/>. The collection itself cannot be <c>null</c>, but it can
        /// contain elements that are <c>null</c>.</param>
        public void AddRange(IEnumerable<TPoint> instances)
        {
            foreach (TPoint point in instances)
            {
                point.PathInternal = Parent;
            }
            _list.AddRange(instances);
        }

        /// <summary>
        /// Removes all items from the <see cref="PathPointCollection{TPath, TPoint}"/>.
        /// </summary>
        public void Clear()
        {
            _list.Clear();
            foreach (TPoint point in _list)
            {
                point.PathInternal = null;
            }
        }

        /// <summary>
        /// Determines whether the <see cref="PathPointCollection{TPath, TPoint}"/> contains a specific point.
        /// </summary>
        /// <param name="item">The point to locate in the <see cref="PathPointCollection{TPath, TPoint}"/>.
        /// </param>
        /// <returns><c>true</c> if the point is found in the <see cref="PathPointCollection{TPath, TPoint}"/>;
        /// otherwise, <c>false</c>.</returns>
        public bool Contains(TPoint item)
        {
            return _list.Contains(item);
        }

        /// <summary>
        /// Determines whether the <see cref="PathPointCollection{TPath, TPoint}"/> contains a specific point.
        /// </summary>
        /// <param name="value">The point to locate in the <see cref="PathPointCollection{TPath, TPoint}"/>.
        /// </param>
        /// <returns><c>true</c> if the point is found in the <see cref="PathPointCollection{TPath, TPoint}"/>;
        /// otherwise, <c>false</c>.</returns>
        public bool Contains(object value)
        {
            return Contains((TPoint)value);
        }

        /// <summary>
        /// Copies the elements of the <see cref="PathPointCollection{TPath, TPoint}"/> to an <see cref="Array"/>,
        /// starting at a particular <see cref="Array"/> index.
        /// </summary>
        /// <param name="array">The one-dimensional <see cref="Array"/> that is the destination of the elements copied
        /// from <see cref="PathPointCollection{TPath, TPoint}"/>. The <see cref="Array"/> must have zero-based
        /// indexing.</param>
        /// <param name="arrayIndex">The zero-based index in <paramref name="array"/> at which copying begins.</param>
        public void CopyTo(TPoint[] array, int arrayIndex)
        {
            _list.CopyTo(array, arrayIndex);
        }

        /// <summary>
        /// Copies the elements of the <see cref="PathPointCollection{TPath, TPoint}"/> to an <see cref="Array"/>,
        /// starting at a particular <see cref="Array"/> index.
        /// </summary>
        /// <param name="array">The one-dimensional <see cref="Array"/> that is the destination of the elements copied
        /// from <see cref="PathPointCollection{TPath, TPoint}"/>. The <see cref="Array"/> must have zero-based
        /// indexing.</param>
        /// <param name="index">The zero-based index in <paramref name="array"/> at which copying begins.</param>
        public void CopyTo(Array array, int index)
        {
            _list.CopyTo((TPoint[])array, index);
        }

        /// <summary>
        /// Returns an enumerator that iterates through the collection.
        /// </summary>
        /// <returns>An enumerator that can be used to iterate through the collection.</returns>
        public IEnumerator<TPoint> GetEnumerator()
        {
            return _list.GetEnumerator();
        }

        /// <summary>
        /// Determines the index of a specific item in the <see cref="PathPointCollection{TPath, TPoint}"/>.
        /// </summary>
        /// <param name="item">The object to locate in the <see cref="PathPointCollection{TPath, TPoint}"/>.</param>
        /// <returns>The index of the point if found in the list; otherwise, -1.</returns>
        public int IndexOf(TPoint item)
        {
            return _list.IndexOf(item);
        }

        /// <summary>
        /// Determines the index of a specific item in the <see cref="PathPointCollection{TPath, TPoint}"/>.
        /// </summary>
        /// <param name="value">The object to locate in the <see cref="PathPointCollection{TPath, TPoint}"/>.</param>
        /// <returns>The index of the point if found in the list; otherwise, -1.</returns>
        public int IndexOf(object value)
        {
            return IndexOf((TPoint)value);
        }

        /// <summary>
        /// Inserts a point to the <see cref="PathPointCollection{TPath, TPoint}"/> at the specified index.
        /// </summary>
        /// <param name="index">The zero-based index at which the point should be inserted.</param>
        /// <param name="item">The point to insert into the <see cref="PathPointCollection{TPath, TPoint}"/>.</param>
        public void Insert(int index, TPoint item)
        {
            _list.Insert(index, item);
            item.PathInternal = Parent;
        }

        /// <summary>
        /// Inserts a point to the <see cref="PathPointCollection{TPath, TPoint}"/> at the specified index.
        /// </summary>
        /// <param name="index">The zero-based index at which the point should be inserted.</param>
        /// <param name="value">The point to insert into the <see cref="PathPointCollection{TPath, TPoint}"/>.</param>
        public void Insert(int index, object value)
        {
            Insert(index, (TPoint)value);
        }

        /// <summary>
        /// Removes the first occurrence of a specific point from the <see cref="PathPointCollection{TPath, TPoint}"/>.
        /// </summary>
        /// <param name="item">The point to remove from the <see cref="PathPointCollection{TPath, TPoint}"/>.</param>
        /// <returns><c>true</c> if the point was successfully removed from the
        /// <see cref="PathPointCollection{TPath, TPoint}"/>; otherwise, <c>false</c>. This method also returns
        /// <c>false</c> if the point is not found in the original <see cref="PathPointCollection{TPath, TPoint}"/>.
        /// </returns>
        public bool Remove(TPoint item)
        {
            if (_list.Remove(item))
            {
                item.PathInternal = null;
                return true;
            }
            return false;
        }

        /// <summary>
        /// Removes the first occurrence of a specific point from the <see cref="PathPointCollection{TPath, TPoint}"/>.
        /// </summary>
        /// <param name="value">The point to remove from the <see cref="PathPointCollection{TPath, TPoint}"/>.</param>
        public void Remove(object value)
        {
            Remove((TPoint)value);
        }

        /// <summary>
        /// Removes the <see cref="PathPointCollection{TPath, TPoint}"/> point at the specified index.
        /// </summary>
        /// <param name="index">The zero-based index of the point to remove.</param>
        public void RemoveAt(int index)
        {
            TPoint point = _list[index];
            _list.RemoveAt(index);
            point.PathInternal = null;
        }
        
        /// <summary>
        /// Returns an enumerator that iterates through a collection.
        /// </summary>
        /// <returns>An <see cref="IEnumerable"/> object that can be used to iterate through the collection.</returns>
        IEnumerator IEnumerable.GetEnumerator()
        {
            return _list.GetEnumerator();
        }
    }
}
