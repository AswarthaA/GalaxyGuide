/*
 *   FileName: GalaxyDictionary.cs
 *   Class file: This file contains Custom dictionary used for storing galaxy units and items.
 *   Author: Aswartha Narayana
 *   Date Created: 16th Nov 2014
 *   
 *   Copyright (c) 2014 All Rights Reserved.. :)
*/

namespace GalaxyGuide.Common
{
    using System.Collections.Generic;

    /// <summary>
    /// Galaxy dictionary extended from <see cref="Dictionary{TKey,TValue}"/>. 
    /// </summary>
    /// <typeparam name="TKey">Any class can be used as Key.</typeparam>
    /// <typeparam name="TValue">Any class can be used as Value.</typeparam>
    public class GalaxyDictionary<TKey, TValue> : Dictionary<TKey, TValue>
    {
        /// <summary>
        /// If key already exists value will be updated, otherwise added to the Dictionary.
        /// </summary>
        /// <param name="key">Any type can by used.</param>
        /// <param name="value">Any type can by used.</param>
        public void AddUpdateKey(TKey key, TValue value)
        {
            if (ContainsKey(key))
            {
                this[key] = value;
            }
            else
            {
                Add(key, value);
            }
        }
    }
}
