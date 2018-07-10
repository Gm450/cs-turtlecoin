﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Canti.CryptoNote.P2P.Commands
{
    internal class CommandPing
    {
        // Command ID
        internal const int Id = GlobalsConfig.LEVIN_COMMANDS_BASE + 3;

        // Outgoing request structure
        internal struct Request : ICommandRequestBase
        {
            // Serializes request data into a byte array
            public byte[] Serialize()
            {
                // No data is needed for this request
                return new byte[0];
            }
        }

        // Incoming response structure
        internal struct Response : ICommandResponseBase<Response>
        {
            // Variables
            internal string Status { get; set; }
            internal ulong PeerId { get; set; }

            // Deseriaizes response data
            public Response Deserialize(byte[] Data)
            {
                // Deserialize data


                // Populate and return new response
                return new Response
                {
                    Status = "OK",
                    PeerId = 0
                };
            }
        }
    }
}
