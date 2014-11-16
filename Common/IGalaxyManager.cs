/*
 *   FileName: IGalaxyManager.cs
 *   Class file: This file contains GalaxyManager interface.
 *   Author: Aswartha Narayana
 *   Date Created: 16th Nov 2014
 *   
 *   Copyright (c) 2014 All Rights Reserved.. :)
*/


namespace GalaxyGuide.Common
{
    /// <summary>
    /// Galaxy manager interface. 
    /// </summary>
    public interface IGalaxyManager
    {
        /// <summary>
        /// Processes the messages given by the merchant.
        /// </summary>
        /// <param name="inputString"><see cref="string"/></param>
        /// <returns><see cref="string"/></returns>
        string ProcessMessage(string inputString);

        /// <summary>
        /// Converts Roman value to Hindu Arabic value. Like XXI equals to 21
        /// </summary>
        /// <param name="arabicString"><see cref="string"/></param>
        /// <returns><see cref="string"/></returns>
        string GetHinduArabicValue(string arabicString);

    }
}
