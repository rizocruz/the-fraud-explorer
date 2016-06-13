/*
 * The Fraud Explorer
 * http://www.thefraudexplorer.com/
 *
 * Copyright (c) 2016 The Fraud Explorer
 * email: support@thefraudexplorer.com
 * Licensed under GNU GPL v3
 * http://www.thefraudexplorer.com/License
 *
 * Date: 2016-06-30 15:12:41 -0500 (Wed, 30 Jun 2016)
 * Revision: v0.9.6-beta
 *
 * Description: Cipher methods
 */

using System;

namespace The_Fraud_Explorer_Configurator.Crypto
{
    /// <summary>
    /// Variables cipher
    /// </summary>

    #region Variables cipher
    class CipherMethods { }

    public class Ciphers
    {

        public static string XMorEncryptText(string ClearText)
        {
            try
            {
                string output = string.Empty;
                Random keyGen = new Random(int.MaxValue - (int)(int.MaxValue * 0.2333));

                foreach (char c in ClearText)
                {
                    int cByte = (int)Convert.ToByte(c);
                    output += (cByte * keyGen.Next(10000)).ToString() + "~";
                }

                return output.Remove(output.Length - 1, 1);
            }
            catch {}
            return null;
        }     
    }

    #endregion
}
