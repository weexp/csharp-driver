//
//      Copyright (C) DataStax Inc.
//
//   Licensed under the Apache License, Version 2.0 (the "License");
//   you may not use this file except in compliance with the License.
//   You may obtain a copy of the License at
//
//      http://www.apache.org/licenses/LICENSE-2.0
//
//   Unless required by applicable law or agreed to in writing, software
//   distributed under the License is distributed on an "AS IS" BASIS,
//   WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
//   See the License for the specific language governing permissions and
//   limitations under the License.
//

using System;
using System.IO;
using Cassandra.Serialization;

namespace Cassandra
{
    internal class Frame
    {
        private readonly Stream _body;
        private readonly ISerializer _serializer;
        private readonly FrameHeader _header;

        /// <summary>
        /// The 8 byte protocol header
        /// </summary>
        public FrameHeader Header
        {
            get { return _header; }
        }

        /// <summary>
        /// A stream containing the frame body
        /// </summary>
        public Stream Body
        {
            get { return _body; }
        }

        /// <summary>
        /// Gets the serializer instance to be used for this frame
        /// </summary>
        public ISerializer Serializer
        {
            get { return _serializer; }
        }

        public Frame(FrameHeader header, Stream body, ISerializer serializer)
        {
            _header = header ?? throw new ArgumentNullException("header");
            _body = body ?? throw new ArgumentNullException("body");
            _serializer = serializer ?? throw new ArgumentNullException("serializer");
        }
    }
}