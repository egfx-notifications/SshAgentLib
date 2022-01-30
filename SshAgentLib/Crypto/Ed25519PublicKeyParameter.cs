﻿//
// Ed25519PublicKeyParameter.cs
//
// Copyright (c) 2015 David Lechner
//
// Permission is hereby granted, free of charge, to any person obtaining a copy
// of this software and associated documentation files (the "Software"), to deal
// in the Software without restriction, including without limitation the rights
// to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
// copies of the Software, and to permit persons to whom the Software is
// furnished to do so, subject to the following conditions:
//
// The above copyright notice and this permission notice shall be included in
// all copies or substantial portions of the Software.
//
// THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
// IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
// FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
// AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
// LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
// OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN
// THE SOFTWARE.

using System;

using Chaos.NaCl;
using Org.BouncyCastle.Crypto;

namespace dlech.SshAgentLib.Crypto
{
    /// <summary>
    /// Glue to make Chaos.NaCl work with BouncyCastle
    /// </summary>
    public sealed class Ed25519PublicKeyParameter : AsymmetricKeyParameter
    {
        byte[] key;

        public byte[] Key
        {
            get
            {
                var copy = new byte[key.Length];
                Array.Copy(key, copy, key.Length);
                return copy;
            }
        }

        public Ed25519PublicKeyParameter(byte[] key) : base(privateKey: false)
        {
            if (key == null)
            {
                throw new ArgumentNullException("key");
            }
            if (key.Length != Ed25519.PublicKeySizeInBytes)
            {
                throw new ArgumentException("Bad key length.", "key");
            }
            this.key = key;
        }
    }
}
