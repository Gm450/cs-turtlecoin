//
// Copyright 2012-2013 The CryptoNote Developers
// Copyright 2014-2018 The Monero Developers
// Copyright 2018 The TurtleCoin Developers
//
// Please see the included LICENSE file for more information.

using System;
using Canti.Data;

namespace Canti.Blockchain.Crypto
{
    public class WalletKeys
    {
        public WalletKeys(KeyPair spendKeys, KeyPair viewKeys)
        {
            this.spendKeys = spendKeys;
            this.viewKeys = viewKeys;
        }

        public WalletKeys(PublicKey publicSpendKey, PrivateKey privateSpendKey,
                          PublicKey publicViewKey, PrivateKey privateViewKey)
        {
            this.spendKeys = new KeyPair(publicSpendKey, privateSpendKey);
            this.viewKeys = new KeyPair(publicViewKey, privateViewKey);
        }

        public KeyPair spendKeys;
        public KeyPair viewKeys;
    }

    public class KeyPair
    {
        public KeyPair(PublicKey publicKey, PrivateKey privateKey)
        {
            this.privateKey = privateKey;
            this.publicKey = publicKey;
        }

        public PrivateKey privateKey;
        public PublicKey publicKey;
    }

    public class PublicKeys
    {
        public PublicKeys(PublicKey spendKey, PublicKey viewKey)
        {
            this.spendKey = spendKey;
            this.viewKey = viewKey;
        }

        public PublicKey spendKey;
        public PublicKey viewKey;
    }

    public class PrivateKeys
    {
        public PrivateKeys(PrivateKey spendKey, PrivateKey viewKey)
        {
            this.spendKey = spendKey;
            this.viewKey = viewKey;
        }

        public PrivateKey spendKey;
        public PrivateKey viewKey;
    }

    public class ThirtyTwoByteKey
    {
        public ThirtyTwoByteKey(byte[] data)
        {
            if (data.Length < 32)
            {
                throw new ArgumentException("Input array must be at least 32 bytes long!");
            }

            this.data = new byte[32];

            /* We just copy the first 32 bytes. This allows us to take in a
               byte[] of any length, without having to resize first. A loop
               copy is apparently faster than Array.Copy() or
               Buffer.BlockCopy() when the length is of this size */
            for (int i = 0; i < 32; i++)
            {
                this.data[i] = data[i];
            }
        }

        public ThirtyTwoByteKey(string input)
        {
            /* 64 chars in hex == 32 bytes */
            if (input.Length < 64)
            {
                throw new ArgumentException("Input string must be at least 64 chars long!");
            }

            byte[] data = Encoding.HexStringToByteArray(input);

            this.data = new byte[32];

            for (int i = 0; i < 32; i++)
            {
                this.data[i] = data[i];
            }
        }

        public ThirtyTwoByteKey()
        {
            data = new byte[32];
        }

        public override bool Equals(object obj)
        {
            var other = obj as ThirtyTwoByteKey;

            if (other == null)
            {
                return false;
            }

            for (int i = 0; i < 32; i++)
            {
                if (data[i] != other.data[i])
                {
                    return false;
                }
            }

            return true;
        }

        public override int GetHashCode()
        {
            return data.GetHashCode();
        }

        public override string ToString()
        {
            return Encoding.ByteArrayToHexString(data);
        }

        public byte[] data { get; set; }
    }

    public class EllipticCurvePoint : ThirtyTwoByteKey
    {
        public EllipticCurvePoint(byte[] data) : base(data) {}
        public EllipticCurvePoint(string data) : base(data) {}
    }

    public class EllipticCurveScalar : ThirtyTwoByteKey
    {
        public EllipticCurveScalar(byte[] data) : base(data) {}
        public EllipticCurveScalar(string data) : base(data) {}
    }

    public class PrivateKey : ThirtyTwoByteKey
    {
        public PrivateKey(byte[] data) : base(data) {}
        public PrivateKey(string data) : base(data) {}
    }

    public class PublicKey : ThirtyTwoByteKey
    {
        public PublicKey(byte[] data) : base(data) {}
        public PublicKey(string data) : base(data) {}
    }
}
