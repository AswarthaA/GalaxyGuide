/*
 *   FileName: Enum.cs
 *   Class file: This file contains Enumerations used in the solution.
 *   Author: Aswartha Narayana
 *   Date Created: 16th Nov 2014
 *   
 *   Copyright (c) 2014 All Rights Reserved.. :)
*/

namespace GalaxyGuide.Common
{
    /// <summary>
    /// This contains Romans Keys and its values used in the Galaxy.
    /// </summary>
    public enum Romans
    {
        I = 1,
        V = 5,
        X = 10,
        L = 50,
        C = 100,
        D = 500,
        M = 1000
    }

    /// <summary>
    /// Type of inputs allowed in the Galaxy guide.
    /// </summary>
    public enum InputType
    {
        Roman,
        NewWord,
        AssignCredits,
        HowMuchIs,
        HowManyCredits,
        Invalid
    }
}
